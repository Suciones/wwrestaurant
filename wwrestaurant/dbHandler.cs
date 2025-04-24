using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace wwrestaurant {
    class dbHandler {
        private string connString; // Mergeti in Project -> Add New Data Source -> Database -> Dataset -> Show connection string.
                                   // Inlocuiti |DataDirectoy| cu path-ul spre wwwrestaurant.mdf 

        private DataSet menu_ds;
        private DataSet order_items_ds;
        private DataSet orders_ds;
        private DataSet tables_ds;
        private DataSet users_ds;
        private DataSet waiters_ds;

        private SqlDataAdapter menu_ad;
        private SqlDataAdapter order_items_ad;
        private SqlDataAdapter orders_ad;
        private SqlDataAdapter tables_ad;
        private SqlDataAdapter users_ad;
        private SqlDataAdapter waiters_ad;



        //Constructorul l-am facut asftel incat sa nu trebuiasa initializate neaparat toate dataset-urile
        public dbHandler(string connString, DataSet menu_ds = null, DataSet order_items_ds = null,
                        DataSet orders_ds = null, DataSet tables_ds = null, DataSet users_ds = null, DataSet waiters_ds = null) {

            //dataset-urile
            this.connString = connString;
            this.menu_ds = menu_ds ?? this.menu_ds;
            this.order_items_ds = order_items_ds ?? this.order_items_ds;
            this.orders_ds = orders_ds ?? this.orders_ds;
            this.tables_ds = tables_ds ?? this.tables_ds;
            this.users_ds = users_ds ?? this.users_ds;
            this.waiters_ds = waiters_ds ?? this.waiters_ds;

            //adapters
            menu_ad = new SqlDataAdapter("SELECT * FROM menu", connString);
            order_items_ad = new SqlDataAdapter("SELECT * FROM order_items", connString);
            orders_ad = new SqlDataAdapter("SELECT * FROM orders", connString);
            tables_ad = new SqlDataAdapter("SELECT * FROM tables", connString);
            users_ad = new SqlDataAdapter("SELECT * FROM users", connString);
            waiters_ad = new SqlDataAdapter("SELECT * FROM waiters", connString);


        }

        public void RefreshDataset(DataSet ds, SqlDataAdapter ad, string table_name) {
            ds.Clear();
            ad.Fill(ds, table_name);
        }

        //Metoda pentru a extrage UN item din meniu dupa NUME. Returneaza un tuple cu ID, descriere, pret, si URL-ul pozei
        public (int itemId, string description, float price, string picture) GetMenuItem(string name) {
            using(SqlConnection connection = new SqlConnection(connString)) {
                try {
                    connection.Open();
                    RefreshDataset(menu_ds, menu_ad, "menu");

                    string query = "SELECT item_id, description, price, picture FROM menu WHERE name = @name";
                    using(SqlCommand command = new SqlCommand(query, connection)) {

                        command.Parameters.AddWithValue("@name", name);

                        using(SqlDataReader reader = command.ExecuteReader()) {
                            if(reader.Read()) {
                                int itemId = reader.GetInt32(reader.GetOrdinal("item_id"));
                                string description = reader.GetString(reader.GetOrdinal("description"));
                                float price = (float)reader.GetDouble(reader.GetOrdinal("price"));
                                string picture = reader.GetString(reader.GetOrdinal("picture"));

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

        public void UpdateTableStatus(int tableNumber, string status)
        {
            // Use a parameterized UPDATE query to avoid SQL injection
            string query = "UPDATE tables SET status_table = @status WHERE table_nr = @tableNumber";
            using (SqlConnection con = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Set parameter values
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@tableNumber", tableNumber);

                con.Open();
                cmd.ExecuteNonQuery();  // Execute the update command
            }
        }
        public void ResetTableStatus(int tableNumber)
        {
            // Simply call UpdateTableStatus with "empty"
            UpdateTableStatus(tableNumber, "empty");
        }

    }
}
