using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class DashboardReceiptModel
    {
        public string ReceiptNo { get; set; }

        public decimal ReceivedAmount { get; set; }

        public string ClientName { get; set; }


        public string ProductName { get; set; }
    }
}