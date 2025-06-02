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
    public partial class PayForm : Form
    {
        private List<OrderItem> order;
        private decimal baseTotal;
        private dbHandler db;

        private Image cardFront, cardBack;
        private bool showingBack = false;

        private Form orderFormReference;
        private int tableNr;
        private string waiterName;

        public PayForm(List<OrderItem> orderItems, int tableNr, string waiterName, Form orderForm = null)
        {
            InitializeComponent();

            this.order = orderItems;
            this.tableNr = tableNr;
            this.waiterName = waiterName;
            this.orderFormReference = orderForm;

            baseTotal = order.Sum(i => i.Total);

            txtTable.Text = tableNr.ToString();
            txtWaiter.Text = waiterName;
            lblTotal.Text = $"Base Total: {baseTotal:C}";
            lblFinalTotal.Text = $"Total with Tip: {baseTotal:C}";

            cmbTip.SelectedIndex = 0;

            AppStyle.ApplyFormStyle(this);


        }


        private void PayForm_Load(object sender, EventArgs e)
        {
            cardFront = Image.FromFile("Resources/card_front.png");
            cardBack = Image.FromFile("Resources/card_back.png");

            picCard.Image = cardFront;
            txtCVV.Visible = false;
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTip = cmbTip.SelectedItem.ToString().Replace("%", "");
            int tipPercent = int.TryParse(selectedTip, out int percent) ? percent : 0;

            decimal tipAmount = baseTotal * tipPercent / 100m;
            decimal finalTotal = baseTotal + tipAmount;

            lblFinalTotal.Text = $"Total with Tip: {finalTotal:C}";
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {

            if (!showingBack)
            {
                // Show back
                picCard.Image = cardBack;
                txtCardNumber.Visible = false;
                txtCardName.Visible = false;
                txtExpiry.Visible = false;
                txtCVV.Visible = true;
                showingBack = true;
            }
            else
            {
                // Show front again
                picCard.Image = cardFront;
                txtCardNumber.Visible = true;
                txtCardName.Visible = true;
                txtExpiry.Visible = true;
                txtCVV.Visible = false;
                showingBack = false;
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            // Validate fields
            if (string.IsNullOrWhiteSpace(txtCardNumber.Text) ||
                string.IsNullOrWhiteSpace(txtCardName.Text) ||
                string.IsNullOrWhiteSpace(txtExpiry.Text) ||
                string.IsNullOrWhiteSpace(txtCVV.Text))
            {
                MessageBox.Show("Please complete all card fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblStatus.Text = "Payment Successful!";
            lblStatus.ForeColor = Color.ForestGreen;

            // Close forms after short delay
            Timer closeTimer = new Timer();
            closeTimer.Interval = 1000;
            closeTimer.Tick += (s, ev) =>
            {
                closeTimer.Stop();
                this.Close();
                orderFormReference?.Close();
            };
            closeTimer.Start();
        }
    }

}



