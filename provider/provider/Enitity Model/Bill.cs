using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class Bill
    {
        public Bill()
        {
            this.Receipts = new List<Receipt>();
        }

        public int BillID { get; set; }
        public string BillNo { get; set; }
        public System.DateTime BillDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<int> ClientAccountID { get; set; }
        public string ProductID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> StatusID { get; set; }
        public decimal Amount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public string Comments { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ClientAccountSetup ClientAccountSetup { get; set; }
        public virtual ClientSetup ClientSetup { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}