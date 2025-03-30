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
   
    public partial class Form_table : Form
    {
        public Form_table()
        {
            InitializeComponent();
        }
        List<RestaurantTable> tables = new List<RestaurantTable>();
        private void TableAvailabilityForm_Load(object sender, EventArgs e)
        {
            tables = new List<RestaurantTable>
    {
        new RestaurantTable { Id = 1, Name = "Table 1", Status = "Available" },
        new RestaurantTable { Id = 2, Name = "Table 2", Status = "Occupied" },
        new RestaurantTable { Id = 3, Name = "Table 3", Status = "Reserved" },
        new RestaurantTable { Id = 4, Name = "Table 4", Status = "Available" }
    };

            panelTables.Invalidate(); // Redraw
        }
        
        private void Form_table_Load(object sender, EventArgs e)
        {

        }

        private void panelTables_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int x = 50, y = 50;

            foreach (var table in tables)
            {
                Color color;
                switch (table.Status)
                {
                    case "Available":
                        color = Color.Green;
                        break;
                    case "Occupied":
                        color = Color.Red;
                        break;
                    case "Reserved":
                        color = Color.Orange;
                        break;
                    default:
                        color = Color.Gray;
                        break;
                }

                Rectangle rect = new Rectangle(x, y, 80, 80);
                table.Area = rect; // Store for click detection
                g.FillEllipse(new SolidBrush(color), rect);
                g.DrawString(table.Name, new Font("Arial", 10), Brushes.White, x + 10, y + 30);

                x += 120; // Move next table
            }
        }
        private void panelTables_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var table in tables)
            {
                if (table.Area.Contains(e.Location))
                {
                    toolTip1.SetToolTip(panelTables, $"{table.Name}\nStatus: {table.Status}");
                    return;
                }
            }
            toolTip1.SetToolTip(panelTables, "");
        }
        private void panelTables_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var table in tables)
            {
                if (table.Area.Contains(e.Location))
                {
                    // Toggle status on click
                    if (table.Status == "Available") table.Status = "Occupied";
                    else if (table.Status == "Occupied") table.Status = "Reserved";
                    else table.Status = "Available";

                    panelTables.Invalidate(); // Redraw
                    break;
                }
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            panelTables.Invalidate(); // Force redraw
        }

        

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
    public class RestaurantTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } // Available, Occupied, Reserved
        public Rectangle Area { get; set; } // For click detection
    }
}
