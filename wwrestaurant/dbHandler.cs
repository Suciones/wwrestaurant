using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace wwrestaurant {
    class dbHandler {
        private string connString; //se va folosi string-ul catre azure

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



        //Constructorul l-am facut asftel incat sa nu trebuiasca initializate neaparat toate dataset-urile
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



        //Functie de complete order. Ia ca input id-ul comenzii si returneaza true daca ordinul
        //este eligibil pentru compensatie dupa 30 de minute, sau false daca nu este.
        //Poate fi folosit direct, sau printr-o variabila (e.g. bool result = handler.CompleteOrder(id))
        //In cazul asta CompleteOrder() va fi executat si va stoca rezultatul in result.
        public bool CompleteOrder(int id) {
            using(SqlConnection connection = new SqlConnection(connString)) {
                try {
                    connection.Open();

                    using(SqlTransaction transaction = connection.BeginTransaction()) {
                        try {
                            string update_query = "UPDATE orders SET status = 'completed' WHERE order_id = @id AND status != 'completed'";
                            string select_query = "SELECT time FROM orders WHERE order_id = @id";
                            DateTime orderTime;
                            int affected_rows;

                            using(SqlCommand update_command = new SqlCommand(update_query, connection, transaction)) {
                                update_command.Parameters.AddWithValue("@id", id);
                                affected_rows = update_command.ExecuteNonQuery();

                                if(affected_rows == 0) {
                                    Console.WriteLine("Order has already been completed!");
                                }
                            }

                            using(SqlCommand select_command = new SqlCommand(select_query, connection, transaction)) {
                                select_command.Parameters.AddWithValue("@id", id);

                                using(SqlDataReader reader = select_command.ExecuteReader()) {
                                    if(reader.Read()) {
                                        orderTime = reader.GetDateTime(reader.GetOrdinal("time"));
                                    }
                                    else {
                                        throw new Exception("Order with ID " + id + " not found!");
                                    }
                                }
                            }

                            transaction.Commit();

                            DateTime now = DateTime.Now;
                            now = now.AddHours(-3);
                            Console.WriteLine($"Order time: {orderTime}, Now: {now}, Order+30min: {orderTime.AddMinutes(30)}");

                            return now > orderTime.AddMinutes(30);


                        }
                        catch(Exception e) {
                            transaction.Rollback();
                            throw new Exception("Error completing order: " + e.Message + " Rolling back...");
                        }
                    }
                }
                catch(Exception e) {
                    throw new Exception("Error connecting to database: " + e.Message);
                }
            }
        }




    }
}
