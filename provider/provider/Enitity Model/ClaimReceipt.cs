using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class ClaimReceipt
    {
        public ClaimReceipt()
        {
            this.ClaimReceiptDetails = new List<ClaimReceiptDetail>();
            this.PatientLedgers = new List<PatientLedger>();
        }

        public int ClaimReceiptID { get; set; }
        public string ReceiptNumber { get; set; }
        public System.DateTime ReceiptDate { get; set; }
        public Nullable<int> PaymentTypeID { get; set; }
        public Nullable<int> PaymentModeID { get; set; }
        public string BankName { get; set; }
        public string PaymentIDNumber { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public decimal PaidAmount { get; set; }
        public Nullable<int> ReceiptStatusID { get; set; }
        public string Comments { get; set; }
        public Nullable<int> PatientID { get; set; }
        public Nullable<int> InsuranceCompanyID { get; set; }
        public decimal RefundAmount { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsOutOfPocket { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public virtual ClaimPaymentStatus ClaimPaymentStatu { get; set; }
        public virtual ClaimPaymentStatus ClaimPaymentStatu1 { get; set; }
        public virtual ICollection<ClaimReceiptDetail> ClaimReceiptDetails { get; set; }
        public virtual InsuranceCompany InsuranceCompany { get; set; }
        public virtual ICollection<PatientLedger> PatientLedgers { get; set; }
    }
}