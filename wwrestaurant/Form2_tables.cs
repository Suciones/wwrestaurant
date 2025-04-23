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
    public partial class Form2_tables : Form
    {
        SqlConnection myCon = new SqlConnection();

        DataSet tablenr = new DataSet();

        private enum TableStatus { Free, Reserved, Occupied }

        private TableStatus[] tableStatuses = new TableStatus[9]; // 9 tables

        private Panel[] indicatorPanels = new Panel[9];

        private string mode;

        private int? lastSelectedIndex = null;

        

        public Form2_tables(string mode)
        {
            InitializeComponent();
            this.mode = mode;
            if (mode == "order")
            {
                this.Text = "Start Order - Select Table";
                lblPrompt.Text = "Choose your table:";
            }
            else if (mode == "reserve")
            {
                this.Text = "Reserve Table - Select Table";
                lblPrompt.Text = "Reserve a table:";
            }
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

        private void Form2_tables_Load(object sender, EventArgs e)
        {

        }
        private void UpdateIndicators()
        {
            for (int i = 0; i < tableStatuses.Length; i++)
            {
                switch (tableStatuses[i])
                {
                    case TableStatus.Free:
                        indicatorPanels[i].BackColor = Color.Green;
                        break;
                    case TableStatus.Reserved:
                        indicatorPanels[i].BackColor = Color.Yellow;
                        break;
                    case TableStatus.Occupied:
                        indicatorPanels[i].BackColor = Color.Red;
                        break;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // "Table Availability"
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Legend
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // colors
        }

        private void panel11_background_Paint(object sender, PaintEventArgs e)
        {
            //background panel Dock:Fill
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            // big panel
        }

        private void TABLE1_LABEL_Click(object sender, EventArgs e)
        {
            //TABLE 1
        }

        private void TABLE1_LABEL2_Click(object sender, EventArgs e)
        {
            // TABLE 1
            //Seats:10
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTable_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPrompt_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
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
                if (mode == "order")
                {
                    tableStatuses[index] = TableStatus.Occupied;
                    indicatorPanels[index].BackColor = Color.Red;
                    lblMessage.Text = "Table chosen!";
                }
                else
                {
                    tableStatuses[index] = TableStatus.Reserved;
                    indicatorPanels[index].BackColor = Color.Yellow;
                    lblMessage.Text = "Table reserved!";
                }

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

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnClearChoice_Click(object sender, EventArgs e)
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
    }
}
