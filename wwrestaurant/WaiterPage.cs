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
    public partial class WaiterPage : Form
    {
        public WaiterPage()
        {
            InitializeComponent();
            OrdersList.Items.Clear();
            //dbHandler dbHandler = new dbHandler();
        }

        private void OrdersList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
