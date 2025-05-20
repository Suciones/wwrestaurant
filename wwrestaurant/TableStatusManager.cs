using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwrestaurant
{
    // Static event manager class for table status updates
    public static class TableStatusManager
    {
        // Define a delegate and event for table status changes
        public delegate void TableStatusChangedEventHandler(object sender, EventArgs e);
        public static event TableStatusChangedEventHandler TableStatusChanged;

        // Method to notify all subscribers that table status has changed
        public static void NotifyTableStatusChanged()
        {
            TableStatusChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}
