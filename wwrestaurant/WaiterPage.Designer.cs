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
            this.SuspendLayout();
            // 
            // ItemsList
            // 
            this.ItemsList.HideSelection = false;
            this.ItemsList.Location = new System.Drawing.Point(287, 12);
            this.ItemsList.Name = "ItemsList";
            this.ItemsList.Size = new System.Drawing.Size(353, 426);
            this.ItemsList.TabIndex = 0;
            this.ItemsList.UseCompatibleStateImageBehavior = false;
            // 
            // OrdersList
            // 
            this.OrdersList.HideSelection = false;
            this.OrdersList.Location = new System.Drawing.Point(12, 12);
            this.OrdersList.Name = "OrdersList";
            this.OrdersList.Size = new System.Drawing.Size(269, 426);
            this.OrdersList.TabIndex = 1;
            this.OrdersList.UseCompatibleStateImageBehavior = false;
            this.OrdersList.SelectedIndexChanged += new System.EventHandler(this.OrdersList_SelectedIndexChanged);
            // 
            // orderstatusbutton
            // 
            this.orderstatusbutton.Enabled = false;
            this.orderstatusbutton.Location = new System.Drawing.Point(677, 101);
            this.orderstatusbutton.Name = "orderstatusbutton";
            this.orderstatusbutton.Size = new System.Drawing.Size(75, 52);
            this.orderstatusbutton.TabIndex = 2;
            this.orderstatusbutton.Text = "Order Status";
            this.orderstatusbutton.UseVisualStyleBackColor = true;
            // 
            // completeorderbutton
            // 
            this.completeorderbutton.Location = new System.Drawing.Point(677, 159);
            this.completeorderbutton.Name = "completeorderbutton";
            this.completeorderbutton.Size = new System.Drawing.Size(75, 52);
            this.completeorderbutton.TabIndex = 3;
            this.completeorderbutton.Text = "Complete Order";
            this.completeorderbutton.UseVisualStyleBackColor = true;
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
            this.finishorderbutton.Location = new System.Drawing.Point(677, 323);
            this.finishorderbutton.Name = "finishorderbutton";
            this.finishorderbutton.Size = new System.Drawing.Size(75, 54);
            this.finishorderbutton.TabIndex = 5;
            this.finishorderbutton.Text = "Finish Order";
            this.finishorderbutton.UseVisualStyleBackColor = true;
            // 
            // WaiterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.finishorderbutton);
            this.Controls.Add(this.totalprice);
            this.Controls.Add(this.completeorderbutton);
            this.Controls.Add(this.orderstatusbutton);
            this.Controls.Add(this.OrdersList);
            this.Controls.Add(this.ItemsList);
            this.Name = "WaiterPage";
            this.Text = "WaiterPage";
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
    }
}