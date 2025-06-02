using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wwrestaurant
{
    public static class AppStyle
    {
        // === Theme Colors ===
        public static Color PrimaryColor = Color.FromArgb(216, 64, 64); // red
        public static Color AccentColor = Color.FromArgb(163, 29, 29);   // dark red
        public static Color BackgroundColor = Color.FromArgb(248, 242, 222);
        public static Color BackgroundColor_user = Color.White;
        public static Color TextColor = Color.Black;
        public static Color HeaderColor = Color.FromArgb(50, 50, 50);

        public static Font PrimaryFont = new Font("DejaVu Serif", 18, FontStyle.Regular);
        public static Font HeaderFont = new Font("Elephant", 20, FontStyle.Bold);

        public static FontFamily PrimaryFontFamily = new FontFamily("DejaVu Serif");
        public static FontFamily HeaderFontFamily = new FontFamily("Elephant");

        // === Apply Theme to Entire Form ===
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = BackgroundColor_user;
            foreach (Control control in form.Controls)
            {
                ApplyControlStyle(control);
            }
        }

        // === Apply Style to Individual Control Recursively ===
        private static void ApplyControlStyle(Control control)
        {
            control.Font = PrimaryFont;

            switch (control)
            {
                case Button btn:
                    StyleButton(btn);
                    break;

                case Label lbl:
                    lbl.ForeColor = TextColor;
                    lbl.Font = PrimaryFont;
                    break;

                case Panel pnl:
                    pnl.BackColor = Color.White;
                    break;

                case DataGridView dgv:
                    StyleDataGridView(dgv);
                    break;

                case ListView lv:
                    StyleListView(lv);
                    break;

                case TextBox tb:
                    StyleTextBox(tb);
                    break;

                default:
                    control.ForeColor = TextColor;
                    break;
            }

            foreach (Control child in control.Controls)
            {
                ApplyControlStyle(child);
            }
        }

        // === Style a Button ===
        private static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = PrimaryColor;
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(170, 30, 45);
            btn.Cursor = Cursors.Hand;

            btn.Font = new Font(PrimaryFontFamily, btn.Font.Size, FontStyle.Bold); // only change family + style
        }

        // === Style DataGridView ===
        private static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = HeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = TextColor;
            dgv.DefaultCellStyle.SelectionBackColor = AccentColor;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv.RowHeadersVisible = false;
            dgv.GridColor = Color.LightGray;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.ScrollBars = ScrollBars.Vertical;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        // === Style ListView ===
        private static void StyleListView(ListView lv)
        {
            lv.BackColor = Color.White;
            lv.ForeColor = TextColor;
            lv.Font = new Font(PrimaryFontFamily, lv.Font.Size, lv.Font.Style);
            lv.FullRowSelect = true;
            lv.GridLines = true;
            lv.View = View.Details;


        }
        private static void StyleTextBox(TextBox tb)
        {
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.BackColor = Color.White;
            tb.ForeColor = Color.Black;
            tb.Font = new Font(PrimaryFontFamily, tb.Font.Size, tb.Font.Style); // only font family
        }
    }
}
