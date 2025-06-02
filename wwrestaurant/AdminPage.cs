using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wwrestaurant;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace wwrestaurant {
    public partial class AdminPage:Form {
        private dbHandler handler;
        private DataSet menu_ds;
        private DataSet users_ds;
        private DateTime selectedDate = DateTime.Now;

        public AdminPage() {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;


            menu_ds = new DataSet();
            users_ds = new DataSet();
            handler = new dbHandler(menu_ds: menu_ds, users_ds: users_ds);

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            handler.menu_ad.Fill(menu_ds, "menu");
            handler.users_ad.Fill(users_ds, "users");
            dataGridView1.DataSource = menu_ds.Tables[0];
            dataGridView2.DataSource = users_ds.Tables[0];

            dataGridView1.ReadOnly = false;
            dataGridView2.ReadOnly = false;

            // Initialize calendar
            calendar.DateChanged += Calendar_DateChanged;
            dateLabel.Text = "Selected Date: " + selectedDate.ToShortDateString();

            // Load waiters into combobox
            LoadWaiters();

            // Load initial statistics
            RefreshStatistics();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void Calendar_DateChanged(object sender, DateRangeEventArgs e) {
            selectedDate = e.Start;
            dateLabel.Text = "Selected Date: " + selectedDate.ToShortDateString();
            RefreshStatistics();
        }

        private void LoadWaiters() {
            try {
                // Get waiters and populate combobox
                var waiters = handler.GetWaiters();

                // Create a dictionary for the combobox
                Dictionary<string, int> waiterItems = new Dictionary<string, int>();
                foreach(var waiter in waiters) {
                    waiterItems.Add(waiter.name, waiter.id);
                }

                comboBox1.DataSource = new BindingSource(waiterItems, null);
                comboBox1.DisplayMember = "Key";
                comboBox1.ValueMember = "Value";
            }
            catch(Exception ex) {
                MessageBox.Show("Error loading waiters: " + ex.Message);
            }
        }

        private void RefreshStatistics() {
            try {
                // Get statistics for selected date
                var stats = GetStatsForDate(selectedDate);

                // Update textboxes
                textBox1.Text = stats.totalIncome.ToString("C", new CultureInfo("de-DE"));
                textBox2.Text = stats.completedOrders.ToString(); // Orders completed
                textBox3.Text = stats.delayedOrders.ToString(); // Orders delayed

                // Update waiter income if a waiter is selected
                UpdateWaiterIncome();
            }
            catch(Exception ex) {
                MessageBox.Show("Error refreshing statistics: " + ex.Message);
            }
        }

        private void UpdateWaiterIncome() {
            if(comboBox1.SelectedItem != null) {
                try {
                    // Get the selected waiter ID
                    KeyValuePair<string, int> selectedWaiter = (KeyValuePair<string, int>)comboBox1.SelectedItem;
                    int waiterId = selectedWaiter.Value;

                    // Debug info
                    Console.WriteLine($"Selected waiter: {selectedWaiter.Key}, ID: {waiterId}");

                    // Get waiter's income for the selected date
                    decimal waiterIncome = GetWaiterIncomeForDate(waiterId, selectedDate);

                    // Debug the income value
                    Console.WriteLine($"Waiter income: {waiterIncome}");

                    // Update textbox
                    textBox4.Text = waiterIncome.ToString("C", new CultureInfo("de-DE"));
                }
                catch(Exception ex) {
                    MessageBox.Show("Error updating waiter income: " + ex.Message);
                }
            }
            else {
                textBox4.Text = "0,00 €";  // Format as euro with German culture
            }
        }

        // Get statistics for a specific date
        public (decimal totalIncome, int completedOrders, int delayedOrders) GetStatsForDate(DateTime date) {
            decimal totalIncome = 0;
            int completedOrders = 0;
            int delayedOrders = 0;

            using(SqlConnection connection = new SqlConnection(handler.connString)) {
                try {
                    connection.Open();

                    // Get total income for the specified date
                    string incomeQuery = @"
                SELECT SUM(m.price) AS TotalIncome
                FROM orders o
                JOIN order_items oi ON o.order_id = oi.order_id
                JOIN menu m ON oi.item_id = m.item_id
                WHERE CONVERT(date, o.time) = CONVERT(date, @selectedDate)";

                    using(SqlCommand command = new SqlCommand(incomeQuery, connection)) {
                        command.Parameters.AddWithValue("@selectedDate", date);
                        object result = command.ExecuteScalar();
                        if(result != null && result != DBNull.Value) {
                            totalIncome = Convert.ToDecimal(result);
                        }
                    }

                    // Get completed orders count for the specified date
                    string completedQuery = @"
                SELECT COUNT(*) AS CompletedOrders
                FROM orders
                WHERE status = 'completed'
                AND CONVERT(date, time) = CONVERT(date, @selectedDate)";

                    using(SqlCommand command = new SqlCommand(completedQuery, connection)) {
                        command.Parameters.AddWithValue("@selectedDate", date);
                        object result = command.ExecuteScalar();
                        if(result != null && result != DBNull.Value) {
                            completedOrders = Convert.ToInt32(result);
                        }
                    }

                    // Get delayed orders count for the specified date
                    string delayedQuery = @"
                SELECT COUNT(*) AS DelayedOrders
                FROM orders
                WHERE status = 'completed'
                AND DATEDIFF(minute, time, DATEADD(HOUR, -3, GETDATE())) > 30
                AND CONVERT(date, time) = CONVERT(date, @selectedDate)";

                    using(SqlCommand command = new SqlCommand(delayedQuery, connection)) {
                        command.Parameters.AddWithValue("@selectedDate", date);
                        object result = command.ExecuteScalar();
                        if(result != null && result != DBNull.Value) {
                            delayedOrders = Convert.ToInt32(result);
                        }
                    }
                }
                catch(Exception ex) {
                    throw new Exception("Error fetching statistics for the selected date: " + ex.Message);
                }
            }

            return (totalIncome, completedOrders, delayedOrders);
        }

        // Get waiter income for a specific date
        public decimal GetWaiterIncomeForDate(int waiterId, DateTime date) {
            decimal waiterIncome = 0;

            using(SqlConnection connection = new SqlConnection(handler.connString)) {
                try {
                    connection.Open();

                    string query = @"
                SELECT COALESCE(SUM(m.price), 0) AS WaiterIncome
                FROM orders o
                JOIN tables t ON o.table_nr = t.table_nr
                JOIN order_items oi ON o.order_id = oi.order_id
                JOIN menu m ON oi.item_id = m.item_id
                WHERE t.user_id = @waiterId
                AND CONVERT(date, o.time) = CONVERT(date, @selectedDate)";

                    using(SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@waiterId", waiterId);
                        command.Parameters.AddWithValue("@selectedDate", date);
                        object result = command.ExecuteScalar();

                        if(result != null && result != DBNull.Value) {
                            waiterIncome = Convert.ToDecimal(result);
                        }
                    }
                }
                catch(Exception ex) {
                    throw new Exception("Error fetching waiter income for the selected date: " + ex.Message);
                }
            }

            return waiterIncome;
        }

        // Add a refresh button handler 
        private void refreshButton_Click(object sender, EventArgs e) {
            RefreshStatistics();
        }

        private void button1_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 1;
        }
        private void backButton1_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 0;
        }

        private void backButton2_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 2;
        }

        private void saveUsersButton_Click_1(object sender, EventArgs e) {
            try {
                // Configure the SqlDataAdapter with commands
                SqlCommandBuilder usersCommandBuilder = new SqlCommandBuilder(handler.users_ad);

                // Update the database
                handler.users_ad.Update(users_ds, "users");
                MessageBox.Show("Changes saved successfully!");
            }
            catch(Exception ex) {
                MessageBox.Show("Error saving changes: " + ex.Message);
            }
        }

        private void deleteUsersButton_Click(object sender, EventArgs e) {
            if(dataGridView2.CurrentRow != null) {
                try {
                    // Confirm deletion
                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete this user?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if(result == DialogResult.Yes) {
                        // Mark row for deletion
                        dataGridView2.CurrentRow.Selected = true;
                        DataRowView rowView = (DataRowView)dataGridView2.CurrentRow.DataBoundItem;
                        rowView.Row.Delete();

                        // Update the database
                        SqlCommandBuilder usersCommandBuilder = new SqlCommandBuilder(handler.users_ad);
                        handler.users_ad.Update(users_ds, "users");

                        MessageBox.Show("User deleted successfully!");
                    }
                }
                catch(Exception ex) {
                    MessageBox.Show("Error deleting user: " + ex.Message);
                }
            }
            else {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        private void deleteMenuButton_Click(object sender, EventArgs e) {
            if(dataGridView1.CurrentRow != null) {
                try {
                    // Confirm deletion
                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete this menu item?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if(result == DialogResult.Yes) {
                        // Mark row for deletion
                        dataGridView1.CurrentRow.Selected = true;
                        DataRowView rowView = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                        rowView.Row.Delete();

                        // Update the database
                        SqlCommandBuilder menuCommandBuilder = new SqlCommandBuilder(handler.menu_ad);
                        handler.menu_ad.Update(menu_ds, "menu");

                        MessageBox.Show("Menu item deleted successfully!");
                    }
                }
                catch(Exception ex) {
                    MessageBox.Show("Error deleting menu item: " + ex.Message);
                }
            }
            else {
                MessageBox.Show("Please select a menu item to delete.");
            }
        }

        private void saveMenuButton_Click_1(object sender, EventArgs e) {
            try {
                // Commit any pending edits in the DataGridView
                dataGridView1.EndEdit();

                // Validate for negative prices and duplicate names before saving
                var menuTable = menu_ds.Tables["menu"];
                HashSet<string> names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                foreach(DataRow row in menuTable.Rows) {
                    // Skip deleted rows
                    if(row.RowState == DataRowState.Deleted)
                        continue;

                    // Check for negative price
                    if(row.Table.Columns.Contains("price")) {
                        if(row["price"] != DBNull.Value && decimal.TryParse(row["price"].ToString(), out decimal price)) {
                            if(price < 0) {
                                MessageBox.Show("Negative prices are not allowed. Please correct the menu item(s) with negative prices.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Check for duplicate names
                    if(row.Table.Columns.Contains("name")) {
                        string name = row["name"]?.ToString().Trim();
                        if(!string.IsNullOrEmpty(name)) {
                            if(names.Contains(name)) {
                                MessageBox.Show($"Duplicate menu item name found: '{name}'. Please ensure all menu item names are unique.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            names.Add(name);
                        }
                    }
                }

                // Configure the SqlDataAdapter with the INSERT, UPDATE, and DELETE commands
                SqlCommandBuilder menuCommandBuilder = new SqlCommandBuilder(handler.menu_ad);

                // Update the database with changes from the DataSet
                handler.menu_ad.Update(menu_ds, "menu");
                MessageBox.Show("Menu changes saved successfully!");
                MenuStatusManager.NotifyMenuStatusChanged();
            }
            catch(Exception ex) {
                MessageBox.Show("Error saving changes: " + ex.Message);
            }
        }




        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e) {
            UpdateWaiterIncome();
        }


        private void openCalendarButton_Click(object sender, EventArgs e) {
            calendar.Visible = !calendar.Visible;
            if(calendar.Visible) {
                calendar.BringToFront();
                this.ActiveControl = calendar;
            }
        }

<<<<<<< HEAD
        private void refresh_Button_Click(object sender, EventArgs e) {
            try {
                // Re-fill the menu dataset from the database
                menu_ds.Clear();
                handler.menu_ad.Fill(menu_ds, "menu");

                // Rebind the DataGridView to ensure it shows the latest data
                dataGridView1.DataSource = menu_ds.Tables["menu"];
                MessageBox.Show("Menu refreshed!");
            }
            catch(Exception ex) {
                MessageBox.Show("Error refreshing menu: " + ex.Message);
            }
        }

        private void refresh_Button2_Click(object sender, EventArgs e) {
            try {
                // Re-fill the users dataset from the database
                users_ds.Clear();
                handler.users_ad.Fill(users_ds, "users");

                // Rebind the DataGridView to ensure it shows the latest data
                dataGridView2.DataSource = users_ds.Tables["users"];
                MessageBox.Show("Users refreshed!");
            }
            catch(Exception ex) {
                MessageBox.Show("Error refreshing users: " + ex.Message);
            }
        }
=======
        private void AdminPage_Load(object sender, EventArgs e)
        {
>>>>>>> 68f2dd8543824669b66018bd8feeff35fb709dff

        }

      
    }
}
