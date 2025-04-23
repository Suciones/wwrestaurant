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
        SqlConnection myCon = new SqlConnection();

        DataSet tablenr = new DataSet();

        private enum TableStatus { Free, Reserved, Occupied }

        private TableStatus[] tableStatuses = new TableStatus[9]; // 9 tables

        private Panel[] indicatorPanels = new Panel[9];

        private string mode;

        private int? lastSelectedIndex = null;
        private void Start_Page_Load(object sender, EventArgs e)
        {

        }
        public Start_Page()
        {
           
            InitializeComponent();
            //this.mode = mode;
            //if (mode == "order")
            //{
            //    this.Text = "Start Order - Select Table";
            //    lblPrompt.Text = "Choose your table:";
            //}
            //else if (mode == "reserve")
            //{
            //    this.Text = "Reserve Table - Select Table";
            //    lblPrompt.Text = "Reserve a table:";
            //}
            for (int i = 0; i < tableStatuses.Length; i++)
            {
                tableStatuses[i] = TableStatus.Free;
            }
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
                tableStatuses[i] = TableStatus.Free;
                indicatorPanels[i].BackColor = Color.Green;

                // Optional: make circle-shaped using Paint
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0, 0, indicatorPanels[i].Width, indicatorPanels[i].Height);
                indicatorPanels[i].Region = new Region(gp);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {

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

            // Reset table status and indicator color
            tableStatuses[index] = TableStatus.Free;
            indicatorPanels[index].BackColor = Color.Green;

            // Clear reference and message
            lastSelectedIndex = null;
            lblMessage.Text = "Choice cleared!";
            lblMessage.ForeColor = Color.Green;
        }

        private void btnStartOrder_Click(object sender, EventArgs e)
        { // aici se creaza o cocmanda noua care va avea order_id si table_id
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
                lastSelectedIndex = index;
                
                    tableStatuses[index] = TableStatus.Occupied;
                    indicatorPanels[index].BackColor = Color.Red;
                    lblMessage.Text = "Table chosen!";
                    lblMessage.ForeColor = Color.Green;
            }
            else if (tableStatuses[index] == TableStatus.Reserved)
            {
                lblMessage.Text = "Table reserved! Please choose another table!";
                lblMessage.ForeColor = Color.Red;
            }
            else if (tableStatuses[index] == TableStatus.Occupied)
            {
                lblMessage.Text = "Wrong Table!";
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
                lastSelectedIndex = index;

                tableStatuses[index] = TableStatus.Reserved;
                indicatorPanels[index].BackColor = Color.Yellow;
                lblMessage.Text = "Table reserved!";
                lblMessage.ForeColor = Color.Green;
            }
            else if (tableStatuses[index] == TableStatus.Reserved)
            {
                lblMessage.Text = "Table reserved! Please choose another table!";
                lblMessage.ForeColor = Color.Red;
            }
            else if (tableStatuses[index] == TableStatus.Occupied)
            {
                lblMessage.Text = "Wrong Table!";
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}
