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
    public partial class Form1_manager : Form
    {
        private DataTable tableStatusTable;
        private void Form1_manager_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            LoadTableData();

        }
        private void InitializeTableStatusTable()
        {
            tableStatusTable = new DataTable();
            tableStatusTable.Columns.Add("Table Number", typeof(int));
            tableStatusTable.Columns.Add("Status", typeof(string));
            tableStatusTable.Columns.Add("Action", typeof(string)); // dummy column to match grid

            dgvTables.DataSource = tableStatusTable;

            // Add a real action button column
            if (!dgvTables.Columns.Contains("ChangeStatus"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "Action";
                btn.Name = "ChangeStatus";
                btn.Text = "Change";
                btn.UseColumnTextForButtonValue = true;
                dgvTables.Columns.Add(btn);
                dgvTables.CellClick += dgvTables_CellContentClick;// DgvTables_CellClick;
            }
        }
        private void LoadTableData()
        {
            tableStatusTable.Clear();

            for (int i = 1; i <= 9; i++)
            {
                // Initial status - can be updated from DB or memory
                tableStatusTable.Rows.Add(i, "Free", "Change");
            }

            lblTotalOrders.Text = "Total Orders: 128"; // Example values
            lblTotalIncome.Text = "Total Income: $1,580.50";

        }
        private string GetNextStatus(string current)
        {
            switch (current)
            {
                case "Free": return "Reserved";
                case "Reserved": return "Occupied";
                case "Occupied": return "Free";
                default: return "Free";
            }
        }
        

            private void lblTitle_Click(object sender, EventArgs e)
            {

            }

            private void dgvTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgvTables.Columns["ChangeStatus"].Index)
                {
                    int tableNum = Convert.ToInt32(dgvTables.Rows[e.RowIndex].Cells[0].Value);
                    string currentStatus = dgvTables.Rows[e.RowIndex].Cells[1].Value.ToString();

                    string newStatus = GetNextStatus(currentStatus);

                    dgvTables.Rows[e.RowIndex].Cells[1].Value = newStatus;

                    MessageBox.Show($"Table {tableNum} status changed to {newStatus}", "Status Updated");
                }

            }

            private void btnRefresh_Click(object sender, EventArgs e)
            {
            LoadTableData();
        }
        }
   }

