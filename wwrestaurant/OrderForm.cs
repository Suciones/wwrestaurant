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

       

        private void btnFinishOrder_Click_1(object sender, EventArgs e)
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
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save order: " + ex.Message);
            }
        }

        private void btnCheck_Click_1(object sender, EventArgs e)
        {
            decimal total = currentOrder.Sum(i => i.Price * i.Quantity);
            MessageBox.Show($"Total: {total:C}");
        }
    }
}
