using System;

namespace wwrestaurant {
    class Program {
        public static void Main(string[] args) {
            dbConnection db = new dbConnection();
            db.ExecuteQuery();
        }
    }
}
