using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace wwrestaurant {
    class dbHandler {
        private string connString= @"Server=tcp:wwrestaurantserver.database.windows.net,1433;Initial Catalog=wwrestaurant;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=""Active Directory Default"""; //se va folosi string-ul catre azure

        public DataSet menu_ds;
        public DataSet order_items_ds;
        public DataSet orders_ds;
        public DataSet tables_ds;
        public DataSet users_ds;
       

        public SqlDataAdapter menu_ad;
        public SqlDataAdapter order_items_ad;
        public SqlDataAdapter orders_ad;
        public SqlDataAdapter tables_ad;
        public SqlDataAdapter users_ad;
       



        //Constructorul l-am facut asftel incat sa nu trebuiasca initializate neaparat toate dataset-urile
        public dbHandler(DataSet menu_ds = null, DataSet order_items_ds = null,
                        DataSet orders_ds = null, DataSet tables_ds = null, DataSet users_ds = null) {

            //dataset-urile
            //this.connString = connString;
            this.menu_ds = menu_ds ?? this.menu_ds;
            this.order_items_ds = order_items_ds ?? this.order_items_ds;
            this.orders_ds = orders_ds ?? this.orders_ds;
            this.tables_ds = tables_ds ?? this.tables_ds;
            this.users_ds = users_ds ?? this.users_ds;
          
            //adapters
            menu_ad = new SqlDataAdapter("SELECT * FROM menu", connString);
            order_items_ad = new SqlDataAdapter("SELECT * FROM order_items", connString);
            orders_ad = new SqlDataAdapter("SELECT * FROM orders", connString);
            tables_ad = new SqlDataAdapter("SELECT * FROM tables", connString);
            users_ad = new SqlDataAdapter("SELECT * FROM users", connString);
            


        }

        public void RefreshDataset(DataSet ds, SqlDataAdapter ad, string table_name) {
            ds.Clear();
            ad.Fill(ds, table_name);
        }

        //Metoda pentru a extrage UN item din meniu dupa NUME. Returneaza un tuple cu ID, descriere, pret, si URL-ul pozei
        public (int itemId, string description, decimal price, string picture) GetMenuItem(string name) {
            using(SqlConnection connection = new SqlConnection(connString)) {
                try {
                    connection.Open();
                    RefreshDataset(menu_ds, menu_ad, "menu");

                    string query = "SELECT item_id, description, price, picture FROM dbo.menu WHERE name = @name";
                    using(SqlCommand command = new SqlCommand(query, connection)) {

                        command.Parameters.AddWithValue("@name", name);

                        using(SqlDataReader reader = command.ExecuteReader()) {
                            if(reader.Read()) {
                                int itemId = reader.GetInt32(reader.GetOrdinal("item_id"));

                                string description = reader.IsDBNull(reader.GetOrdinal("description"))
                                    ? ""
                                    : reader.GetString(reader.GetOrdinal("description"));

                                decimal price = reader.IsDBNull(reader.GetOrdinal("price"))
                                    ? 0.0m
                                    : reader.GetDecimal(reader.GetOrdinal("price"));

                                string picture = reader.IsDBNull(reader.GetOrdinal("picture"))
                                    ? ""
                                    : reader.GetString(reader.GetOrdinal("picture"));

                                return (itemId, description, price, picture);
                            }
                            else {
                                throw new Exception($"Menu item with name '{name}' not found.");
                            }
                        }
                    }
                }
                catch(Exception ex) {
                    throw new Exception("Error retrieving menu item: " + ex.Message);
                }
            }
        }

        //Functie de adaugat item in meniu (admin). Se seteaza nume, descriere, pret si path-ul catre poza (optional)
        public void AddMenuItem(string name, string description, decimal price, string picture = "") {
            using(SqlConnection connection = new SqlConnection(connString)) {
                try {
                    connection.Open();
                    using(SqlTransaction transaction = connection.BeginTransaction()) {
                        try {
                            string query = "INSERT INTO menu (name, description, price, picture) VALUES (@name, @description, @price, @picture)";
                            using(SqlCommand command = new SqlCommand(query, connection, transaction)) {
                                command.Parameters.AddWithValue("@name", name);
                                command.Parameters.AddWithValue("@description", description);
                                command.Parameters.AddWithValue("@price", price);
                                command.Parameters.AddWithValue("@picture", picture);

                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch(Exception e) {
                            transaction.Rollback();
                            throw new Exception("Error adding to database: " + e.Message + " Rolling back...");

                        }
                    }
                }
                catch(Exception e) {
                    throw new Exception("Error connecting to database: " + e.Message);
                }
            }
        }

        //Functia createOrder are ca input numarul mesei la care se efectueaza comanda si o lista cu iteme din meniu. 
        //Itemele trebuie sa existe, altfel va aparea o eroare.
        //
        //Recommended workflow:
        //1. Buton pentru initializare comanda
        //2. Se adauga iteme existente din meniu
        //3. Buton pentru trimitere comanda

        public void createOrder(int table_nr, List<int> item_id) {
            using(SqlConnection connection = new SqlConnection(connString)) {
                connection.Open();
                using(SqlTransaction transaction = connection.BeginTransaction()) {
                    try {
                        string create_query = "INSERT INTO orders (table_nr) VALUES (@table_nr); SELECT SCOPE_IDENTITY();";
                        int order_id;

                        using(SqlCommand create_command = new SqlCommand(create_query, connection, transaction)) {
                            create_command.Parameters.AddWithValue("@table_nr", table_nr);
                            object result = create_command.ExecuteScalar();
                            if(result == null || !int.TryParse(result.ToString(), out order_id)) {
                                throw new Exception("Failed to retrieve the created order ID!");
                            }
                        }

                        foreach(int item in item_id) {
                            string add_query = "INSERT INTO order_items (order_id, item_id) VALUES (@order_id, @item_id)";
                            using(SqlCommand add_command = new SqlCommand(add_query, connection, transaction)) {
                                add_command.Parameters.AddWithValue("@order_id", order_id);
                                add_command.Parameters.AddWithValue("@item_id", item);
                                int rowsAffected = add_command.ExecuteNonQuery();
                                if(rowsAffected == 0) {
                                    throw new Exception($"Failed to add item with ID {item} to the order!");
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch(Exception ex) {
                        transaction.Rollback();
                        throw new Exception("Error creating order: " + ex.Message);
                    }

                }
            }
        }

        public void createOrder2(int table_nr, List<OrderItem> items)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert order and get ID
                        string create_query = "INSERT INTO orders (table_nr, status, time) VALUES (@table_nr, 'In Progress', @time); SELECT SCOPE_IDENTITY();";
                        int order_id;

                        using (SqlCommand create_command = new SqlCommand(create_query, connection, transaction))
                        {
                            create_command.Parameters.AddWithValue("@table_nr", table_nr);
                            create_command.Parameters.AddWithValue("@time", DateTime.Now);
                            object result = create_command.ExecuteScalar();
                            if (result == null || !int.TryParse(result.ToString(), out order_id))
                            {
                                throw new Exception("Failed to retrieve the created order ID!");
                            }
                        }

                        // Insert each item, as many times as Quantity
                        foreach (OrderItem item in items)
                        {
                            for (int i = 0; i < item.Quantity; i++)
                            {
                                string add_query = "INSERT INTO order_items (order_id, item_id) VALUES (@order_id, @item_id)";
                                using (SqlCommand add_command = new SqlCommand(add_query, connection, transaction))
                                {
                                    add_command.Parameters.AddWithValue("@order_id", order_id);
                                    add_command.Parameters.AddWithValue("@item_id", item.ItemId);
                                    int rowsAffected = add_command.ExecuteNonQuery();
                                    if (rowsAffected == 0)
                                    {
                                        throw new Exception($"Failed to add item with ID {item.ItemId} to the order!");
                                    }
                                }
                            }
                        }

                        // Update table status
                        string update_query = "UPDATE tables SET status_table = 'Occupied' WHERE table_nr = @table_nr";
                        using (SqlCommand update_cmd = new SqlCommand(update_query, connection, transaction))
                        {
                            update_cmd.Parameters.AddWithValue("@table_nr", table_nr);
                            update_cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error creating order: " + ex.Message);
                    }
                }
            }
        }

    }
}
