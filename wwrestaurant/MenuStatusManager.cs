using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwrestaurant
{
    internal class MenuStatusManager
    {
        // Define a delegate and event for table status changes
        public delegate void MenuStatusChangedEventHandler(object sender, EventArgs e);
        public static event MenuStatusChangedEventHandler MenuStatusChanged;

        // Method to notify all subscribers that table status has changed
        public static void NotifyMenuStatusChanged()
        {
            MenuStatusChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}
