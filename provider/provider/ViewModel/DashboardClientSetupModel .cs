using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class DashboardClientSetupModel
    {
        public string ClientName { get; set; }
        public string ProductName { get; set; }
        public Nullable<System.DateTime> ProductActiveFrom { get; set; }
        public Nullable<System.DateTime> ProductActivateTo { get; set; }
    }
}