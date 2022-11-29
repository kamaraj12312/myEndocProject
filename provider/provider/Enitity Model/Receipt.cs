using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class Receipt
    {
        public int ReceiptID { get; set; }
        public int BillID { get; set; }
        public string ReceiptNo { get; set; }
        public System.DateTime ReceiptDate { get; set; }
        public decimal ReceivedAmount { get; set; }
        public Nullable<int> ModeOfPaymentID { get; set; }
        public string BankName { get; set; }
        public string ReferenceNumber { get; set; }
        public string Comments { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual CommonMaster CommonMaster { get; set; }
    }
}