using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class DashboardBillModel
    {
        public decimal Amount { get; set; }

        public string ProductName { get; set; }
        public string ClientName { get; set; }
    }
}