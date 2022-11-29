using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class DashboardInquiryDetailModel
    {
        public Nullable<System.DateTime> NextFollowupDateTime { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string SalesPersonName { get; set; }
        public string InterestedProductID { get; set; }
        public string InquirerName { get; set; }
    }
}