namespace wwrestaurant {
    partial class AdminPage {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.welcomePage = new System.Windows.Forms.TabPage();
            this.dateLabel = new System.Windows.Forms.Label();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.incomeLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.welcome = new System.Windows.Forms.Label();
            this.editMenuPage = new System.Windows.Forms.TabPage();
            this.backButton1 = new System.Windows.Forms.Button();
            this.saveMenuButton = new System.Windows.Forms.Button();
            this.deleteMenuButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.editUsersPage = new System.Windows.Forms.TabPage();
            this.backButton2 = new System.Windows.Forms.Button();
            this.saveUsersButton = new System.Windows.Forms.Button();
            this.deleteUsersButton = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            
            this.openCalendarButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.welcomePage.SuspendLayout();
            this.editMenuPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.editUsersPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
           
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.welcomePage);
            this.tabControl1.Controls.Add(this.editMenuPage);
            this.tabControl1.Controls.Add(this.editUsersPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(910, 506);
            this.tabControl1.TabIndex = 0;
            // 
            // welcomePage
            // 
            this.welcomePage.Controls.Add(this.openCalendarButton);
            this.welcomePage.Controls.Add(this.dateLabel);
            this.welcomePage.Controls.Add(this.calendar);
            this.welcomePage.Controls.Add(this.textBox4);
            this.welcomePage.Controls.Add(this.textBox3);
            this.welcomePage.Controls.Add(this.textBox2);
            this.welcomePage.Controls.Add(this.textBox1);
            this.welcomePage.Controls.Add(this.comboBox1);
            this.welcomePage.Controls.Add(this.label3);
            this.welcomePage.Controls.Add(this.label2);
            this.welcomePage.Controls.Add(this.label1);
            this.welcomePage.Controls.Add(this.incomeLabel);
            this.welcomePage.Controls.Add(this.button2);
            this.welcomePage.Controls.Add(this.button1);
            this.welcomePage.Controls.Add(this.welcome);
            this.welcomePage.Location = new System.Drawing.Point(4, 25);
            this.welcomePage.Name = "welcomePage";
            this.welcomePage.Padding = new System.Windows.Forms.Padding(3);
            this.welcomePage.Size = new System.Drawing.Size(902, 477);
            this.welcomePage.TabIndex = 0;
            this.welcomePage.Text = "tabPage1";
            this.welcomePage.UseVisualStyleBackColor = true;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(670, 58);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(44, 16);
            this.dateLabel.TabIndex = 25;
            this.dateLabel.Text = "label4";
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(331, 58);
            this.calendar.Name = "calendar";
            this.calendar.SelectionRange = new System.Windows.Forms.SelectionRange(new System.DateTime(2024, 5, 19, 0, 0, 0, 0), new System.DateTime(2024, 5, 25, 0, 0, 0, 0));
            this.calendar.TabIndex = 24;
            this.calendar.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(633, 265);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 23;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(633, 373);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(331, 373);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox1.Location = new System.Drawing.Point(331, 269);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 20;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(633, 235);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(486, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 29);
            this.label3.TabIndex = 18;
            this.label3.Text = "Orders delayed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(162, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 29);
            this.label2.TabIndex = 17;
            this.label2.Text = "Orders completed:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(491, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Waiter income:";
            // 
            // incomeLabel
            // 
            this.incomeLabel.AutoSize = true;
            this.incomeLabel.Font = new System.Drawing.Font("Sitka Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incomeLabel.Location = new System.Drawing.Point(197, 262);
            this.incomeLabel.Name = "incomeLabel";
            this.incomeLabel.Size = new System.Drawing.Size(128, 29);
            this.incomeLabel.TabIndex = 15;
            this.incomeLabel.Text = "Income today:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Sitka Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(561, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 78);
            this.button2.TabIndex = 14;
            this.button2.Text = "Edit Users";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Sitka Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(228, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 78);
            this.button1.TabIndex = 13;
            this.button1.Text = "Edit Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.Font = new System.Drawing.Font("Sitka Display", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome.Location = new System.Drawing.Point(328, 16);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(231, 62);
            this.welcome.TabIndex = 12;
            this.welcome.Text = "Hello Boss!";
            // 
            // editMenuPage
            // 
            this.editMenuPage.Controls.Add(this.backButton1);
            this.editMenuPage.Controls.Add(this.saveMenuButton);
            this.editMenuPage.Controls.Add(this.deleteMenuButton);
            this.editMenuPage.Controls.Add(this.dataGridView1);
            this.editMenuPage.Location = new System.Drawing.Point(4, 25);
            this.editMenuPage.Name = "editMenuPage";
            this.editMenuPage.Padding = new System.Windows.Forms.Padding(3);
            this.editMenuPage.Size = new System.Drawing.Size(902, 477);
            this.editMenuPage.TabIndex = 1;
            this.editMenuPage.Text = "tabPage2";
            this.editMenuPage.UseVisualStyleBackColor = true;
            // 
            // backButton1
            // 
            this.backButton1.Font = new System.Drawing.Font("Sitka Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton1.Location = new System.Drawing.Point(775, 413);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(97, 43);
            this.backButton1.TabIndex = 4;
            this.backButton1.Text = "Back";
            this.backButton1.UseVisualStyleBackColor = true;
            this.backButton1.Click += new System.EventHandler(this.backButton1_Click);
            // 
            // saveMenuButton
            // 
            this.saveMenuButton.Font = new System.Drawing.Font("Sitka Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveMenuButton.Location = new System.Drawing.Point(775, 94);
            this.saveMenuButton.Name = "saveMenuButton";
            this.saveMenuButton.Size = new System.Drawing.Size(97, 43);
            this.saveMenuButton.TabIndex = 3;
            this.saveMenuButton.Text = "Save";
            this.saveMenuButton.UseVisualStyleBackColor = true;
            this.saveMenuButton.Click += new System.EventHandler(this.saveMenuButton_Click_1);
            // 
            // deleteMenuButton
            // 
            this.deleteMenuButton.Font = new System.Drawing.Font("Sitka Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteMenuButton.Location = new System.Drawing.Point(775, 34);
            this.deleteMenuButton.Name = "deleteMenuButton";
            this.deleteMenuButton.Size = new System.Drawing.Size(97, 43);
            this.deleteMenuButton.TabIndex = 2;
            this.deleteMenuButton.Text = "Delete";
            this.deleteMenuButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(745, 408);
            this.dataGridView1.TabIndex = 0;
            // 
            // editUsersPage
            // 
            this.editUsersPage.Controls.Add(this.backButton2);
            this.editUsersPage.Controls.Add(this.saveUsersButton);
            this.editUsersPage.Controls.Add(this.deleteUsersButton);
            this.editUsersPage.Controls.Add(this.dataGridView2);
            this.editUsersPage.Location = new System.Drawing.Point(4, 25);
            this.editUsersPage.Name = "editUsersPage";
            this.editUsersPage.Padding = new System.Windows.Forms.Padding(3);
            this.editUsersPage.Size = new System.Drawing.Size(902, 477);
            this.editUsersPage.TabIndex = 2;
            this.editUsersPage.Text = "tabPage1";
            this.editUsersPage.UseVisualStyleBackColor = true;
            // 
            // backButton2
            // 
            this.backButton2.Font = new System.Drawing.Font("Sitka Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton2.Location = new System.Drawing.Point(790, 423);
            this.backButton2.Name = "backButton2";
            this.backButton2.Size = new System.Drawing.Size(97, 43);
            this.backButton2.TabIndex = 9;
            this.backButton2.Text = "Back";
            this.backButton2.UseVisualStyleBackColor = true;
            this.backButton2.Click += new System.EventHandler(this.backButton2_Click);
            // 
            // saveUsersButton
            // 
            this.saveUsersButton.Font = new System.Drawing.Font("Sitka Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveUsersButton.Location = new System.Drawing.Point(779, 93);
            this.saveUsersButton.Name = "saveUsersButton";
            this.saveUsersButton.Size = new System.Drawing.Size(97, 43);
            this.saveUsersButton.TabIndex = 8;
            this.saveUsersButton.Text = "Save";
            this.saveUsersButton.UseVisualStyleBackColor = true;
            this.saveUsersButton.Click += new System.EventHandler(this.saveUsersButton_Click_1);
            // 
            // deleteUsersButton
            // 
            this.deleteUsersButton.Font = new System.Drawing.Font("Sitka Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteUsersButton.Location = new System.Drawing.Point(779, 33);
            this.deleteUsersButton.Name = "deleteUsersButton";
            this.deleteUsersButton.Size = new System.Drawing.Size(97, 43);
            this.deleteUsersButton.TabIndex = 7;
            this.deleteUsersButton.Text = "Delete";
            this.deleteUsersButton.UseVisualStyleBackColor = true;
            this.deleteUsersButton.Click += new System.EventHandler(this.deleteUsersButton_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(15, 10);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(745, 408);
            this.dataGridView2.TabIndex = 5;
            // 
            // wwrestaurantDataSet
            // 
            
            // 
            // openCalendarButton
            // 
            this.openCalendarButton.Location = new System.Drawing.Point(206, 235);
            this.openCalendarButton.Name = "openCalendarButton";
            this.openCalendarButton.Size = new System.Drawing.Size(119, 23);
            this.openCalendarButton.TabIndex = 26;
            this.openCalendarButton.Text = "Select date";
            this.openCalendarButton.UseVisualStyleBackColor = true;
            this.openCalendarButton.Click += new System.EventHandler(this.openCalendarButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 518);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.welcomePage.ResumeLayout(false);
            this.welcomePage.PerformLayout();
            this.editMenuPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.editUsersPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage welcomePage;
        private System.Windows.Forms.TabPage editMenuPage;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label incomeLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.TabPage editUsersPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        
        private System.Windows.Forms.Button saveMenuButton;
        private System.Windows.Forms.Button deleteMenuButton;
        private System.Windows.Forms.Button backButton1;
        private System.Windows.Forms.Button backButton2;
        private System.Windows.Forms.Button saveUsersButton;
        private System.Windows.Forms.Button deleteUsersButton;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button openCalendarButton;
    }
}

