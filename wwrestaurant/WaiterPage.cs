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
        private Start_Page startPageReference;

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
                    if(dbHandler.GetOrderStatus(orderId)=="Finished")
                    {
                        completeorderbutton.Enabled = false;
                        orderstatusbutton.BackColor = Color.Red;
                    }
                    if (dbHandler.GetOrderStatus(orderId) == "In Progress")
                    {
                        completeorderbutton.Enabled = true;
                        orderstatusbutton.BackColor = Color.Yellow;
                    }
                    if (dbHandler.GetOrderStatus(orderId) == "completed")
                    {
                        completeorderbutton.Enabled = false;
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

        private void completeorderbutton_Click(object sender, EventArgs e)
        {
            if (OrdersList.SelectedItems.Count > 0)
            {
                string selectedOrder = OrdersList.SelectedItems[0].Text;
                Match match = Regex.Match(selectedOrder, @"Order ID: (\d+)");
                if (match.Success)
                {
                    int orderId = int.Parse(match.Groups[1].Value);

                    dbHandler.MarkOrderAsCompleted(orderId);

                    // Refresh orders list
                    LoadOrders();

                    // Clear previously shown details
                    ItemsList.Items.Clear();
                    TotalLabel.Text = "Total: $0.00";
                    orderstatusbutton.BackColor = SystemColors.Control; // Reset to default

                    MessageBox.Show("Order marked as completed!");
                }
                else
                {
                    MessageBox.Show("Could not extract order ID.");
                }
            }
            else
            {
                MessageBox.Show("Please select an order first.");
            }
        }

        private void finishorderbutton_Click(object sender, EventArgs e)
        {
            if (OrdersList.SelectedItems.Count > 0)
            {
                string selectedOrder = OrdersList.SelectedItems[0].Text;
                Match match = Regex.Match(selectedOrder, @"Order ID: (\d+)");
                if (!match.Success)
                {
                    MessageBox.Show("Invalid order selected.");
                    return;
                }

                int orderId = int.Parse(match.Groups[1].Value);
                string status = dbHandler.GetOrderStatus(orderId);

                if (status == "In progress" || status == "completed")
                {
                    // Simulate receipt popup
                    List<string> items = dbHandler.GetOrderItems(orderId);
                    decimal total = CalculateTotal(items);
                    string receiptText = string.Join("\n", items) + $"\n\nTotal: ${total:F2}";

                    MessageBox.Show(receiptText, "Receipt");

                    // Update order status
                    dbHandler.UpdateOrderStatus(orderId, "Finished");

                    // Free the table
                    dbHandler.SetTableFreeByOrderId(orderId);

                    // Refresh order list
                    LoadOrders();

                    // Notify all subscribers that table status has changed
                    // This will trigger the LoadTables method in Start_Page
                    TableStatusManager.NotifyTableStatusChanged();

                    ItemsList.Items.Clear();
                    TotalLabel.Text = "Total: $0.00";
                    orderstatusbutton.BackColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("This order is not ready to be finished.");
                }
            }
            else
            {
                MessageBox.Show("Please select an order.");
            }
        }


        private void removeitembutton_Click(object sender, EventArgs e)
        {
            if (OrdersList.SelectedItems.Count > 0 && ItemsList.SelectedItems.Count > 0)
            {
                string selectedOrder = OrdersList.SelectedItems[0].Text;
                Match orderMatch = Regex.Match(selectedOrder, @"Order ID: (\d+)");
                if (!orderMatch.Success)
                {
                    MessageBox.Show("Could not extract order ID.");
                    return;
                }

                int orderId = int.Parse(orderMatch.Groups[1].Value);

                string selectedItem = ItemsList.SelectedItems[0].Text;

                // Extract item name (before " x" part)
                string itemName = selectedItem.Split(new[] { " x" }, StringSplitOptions.None)[0].Trim();

                try
                {
                    int itemId = dbHandler.GetItemIdByName(itemName);
                    dbHandler.RemoveOneInstanceFromOrder(orderId, itemId);

                    // Reload UI
                    List<string> items = dbHandler.GetOrderItems(orderId);
                    ItemsList.Items.Clear();
                    foreach (string item in items)
                    {
                        ItemsList.Items.Add(new ListViewItem(item));
                    }

                    decimal total = CalculateTotal(items);
                    TotalLabel.Text = $"Total: ${total:F2}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select both an order and an item.");
            }
        }

    }
}