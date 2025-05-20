namespace wwrestaurant
{
    partial class PayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTable = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.lblWaiter = new System.Windows.Forms.Label();
            this.txtWaiter = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTipLabel = new System.Windows.Forms.Label();
            this.cmbTip = new System.Windows.Forms.ComboBox();
            this.lblFinalTotal = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.picCard = new System.Windows.Forms.PictureBox();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.txtCardName = new System.Windows.Forms.TextBox();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.flipTimer = new System.Windows.Forms.Timer(this.components);
            this.btnFlip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCard)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.Location = new System.Drawing.Point(43, 73);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(99, 27);
            this.lblTable.TabIndex = 0;
            this.lblTable.Text = "Table # :";
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(157, 74);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(97, 22);
            this.txtTable.TabIndex = 1;
            // 
            // lblWaiter
            // 
            this.lblWaiter.AutoSize = true;
            this.lblWaiter.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiter.Location = new System.Drawing.Point(45, 139);
            this.lblWaiter.Name = "lblWaiter";
            this.lblWaiter.Size = new System.Drawing.Size(86, 27);
            this.lblWaiter.TabIndex = 2;
            this.lblWaiter.Text = "Waiter:";
            // 
            // txtWaiter
            // 
            this.txtWaiter.Location = new System.Drawing.Point(157, 139);
            this.txtWaiter.Name = "txtWaiter";
            this.txtWaiter.ReadOnly = true;
            this.txtWaiter.Size = new System.Drawing.Size(97, 22);
            this.txtWaiter.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(45, 205);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(76, 27);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total :";
            // 
            // lblTipLabel
            // 
            this.lblTipLabel.AutoSize = true;
            this.lblTipLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipLabel.Location = new System.Drawing.Point(43, 266);
            this.lblTipLabel.Name = "lblTipLabel";
            this.lblTipLabel.Size = new System.Drawing.Size(133, 27);
            this.lblTipLabel.TabIndex = 5;
            this.lblTipLabel.Text = "Add TIP(%):";
            // 
            // cmbTip
            // 
            this.cmbTip.FormattingEnabled = true;
            this.cmbTip.Items.AddRange(new object[] {
            "NO TIP",
            "10%",
            "15%",
            "20%"});
            this.cmbTip.Location = new System.Drawing.Point(182, 271);
            this.cmbTip.Name = "cmbTip";
            this.cmbTip.Size = new System.Drawing.Size(358, 24);
            this.cmbTip.TabIndex = 6;
            this.cmbTip.SelectedIndexChanged += new System.EventHandler(this.cmbTip_SelectedIndexChanged);
            // 
            // lblFinalTotal
            // 
            this.lblFinalTotal.AutoSize = true;
            this.lblFinalTotal.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalTotal.Location = new System.Drawing.Point(43, 333);
            this.lblFinalTotal.Name = "lblFinalTotal";
            this.lblFinalTotal.Size = new System.Drawing.Size(159, 27);
            this.lblFinalTotal.TabIndex = 7;
            this.lblFinalTotal.Text = "Total with TIP:";
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(378, 829);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(208, 197);
            this.btnPay.TabIndex = 8;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // picCard
            // 
            this.picCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.picCard.Location = new System.Drawing.Point(200, 426);
            this.picCard.Name = "picCard";
            this.picCard.Size = new System.Drawing.Size(561, 359);
            this.picCard.TabIndex = 9;
            this.picCard.TabStop = false;
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNumber.Location = new System.Drawing.Point(214, 561);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(341, 34);
            this.txtCardNumber.TabIndex = 10;
            // 
            // txtCardName
            // 
            this.txtCardName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardName.Location = new System.Drawing.Point(214, 708);
            this.txtCardName.Name = "txtCardName";
            this.txtCardName.Size = new System.Drawing.Size(281, 34);
            this.txtCardName.TabIndex = 11;
            // 
            // txtExpiry
            // 
            this.txtExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpiry.Location = new System.Drawing.Point(586, 708);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.Size = new System.Drawing.Size(144, 34);
            this.txtExpiry.TabIndex = 12;
            // 
            // txtCVV
            // 
            this.txtCVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCVV.Location = new System.Drawing.Point(609, 561);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.Size = new System.Drawing.Size(121, 34);
            this.txtCVV.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(227, 363);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 14;
            // 
            // flipTimer
            // 
            this.flipTimer.Interval = 50;
            // 
            // btnFlip
            // 
            this.btnFlip.Location = new System.Drawing.Point(41, 489);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(100, 60);
            this.btnFlip.TabIndex = 15;
            this.btnFlip.Text = "FLIP CARD";
            this.btnFlip.UseVisualStyleBackColor = true;
            this.btnFlip.Click += new System.EventHandler(this.btnFlip_Click);
            // 
            // PayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(943, 776);
            this.Controls.Add(this.btnFlip);
            this.Controls.Add(this.txtCVV);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtExpiry);
            this.Controls.Add(this.txtCardName);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.picCard);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblFinalTotal);
            this.Controls.Add(this.cmbTip);
            this.Controls.Add(this.lblTipLabel);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtWaiter);
            this.Controls.Add(this.lblWaiter);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.lblTable);
            this.Name = "PayForm";
            this.Text = "PayForm";
            this.Load += new System.EventHandler(this.PayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.Label lblWaiter;
        private System.Windows.Forms.TextBox txtWaiter;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTipLabel;
        private System.Windows.Forms.ComboBox cmbTip;
        private System.Windows.Forms.Label lblFinalTotal;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.PictureBox picCard;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtCardName;
        private System.Windows.Forms.TextBox txtExpiry;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer flipTimer;
        private System.Windows.Forms.Button btnFlip;
    }
}