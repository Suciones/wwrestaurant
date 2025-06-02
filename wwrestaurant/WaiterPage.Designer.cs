namespace wwrestaurant
{
    partial class WaiterPage
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
            this.ItemsList = new System.Windows.Forms.ListView();
            this.OrdersList = new System.Windows.Forms.ListView();
            this.orderstatusbutton = new System.Windows.Forms.Button();
            this.completeorderbutton = new System.Windows.Forms.Button();
            this.totalprice = new System.Windows.Forms.Label();
            this.finishorderbutton = new System.Windows.Forms.Button();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.removeitembutton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemsList
            // 
            this.ItemsList.HideSelection = false;
            this.ItemsList.Location = new System.Drawing.Point(513, 12);
            this.ItemsList.Name = "ItemsList";
            this.ItemsList.Size = new System.Drawing.Size(274, 521);
            this.ItemsList.TabIndex = 0;
            this.ItemsList.UseCompatibleStateImageBehavior = false;
            // 
            // OrdersList
            // 
            this.OrdersList.HideSelection = false;
            this.OrdersList.Location = new System.Drawing.Point(12, 12);
            this.OrdersList.Name = "OrdersList";
            this.OrdersList.Size = new System.Drawing.Size(495, 521);
            this.OrdersList.TabIndex = 1;
            this.OrdersList.UseCompatibleStateImageBehavior = false;
            this.OrdersList.View = System.Windows.Forms.View.SmallIcon;
            this.OrdersList.SelectedIndexChanged += new System.EventHandler(this.OrdersList_SelectedIndexChanged);
            // 
            // orderstatusbutton
            // 
            this.orderstatusbutton.Enabled = false;
            this.orderstatusbutton.Font = new System.Drawing.Font("Sitka Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderstatusbutton.Location = new System.Drawing.Point(838, 197);
            this.orderstatusbutton.Name = "orderstatusbutton";
            this.orderstatusbutton.Size = new System.Drawing.Size(144, 52);
            this.orderstatusbutton.TabIndex = 2;
            this.orderstatusbutton.Text = "Order Status";
            this.orderstatusbutton.UseVisualStyleBackColor = true;
            // 
            // completeorderbutton
            // 
            this.completeorderbutton.Font = new System.Drawing.Font("Sitka Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeorderbutton.Location = new System.Drawing.Point(838, 262);
            this.completeorderbutton.Name = "completeorderbutton";
            this.completeorderbutton.Size = new System.Drawing.Size(144, 52);
            this.completeorderbutton.TabIndex = 3;
            this.completeorderbutton.Text = "Complete Order";
            this.completeorderbutton.UseVisualStyleBackColor = true;
            this.completeorderbutton.Click += new System.EventHandler(this.completeorderbutton_Click);
            // 
            // totalprice
            // 
            this.totalprice.AutoSize = true;
            this.totalprice.Location = new System.Drawing.Point(677, 291);
            this.totalprice.Name = "totalprice";
            this.totalprice.Size = new System.Drawing.Size(0, 16);
            this.totalprice.TabIndex = 4;
            this.totalprice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // finishorderbutton
            // 
            this.finishorderbutton.Font = new System.Drawing.Font("Sitka Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishorderbutton.Location = new System.Drawing.Point(838, 422);
            this.finishorderbutton.Name = "finishorderbutton";
            this.finishorderbutton.Size = new System.Drawing.Size(144, 54);
            this.finishorderbutton.TabIndex = 5;
            this.finishorderbutton.Text = "Finish Order";
            this.finishorderbutton.UseVisualStyleBackColor = true;
            this.finishorderbutton.Click += new System.EventHandler(this.finishorderbutton_Click);
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(835, 158);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(0, 16);
            this.TotalLabel.TabIndex = 6;
            // 
            // removeitembutton
            // 
            this.removeitembutton.Font = new System.Drawing.Font("Sitka Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeitembutton.Location = new System.Drawing.Point(838, 332);
            this.removeitembutton.Name = "removeitembutton";
            this.removeitembutton.Size = new System.Drawing.Size(144, 54);
            this.removeitembutton.TabIndex = 7;
            this.removeitembutton.Text = "Remove Item";
            this.removeitembutton.UseVisualStyleBackColor = true;
            this.removeitembutton.Click += new System.EventHandler(this.removeitembutton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::wwrestaurant.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(823, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 120);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // WaiterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1052, 557);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.removeitembutton);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.finishorderbutton);
            this.Controls.Add(this.totalprice);
            this.Controls.Add(this.completeorderbutton);
            this.Controls.Add(this.orderstatusbutton);
            this.Controls.Add(this.OrdersList);
            this.Controls.Add(this.ItemsList);
            this.Name = "WaiterPage";
            this.Text = "WaiterPage";
            this.Load += new System.EventHandler(this.WaiterPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ItemsList;
        private System.Windows.Forms.ListView OrdersList;
        private System.Windows.Forms.Button orderstatusbutton;
        private System.Windows.Forms.Button completeorderbutton;
        private System.Windows.Forms.Label totalprice;
        private System.Windows.Forms.Button finishorderbutton;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.Button removeitembutton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}