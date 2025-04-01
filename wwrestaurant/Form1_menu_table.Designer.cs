namespace wwrestaurant
{
    partial class Form1_menu_table
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
            this.btnStartOrder = new System.Windows.Forms.Button();
            this.btnReserveTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartOrder
            // 
            this.btnStartOrder.Location = new System.Drawing.Point(99, 126);
            this.btnStartOrder.Name = "btnStartOrder";
            this.btnStartOrder.Size = new System.Drawing.Size(205, 153);
            this.btnStartOrder.TabIndex = 0;
            this.btnStartOrder.Text = "START ORDER";
            this.btnStartOrder.UseVisualStyleBackColor = true;
            this.btnStartOrder.Click += new System.EventHandler(this.btnStartOrder_Click);
            // 
            // btnReserveTable
            // 
            this.btnReserveTable.Location = new System.Drawing.Point(473, 126);
            this.btnReserveTable.Name = "btnReserveTable";
            this.btnReserveTable.Size = new System.Drawing.Size(204, 150);
            this.btnReserveTable.TabIndex = 1;
            this.btnReserveTable.Text = "RESERVE TABLE";
            this.btnReserveTable.UseVisualStyleBackColor = true;
            this.btnReserveTable.Click += new System.EventHandler(this.btnReserveTable_Click);
            // 
            // Form1_menu_table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReserveTable);
            this.Controls.Add(this.btnStartOrder);
            this.Name = "Form1_menu_table";
            this.Text = "Form1_menu_table";
            this.Load += new System.EventHandler(this.Form1_menu_table_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartOrder;
        private System.Windows.Forms.Button btnReserveTable;
    }
}