namespace wwrestaurant
{
    partial class Start_Page
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.label_tableavailability = new System.Windows.Forms.Label();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.label_menu = new System.Windows.Forms.Label();
            this.dgvMenu = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(1313, 12);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(151, 51);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Log in";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // label_tableavailability
            // 
            this.label_tableavailability.AutoSize = true;
            this.label_tableavailability.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tableavailability.Location = new System.Drawing.Point(147, 397);
            this.label_tableavailability.Name = "label_tableavailability";
            this.label_tableavailability.Size = new System.Drawing.Size(394, 23);
            this.label_tableavailability.TabIndex = 2;
            this.label_tableavailability.Text = "Firstly, please select a table :";
            // 
            // lstTables
            // 
            this.lstTables.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTables.FormattingEnabled = true;
            this.lstTables.ItemHeight = 23;
            this.lstTables.Location = new System.Drawing.Point(151, 434);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(353, 349);
            this.lstTables.TabIndex = 3;
            this.lstTables.SelectedIndexChanged += new System.EventHandler(this.lstTables_SelectedIndexChanged_1);
            // 
            // label_menu
            // 
            this.label_menu.AutoSize = true;
            this.label_menu.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_menu.Location = new System.Drawing.Point(650, 79);
            this.label_menu.Name = "label_menu";
            this.label_menu.Size = new System.Drawing.Size(70, 23);
            this.label_menu.TabIndex = 4;
            this.label_menu.Text = "MENU:";
            // 
            // dgvMenu
            // 
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Price,
            this.Picture,
            this.Quantity,
            this.Add});
            this.dgvMenu.Location = new System.Drawing.Point(654, 121);
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.RowHeadersWidth = 51;
            this.dgvMenu.RowTemplate.Height = 24;
            this.dgvMenu.Size = new System.Drawing.Size(682, 662);
            this.dgvMenu.TabIndex = 5;
            this.dgvMenu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgMenu_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "NAME";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Price
            // 
            this.Price.HeaderText = "PRICE";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.Width = 125;
            // 
            // Picture
            // 
            this.Picture.HeaderText = "";
            this.Picture.MinimumWidth = 6;
            this.Picture.Name = "Picture";
            this.Picture.Width = 125;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 125;
            // 
            // Add
            // 
            this.Add.HeaderText = "Add item";
            this.Add.MinimumWidth = 6;
            this.Add.Name = "Add";
            this.Add.Width = 125;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::wwrestaurant.Properties.Resources.logo;
            this.pictureBox1.InitialImage = global::wwrestaurant.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(-43, -133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(615, 527);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Start_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1629, 959);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvMenu);
            this.Controls.Add(this.label_menu);
            this.Controls.Add(this.lstTables);
            this.Controls.Add(this.label_tableavailability);
            this.Controls.Add(this.btnLogin);
            this.Name = "Start_Page";
            this.Load += new System.EventHandler(this.Start_Page_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label_tableavailability;
        private System.Windows.Forms.ListBox lstTables;
        private System.Windows.Forms.Label label_menu;
        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewImageColumn Picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewButtonColumn Add;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}