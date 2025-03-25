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
    public partial class Menu : Form
    {
        public Menu()
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
            
            menu_panel.Dock = DockStyle.Top;
            Panel panel_scroll = new Panel();
            panel_scroll.Controls.Add(panel_item1);
            panel_scroll.Controls.Add(panel_item2);
            panel_scroll.Controls.Add(panel_item3);
            panel_scroll.Controls.Add(panel_item4);
            panel_scroll.Dock = DockStyle.Fill;
            panel_scroll.AutoScroll = true;




        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
