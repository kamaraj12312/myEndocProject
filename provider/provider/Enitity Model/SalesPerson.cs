using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class SalesPerson
    {
        public SalesPerson()
        {
            this.Inquiries = new List<Inquiry>();
            this.InquiryDetails = new List<InquiryDetail>();
        }

        public int SalesPersonID { get; set; }
        public string Salutation { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Inquiry> Inquiries { get; set; }
        public virtual ICollection<InquiryDetail> InquiryDetails { get; set; }
    }
}