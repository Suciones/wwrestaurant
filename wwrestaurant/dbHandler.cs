using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.Data;

namespace wwrestaurant {
    class dbHandler {
        private string connstring; // Mergeti in Project -> Add New Data Source -> Database -> Dataset -> Show connection string.
                                   // Inlocuiti |DataDirectoy| cu path-ul spre wwwrestaurant.mdf 

        private DataSet menu_ds = new DataSet();
        private DataSet order_items_ds = new DataSet();
        private DataSet orders_ds = new DataSet();
        private DataSet tables_ds = new DataSet();
        private DataSet users_ds = new DataSet();
        private DataSet waiters_ds = new DataSet();

        //Constructorul l-am facut asftel incat sa nu trebuiasa initializate neaparat toate dataset-urile
        public dbHandler(string connstring, DataSet menu_ds = null, DataSet order_items_ds = null,
                        DataSet orders_ds = null, DataSet tables_ds = null, DataSet users_ds = null, DataSet waiters_ds = null) {

            this.connstring = connstring;
            this.menu_ds = menu_ds ?? this.menu_ds;
            this.order_items_ds = order_items_ds ?? this.order_items_ds;
            this.orders_ds = orders_ds ?? this.orders_ds;
            this.tables_ds = tables_ds ?? this.tables_ds;
            this.users_ds = users_ds ?? this.users_ds;
            this.waiters_ds = waiters_ds ?? this.waiters_ds;
        }

        //Metoda pentru a extrage UN item din meniu dupa NUME. Returneaza un tuple cu ID, descriere, pret, si URL-ul pozei
        public (int itemId, string description, decimal price, string picture) GetMenuItem(string name) {
            using(SqlConnection connection = new SqlConnection(connstring)) {
                try {
                    connection.Open();

                    string query = "SELECT item_id, description, price, picture FROM menu WHERE name = @name";
                    using(SqlCommand command = new SqlCommand(query, connection)) {
                        
                        command.Parameters.AddWithValue("@name", name);

                        using(SqlDataReader reader = command.ExecuteReader()) {
                            if(reader.Read()) {
                                int itemId = reader.GetInt32(reader.GetOrdinal("item_id"));
                                string description = reader.GetString(reader.GetOrdinal("description"));
                                decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
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
    }
}
