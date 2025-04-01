using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wwrestaurant
{
    public partial class Form_Manager : Form
    {
        private DataTable tableStatusTable;
        private Label lblTotalOrders;
        private Label lblTotalIncome;
        private DataGridView dgvTables;
        private Button btnRefresh;

        public Form_Manager()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Restaurant Manager Panel";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "Restaurant Manager Dashboard";
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            // Summary: Total Orders and Income
            lblTotalOrders = new Label
            {
                Text = "Total Orders: 128",
                Location = new Point(20, 60),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            lblTotalIncome = new Label
            {
                Text = "Total Income: $1,580.50",
                Location = new Point(200, 60),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            this.Controls.Add(lblTotalOrders);
            this.Controls.Add(lblTotalIncome);

            // DataGridView setup
            dgvTables = new DataGridView
            {
                Location = new Point(20, 100),
                Size = new Size(540, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            this.Controls.Add(dgvTables);

            // Refresh Button
            btnRefresh = new Button
            {
                Text = "Refresh",
                Location = new Point(20, 410),
                Size = new Size(100, 30)
            };
            btnRefresh.Click += (s, e) => LoadTableData();
            this.Controls.Add(btnRefresh);

            // Initialize Table
            InitializeTableStatusTable();
            LoadTableData();
        }

        private void InitializeTableStatusTable()
        {
            tableStatusTable = new DataTable();
            tableStatusTable.Columns.Add("Table Number", typeof(int));
            tableStatusTable.Columns.Add("Status", typeof(string));
            tableStatusTable.Columns.Add("Action", typeof(string));
        }

        private void LoadTableData()
        {
            tableStatusTable.Clear();

            for (int i = 1; i <= 9; i++)
            {
                // In real app, fetch real status from DB. For now, simulate:
                string status = GetRandomStatus(); // or use stored status
                tableStatusTable.Rows.Add(i, status, "Change");
            }

            dgvTables.DataSource = tableStatusTable;

            // Add Button Column if not already added
            if (!dgvTables.Columns.Contains("ChangeStatus"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn
                {
                    HeaderText = "Action",
                    Name = "ChangeStatus",
                    Text = "Change",
                    UseColumnTextForButtonValue = true
                };
                dgvTables.Columns.Add(btn);
                dgvTables.CellClick += DgvTables_CellClick;
            }
        }

        private void DgvTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvTables.Columns["ChangeStatus"].Index)
            {
                // Handle action button click
                int tableNumber = (int)dgvTables.Rows[e.RowIndex].Cells[0].Value;
                string currentStatus = dgvTables.Rows[e.RowIndex].Cells[1].Value.ToString();

                string newStatus = GetNextStatus(currentStatus);

                dgvTables.Rows[e.RowIndex].Cells[1].Value = newStatus;
                MessageBox.Show($"Table {tableNumber} is now {newStatus}.", "Status Changed");
            }
        }

        // Simulate rotating status: Free -> Reserved -> Occupied -> Free
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

        private string GetRandomStatus()
        {
            string[] statuses = { "Free", "Reserved", "Occupied" };
            Random rnd = new Random();
            return statuses[rnd.Next(statuses.Length)];
        }
    }
}
