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
    public partial class Form1_menu_table : Form
    {
        public Form1_menu_table()
        {
            InitializeComponent();
        }

        private void Form1_menu_table_Load(object sender, EventArgs e)
        {

        }

        private void btnStartOrder_Click(object sender, EventArgs e)
        {
            Form2_tables form2_tables = new Form2_tables("order");
            form2_tables.ShowDialog();
        }

        private void btnReserveTable_Click(object sender, EventArgs e)
        {
            Form2_tables form2_tables = new Form2_tables("reserve");
            form2_tables.ShowDialog();
        }
    }
}
