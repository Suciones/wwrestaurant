namespace wwrestaurant
{
    partial class Form_table
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
            this.panelTables = new System.Windows.Forms.Panel();
            this.labelLegend = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTables
            // 
            this.panelTables.Controls.Add(this.labelLegend);
            this.panelTables.Location = new System.Drawing.Point(45, 37);
            this.panelTables.Name = "panelTables";
            this.panelTables.Size = new System.Drawing.Size(561, 304);
            this.panelTables.TabIndex = 0;
            this.panelTables.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTables_Paint);
            // 
            // labelLegend
            // 
            this.labelLegend.AutoSize = true;
            this.labelLegend.Location = new System.Drawing.Point(458, 14);
            this.labelLegend.Name = "labelLegend";
            this.labelLegend.Size = new System.Drawing.Size(53, 16);
            this.labelLegend.TabIndex = 0;
            this.labelLegend.Text = "Legend";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(45, 362);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // Form_table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panelTables);
            this.Name = "Form_table";
            this.Text = "Form_table";
            this.Load += new System.EventHandler(this.Form_table_Load);
            this.panelTables.ResumeLayout(false);
            this.panelTables.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTables;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelLegend;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}