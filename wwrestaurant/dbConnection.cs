using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace wwrestaurant {
    class dbConnection {
        private string connectionString = "datasource=localhost;port=3306;username=root;password=;database=wwrestaurant;";

        public void ExecuteQuery() {
            string query = "SELECT * FROM user";

            using(MySqlConnection databaseConnection = new MySqlConnection(connectionString)) {
                using(MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection)) {
                    commandDatabase.CommandTimeout = 60;

                    try {
                        databaseConnection.Open();
                        using(MySqlDataReader reader = commandDatabase.ExecuteReader()) {
                            if(reader.HasRows) {
                                while(reader.Read()) {
                                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                                    // Process the row data as needed
                                }
                            }
                            else {
                                Console.WriteLine("No rows found.");
                            }
                        }
                    }
                    catch(Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
