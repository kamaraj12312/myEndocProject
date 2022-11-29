using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class Inquiry
    {
        public Inquiry()
        {
            this.InquiryDetails = new List<InquiryDetail>();
        }

        public int InquiryID { get; set; }
        public string Salutation { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string TelePhone { get; set; }
        public string Email { get; set; }
        public string InterestedProductID { get; set; }
        public string Others { get; set; }
        public string ReferedBy { get; set; }
        public string Comments { get; set; }
        public Nullable<int> AssignedToID { get; set; }
        public string InquiryStatus { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public virtual ICollection<InquiryDetail> InquiryDetails { get; set; }
    }
}