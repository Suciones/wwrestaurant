using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wwrestaurant
{
    public partial class OrderForm : Form
    {

        public DataSet menu_ds = new DataSet();
        public DataSet order_items_ds = new DataSet();
        public DataSet orders_ds = new DataSet();
        public DataSet tables_ds = new DataSet();

        private List<OrderItem> currentOrder;
        private int selectedTable;
        private dbHandler db;


        private Panel orderStatusPanel;
        private Label lblOrderStatus;
        private Timer fadeTimer;
        private float opacityIncrement = 0.1f;

        private Timer statusUpdateTimer;
        private int latestOrderId;


        public OrderForm(List<OrderItem> orderList, int tableNr, dbHandler dbHandler)
        {
            InitializeComponent();

            currentOrder = orderList;
            selectedTable = tableNr;
            db = dbHandler;

            this.StartPosition = FormStartPosition.Manual;
            this.Left = Screen.PrimaryScreen.WorkingArea.Left + 20; // float on left
            this.Top = Screen.PrimaryScreen.WorkingArea.Top + 100;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            RefreshGrid();
            SetupOrderStatusPanel();

            // Optional: auto-size columns
            dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupGrid()
        {
            dgvOrderItems.Columns.Clear();
            dgvOrderItems.Columns.Add("Name", "Item");
            dgvOrderItems.Columns.Add("Quantity", "Qty");

            var plusCol = new DataGridViewButtonColumn { Name = "Plus", Text = "+", UseColumnTextForButtonValue = true };
            var minusCol = new DataGridViewButtonColumn { Name = "Minus", Text = "-", UseColumnTextForButtonValue = true };
            dgvOrderItems.Columns.Add(plusCol);
            dgvOrderItems.Columns.Add(minusCol);

            dgvOrderItems.AllowUserToAddRows = false;
        }

        public void RefreshGrid()
        {
            dgvOrderItems.Rows.Clear();
            foreach (var item in currentOrder)
            {
                dgvOrderItems.Rows.Add(item.Name, item.Quantity);
            }
        }

        private void dgvOrderItems_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var item = currentOrder[e.RowIndex];

            if (dgvOrderItems.Columns[e.ColumnIndex].Name == "Plus") item.Quantity++;
            else if (dgvOrderItems.Columns[e.ColumnIndex].Name == "Minus") item.Quantity--;

            if (item.Quantity <= 0) currentOrder.Remove(item);
           
            RefreshGrid();
        }


        private void SetupOrderStatusPanel()
        {
            orderStatusPanel = new Panel();
            orderStatusPanel.Size = new Size(this.ClientSize.Width, 50);
            orderStatusPanel.Location = new Point(0, 10);
            orderStatusPanel.BackColor = Color.Transparent;
            orderStatusPanel.Visible = false;

            lblOrderStatus = new Label();
            lblOrderStatus.AutoSize = false;
            lblOrderStatus.Dock = DockStyle.Fill;
            lblOrderStatus.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblOrderStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblOrderStatus.ForeColor = Color.Black;
            lblOrderStatus.Text = "";

            orderStatusPanel.Controls.Add(lblOrderStatus);
            this.Controls.Add(orderStatusPanel);
            orderStatusPanel.BringToFront();

            // Set up fade-in animation
            fadeTimer = new Timer();
            fadeTimer.Interval = 50; // milliseconds
            fadeTimer.Tick += (s, e) =>
            {
                if (orderStatusPanel.BackColor.A < 255)
                {
                    int newAlpha = Math.Min(orderStatusPanel.BackColor.A + (int)(255 * opacityIncrement), 255);
                    orderStatusPanel.BackColor = Color.FromArgb(newAlpha, orderStatusPanel.BackColor);
                    lblOrderStatus.ForeColor = Color.FromArgb(newAlpha, lblOrderStatus.ForeColor);
                }
                else
                {
                    fadeTimer.Stop();
                }
            };
        }

        private void UpdateOrderStatusLabel()
        {
            string status = db.GetOrderStatus(latestOrderId);
            lblOrderStatus.Text = $"Order Status: {status}";

            switch (status)
            {
                case "In Progress":
                    lblOrderStatus.ForeColor = Color.DarkOrange;
                    orderStatusPanel.BackColor = Color.FromArgb(255, 255, 204); // solid yellow
                    break;
                case "Ready to Serve":
                case "Finished":
                case "Served":
                    lblOrderStatus.ForeColor = Color.ForestGreen;
                    orderStatusPanel.BackColor = Color.FromArgb(204, 255, 204); // solid green
                    break;
                default:
                    lblOrderStatus.ForeColor = Color.Gray;
                    orderStatusPanel.BackColor = Color.FromArgb(200, 200, 200); // gray
                    break;
            }

            orderStatusPanel.Visible = true;
            orderStatusPanel.BringToFront();
        }
        private void StartStatusPolling()
        {
            if (statusUpdateTimer != null)
            {
                statusUpdateTimer.Stop();
                statusUpdateTimer.Dispose();
            }

            statusUpdateTimer = new Timer();
            statusUpdateTimer.Interval = 3000; // 3 seconds
            statusUpdateTimer.Tick += (s, e) =>
            {
                try
                {
                    UpdateOrderStatusLabel();
                }
                catch (Exception ex)
                {
                    statusUpdateTimer.Stop();
                    MessageBox.Show("Error updating order status: " + ex.Message);
                }
            };

            statusUpdateTimer.Start();
        }

        private void btnFinishOrder_Click_1(object sender, EventArgs e) /// SEND ORDER
        {
            if (currentOrder.Count == 0)
            {
                MessageBox.Show("No items in the order.");
                return;
            }

            try
            {
                db.createOrder2(selectedTable, currentOrder);

                db.RefreshDataset(db.orders_ds, db.orders_ad, "orders");
                db.RefreshDataset(db.order_items_ds, db.order_items_ad, "order_items");
                db.RefreshDataset(db.tables_ds, db.tables_ad, "tables");

                MessageBox.Show("Order saved successfully!");
                dgvOrderItems.Visible = false;
                btnFinishOrder.Visible = false;

                // Get latest order ID for this table
                latestOrderId = db.orders_ds.Tables["orders"]
                    .AsEnumerable()
                    .Where(row => row.Field<int>("table_nr") == selectedTable)
                    .OrderByDescending(row => row.Field<DateTime>("time"))
                    .Select(row => row.Field<int>("order_id"))
                    .FirstOrDefault();

                // Display status immediately
                UpdateOrderStatusLabel();

                // Start the timer to poll status every 3 seconds
                StartStatusPolling();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save order: " + ex.Message + "\n\n" + ex.StackTrace);
            }
        }



        private void btnCheck_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Get latest order ID
                int latestOrderId = db.orders_ds.Tables["orders"]
                    .AsEnumerable()
                    .Where(row => row.Field<int>("table_nr") == selectedTable)
                    .OrderByDescending(row => row.Field<DateTime>("time"))
                    .Select(row => row.Field<int>("order_id"))
                    .FirstOrDefault();

                string status = db.GetOrderStatus(latestOrderId);

                if (status != "Finished" && status != "Ready to Serve")
                {
                    MessageBox.Show("Order is not ready to be paid yet!");
                    return;
                }

                // Show the pay window
                PayForm payForm = new PayForm(currentOrder, selectedTable, "Waiter Name", this);
                payForm.ShowDialog();
                // ✅ Call handler to free the table
                db.SetTableFree(selectedTable);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
