using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wwrestaurant
{
    public partial class Start_Page : Form
    {
        public DataSet menu_ds = new DataSet();
        public DataSet order_items_ds = new DataSet();
        public DataSet orders_ds = new DataSet();
        public DataSet tables_ds = new DataSet();
        private dbHandler db;

        public List<OrderItem> currentOrder = new List<OrderItem>();
        public int selectedTable = -1;
        private OrderForm orderForm;

        private int[] tableSeats = new int[] { 2, 2, 4, 4, 6, 6, 8, 10, 10 };
        public Start_Page()
        {
            InitializeComponent();

            db = new dbHandler(menu_ds: menu_ds, order_items_ds: order_items_ds, tables_ds: tables_ds);

            db.menu_ad.Fill(menu_ds);

            // Subscribe to the table status changed event
            TableStatusManager.TableStatusChanged += TableStatusManager_TableStatusChanged;
            MenuStatusManager.MenuStatusChanged += MenuStatusManager_MenuStatusChanged;

            //style 

            AppStyle.ApplyFormStyle(this);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            
        }

        // Event handler for table status changes
        private void TableStatusManager_TableStatusChanged(object sender, EventArgs e)
        {
            // Use Invoke to ensure we're on the UI thread
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => LoadTables()));
            }
            else
            {
                LoadTables();
            }
        }
        private void MenuStatusManager_MenuStatusChanged(object sender, EventArgs e)
        {
            // Use Invoke to ensure we're on the UI thread
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => LoadMenu()));
            }
            else
            {
                LoadMenu();
            }
        }

        // Make sure to unsubscribe when the form is disposed


        private void Start_Page_Load_1(object sender, EventArgs e)
        {
            LoadTables();
            SetupMenuGrid();
            LoadMenu();
        }

        // Keep your existing LoadTables method
        public void LoadTables()
        {
            db.RefreshDataset(db.tables_ds, db.tables_ad, "tables");
            lstTables.Items.Clear();

            foreach (DataRow row in db.tables_ds.Tables["tables"].Rows)
            {
                if (row["status_table"].ToString() == "Free")
                {
                    int tableNr = (int)row["table_nr"];
                    int seats = tableSeats[tableNr - 1]; // -1 because table 1 is at index 0
                    lstTables.Items.Add(Convert.ToInt32(row["table_nr"]));
                }
            }
        }

        private void SetupMenuGrid()
        {
            
            dgvMenu.Columns.Clear();
            dgvMenu.Columns.Add("Name", "Item");
            dgvMenu.Columns.Add("Price", "Price");

            var imgCol = new DataGridViewImageColumn { Name = "Picture", HeaderText = "Image", ImageLayout = DataGridViewImageCellLayout.Zoom };
            dgvMenu.Columns.Add(imgCol);
            dgvMenu.Columns.Add("Quantity", "Qty");

            var btnCol = new DataGridViewButtonColumn
            {
                Name = "Add",
                HeaderText = "Action",
                Text = "Add to Order",
                UseColumnTextForButtonValue = true
            };
            dgvMenu.Columns.Add(btnCol);
            dgvMenu.RowTemplate.Height = 80;
            dgvMenu.AllowUserToAddRows = false;
        }

        private void LoadMenu()
        {
            db.RefreshDataset(db.menu_ds, db.menu_ad, "menu");
            dgvMenu.Rows.Clear();

            foreach (DataRow row in db.menu_ds.Tables["menu"].Rows)
            {
                int id = (int)row["item_id"];
                string name = row["name"].ToString();
                decimal price = (decimal)row["price"];
                string picPath = row["picture"].ToString();

                Image img;
                try { img = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, picPath)); }
                catch { img = new Bitmap(1, 1); }

                int rowIndex = dgvMenu.Rows.Add(name, price.ToString("C"), img, 1);
                dgvMenu.Rows[rowIndex].Tag = id; // Tag = item_id for tracking
            }
        }

     

       


        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            Form1 form1_login = new Form1();
            form1_login.ShowDialog();
        }

        private void lstTables_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (lstTables.SelectedItem != null)
            {
                selectedTable = (int)lstTables.SelectedItem;

                // Show confirmation message
                DialogResult result = MessageBox.Show(
                    "Open order for this table?","",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question

                );

                if (result == DialogResult.Yes)
                {
                    currentOrder.Clear();
                    orderForm?.Close();
                    orderForm = new OrderForm(currentOrder, selectedTable, db);
                    orderForm.Show();
                }

            }

        }

        private void dvgMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvMenu.Columns[e.ColumnIndex].Name == "Add")
            {
                var row = dgvMenu.Rows[e.RowIndex];
                int itemId = (int)row.Tag;
                string name = row.Cells["Name"].Value.ToString();
                decimal price = decimal.Parse(row.Cells["Price"].Value.ToString(), System.Globalization.NumberStyles.Currency);
                int qty = int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int q) ? q : 1;

                var existing = currentOrder.Find(i => i.ItemId == itemId);
                if (existing != null)
                    existing.Quantity += qty;
                else
                    currentOrder.Add(new OrderItem { ItemId = itemId, Name = name, Price = price, Quantity = qty });
                if (orderForm == null)
                {
                    MessageBox.Show("Please select a table first!");
                    return;
                }
                orderForm?.RefreshGrid();
            }
        }

      
    }

    public class OrderItem
    {
        public int ItemId { get; set; }       // From menu.item_id
        public string Name { get; set; }      // menu.name
        public decimal Price { get; set; }    // menu.price
        public int Quantity { get; set; }     // user input

        public decimal Total => Price * Quantity;
    }
}
