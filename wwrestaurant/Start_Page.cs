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

        private List<OrderItem> currentOrder = new List<OrderItem>();
        private int selectedTable = -1;
        private OrderForm orderForm;

       


        public Start_Page()
        {
           
            InitializeComponent();

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            db = new dbHandler(
          
         menu_ds: menu_ds,
         order_items_ds: order_items_ds,
         tables_ds: tables_ds
                 );
        }

        private void Start_Page_Load_1(object sender, EventArgs e)
        {
            LoadTables();
            SetupMenuGrid();
            LoadMenu();
        }

        private void LoadTables()
        {
            db.RefreshDataset(db.tables_ds, db.tables_ad, "tables");
            lstTables.Items.Clear();
            foreach (DataRow row in db.tables_ds.Tables["tables"].Rows)
            {
                if (row["status_table"].ToString() == "Free")
                    lstTables.Items.Add((int)row["table_nr"]);
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
                Image img = null;
                try { img = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, picPath)); }
                catch { img = new Bitmap(1, 1); }

                int r = dgvMenu.Rows.Add(name, price.ToString("C"), img, 1);
                dgvMenu.Rows[r].Tag = id;
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
                currentOrder.Clear();
                orderForm?.Close();
                orderForm = new OrderForm(currentOrder, selectedTable);
                orderForm.Show();
            }

        }

        private void dvgMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dgvMenu.Columns[e.ColumnIndex].Name == "Add")
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
