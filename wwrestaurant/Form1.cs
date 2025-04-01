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
    public partial class Form1 : Form
    {
        public Form1()
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
            this.ActiveControl = username;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            username.Focus();
        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (username.Text.Equals("admin") && password.Text.Equals("admin"))
            {
                this.Hide();
                Menu menuform = new Menu();
                menuform.ShowDialog();
            }
            else
            {
                errorlabel.Text = "Incorrect username or password";
            }
                
        }

        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorlabel.Text = "";
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorlabel.Text = "";
        }

        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Move focus to textBox2
                password.Focus();

                // Mark the event as handled to prevent the "ding" sound
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Move focus to textBox2
                login_button_Click(this, new EventArgs());

                // Mark the event as handled to prevent the "ding" sound
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
