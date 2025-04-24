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
    { // nu i bun codul 
        
    
        SqlConnection myCon = new SqlConnection();
      
        DataSet tablenr = new DataSet();

        private enum TableStatus { Free, Reserved, Occupied }
        private TableStatus[] tableStatuses = new TableStatus[9]; // 9 tables

        private Panel[] indicatorPanels = new Panel[9];

       // private string mode;

        private int? lastSelectedIndex = null;
        private void Start_Page_Load(object sender, EventArgs e)
        {

        }

        
       // private dbHandler db = new dbHandler();
        private int selectedTableIndex = -1;  // -1 indicates no table selected (for example)

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

           
            //for (int i = 0; i < tableStatuses.Length; i++)
            //{
            //    tableStatuses[i] = TableStatus.Free;
            //}
            // Assign manually-created panels to the array
            indicatorPanels[0] = panel8; // 1 1
            indicatorPanels[1] = panel2; // 1 2
            indicatorPanels[2] = panel13; // 1 3
            indicatorPanels[3] = panel6; // 2 1 
            indicatorPanels[4] = panel10; // 2 2 
            indicatorPanels[5] = panel15; // 2 3
            indicatorPanels[6] = panel21; // 3 1
            indicatorPanels[7] = panel19; // 3 2
            indicatorPanels[8] = panel17; // 3 3 

            // Initialize all table statuses as FREE and set colors to green
            for (int i = 0; i < 9; i++)
            {
                //tableStatuses[i] = TableStatus.Free;
                indicatorPanels[i].BackColor = Color.Green;

                // Optional: make circle-shaped using Paint
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0, 0, indicatorPanels[i].Width, indicatorPanels[i].Height);
                indicatorPanels[i].Region = new Region(gp);
            }

        }


        private void panel_11_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnClearChoice_Click_1(object sender, EventArgs e)
        {
            if (lastSelectedIndex == null)
            {
                lblMessage.Text = "You haven't selected a table yet.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            int index = lastSelectedIndex.Value;
            int tableNum = index + 1;

            try
            {
               // db.ResetTableStatus(tableNum);

                tableStatuses[index] = TableStatus.Free;
                indicatorPanels[index].BackColor = Color.Green;

                lastSelectedIndex = null;
                lblMessage.Text = $"Table {tableNum} cleared!";
                lblMessage.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error clearing table: {ex.Message}";
                lblMessage.ForeColor = Color.Red;
            }
        }


        private void btnStartOrder_Click(object sender, EventArgs e)
        {
            int tableNum;
            if (!int.TryParse(txtTable.Text.Trim(), out tableNum) || tableNum < 1 || tableNum > 9)
            {
                lblMessage.Text = "Please enter a valid table number (1–9).";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            int index = tableNum - 1;

            if (tableStatuses[index] == TableStatus.Free || tableStatuses[index] == TableStatus.Reserved)
            {
                try
                {
                    // Example menu item list (replace this with actual selected item IDs from your UI logic)
                    List<int> selectedItemIds = new List<int> { 1, 2 }; // ← Replace with real selection

                    // Create the order with items
                  //  db.createOrder(tableNum, selectedItemIds);

                    // Update table status to 'occupied'
                   // db.UpdateTableStatus(tableNum, "occupied");

                    // Update UI
                    lastSelectedIndex = index;
                    tableStatuses[index] = TableStatus.Occupied;
                    indicatorPanels[index].BackColor = Color.Red;

                    lblMessage.Text = $"Order created for Table {tableNum}!";
                    lblMessage.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"Error creating order: {ex.Message}";
                    lblMessage.ForeColor = Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Table is already occupied!";
                lblMessage.ForeColor = Color.Red;
            }
        }



        private void btnReserveTable_Click(object sender, EventArgs e)
        {
            int tableNum;
            if (!int.TryParse(txtTable.Text.Trim(), out tableNum) || tableNum < 1 || tableNum > 9)
            {
                lblMessage.Text = "Please enter a valid table number (1–9).";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            int index = tableNum - 1;

            if (tableStatuses[index] == TableStatus.Free)
            {
                try
                {
                   // db.UpdateTableStatus(tableNum, "reserved");

                    lastSelectedIndex = index;
                    tableStatuses[index] = TableStatus.Reserved;
                    indicatorPanels[index].BackColor = Color.Yellow;

                    lblMessage.Text = $"Table {tableNum} reserved!";
                    lblMessage.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"Error reserving table: {ex.Message}";
                    lblMessage.ForeColor = Color.Red;
                }
            }
            else
            {
                lblMessage.Text = tableStatuses[index] == TableStatus.Reserved
                    ? "Table already reserved!"
                    : "Table is occupied!";
                lblMessage.ForeColor = Color.Red;
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 form1_login = new Form1();
            form1_login.ShowDialog();
        }
    }
}
