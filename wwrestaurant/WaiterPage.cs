using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace wwrestaurant
{
    public partial class WaiterPage : Form
    {
        dbHandler dbHandler;
        int waiterUserId;

        public WaiterPage(int userId)
        {
            InitializeComponent();
            this.waiterUserId = userId;

            dbHandler = new dbHandler(
                new DataSet(), new DataSet(), new DataSet(), new DataSet(), new DataSet()
            );

            LoadOrders();
        }

        private void LoadOrders()
        {
            OrdersList.Items.Clear();
            List<string> orders = dbHandler.GetOrdersByWaiter(waiterUserId);
            foreach (string order in orders)
            {
                ListViewItem item = new ListViewItem(order);
                OrdersList.Items.Add(item);
            }
        }

        private void OrdersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OrdersList.SelectedItems.Count > 0)
            {
                string selectedOrder = OrdersList.SelectedItems[0].Text;

                // Extract the order ID using regex
                Match match = Regex.Match(selectedOrder, @"Order ID: (\d+)");
                if (match.Success)
                {
                    int orderId = int.Parse(match.Groups[1].Value);

                    // Clear previous items
                    ItemsList.Items.Clear();

                    // Get items for this order
                    List<string> items = dbHandler.GetOrderItems(orderId);

                    // Display items
                    foreach (string item in items)
                    {
                        ListViewItem listItem = new ListViewItem(item);
                        ItemsList.Items.Add(listItem);
                    }
                    if(dbHandler.GetOrderStatus(orderId)=="uncompleted")
                    {
                        orderstatusbutton.BackColor = Color.Red;
                    }
                    if (dbHandler.GetOrderStatus(orderId) == "In progress")
                    {
                        orderstatusbutton.BackColor = Color.Yellow;
                    }
                    if (dbHandler.GetOrderStatus(orderId) == "completed")
                    {
                        orderstatusbutton.BackColor = Color.Green;
                    }

                    // Calculate and display total
                    decimal total = CalculateTotal(items);
                    TotalLabel.Text = $"Total: ${total:F2}";
                }
            }
        }

        private decimal CalculateTotal(List<string> items)
        {
            decimal total = 0;

            foreach (string item in items)
            {
                // Extract the total price for each item
                Match match = Regex.Match(item, @"= \$(\d+\.\d+)");
                if (match.Success)
                {
                    decimal itemTotal = decimal.Parse(match.Groups[1].Value);
                    total += itemTotal;
                }
            }

            return total;
        }

        private void WaiterPage_Load(object sender, EventArgs e)
        {
            // Optional: You can call LoadOrders() here instead of constructor
        }
    }
}