using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class InquiryDetail
    {
        public int InquiryDetailID { get; set; }
        public int InquiryID { get; set; }
        public int SalesPersonID { get; set; }
        public string ModeOfContact { get; set; }
        public Nullable<System.DateTime> ContactTime { get; set; }
        public string Feedback { get; set; }
        public Nullable<System.DateTime> NextFollowupDateTime { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Inquiry Inquiry { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
    }
}