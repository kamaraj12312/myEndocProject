using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace provider.Enitity_Model
{
    public class ClaimBill
    {
        public ClaimBill()
        {
            //this.ClaimBillDetails = new List<ClaimBillDetail>();
            this.ClaimReceiptDetails = new List<ClaimReceiptDetail>();
            this.PatientLedgers = new List<PatientLedger>();
        }

        public int ClaimBillID { get; set; }
        public string BillNumber { get; set; }
        public Nullable<System.DateTime> BillDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public int ClaimID { get; set; }
        public string ClaimNumber { get; set; }
        public string BillStatusCode { get; set; }
        public decimal Charges { get; set; }
        public decimal PaidByInsurance { get; set; }
        public decimal PaidByPatient { get; set; }
        public Nullable<decimal> BalanceAmount { get; set; }
        public Nullable<System.DateTime> ExportedDate { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ClaimTypeCode { get; set; }
        public decimal BilledAmount { get; set; }
        public virtual Claim Claim { get; set; }
        //public virtual ICollection<ClaimBillDetail> ClaimBillDetails { get; set; }
        public virtual ICollection<ClaimReceiptDetail> ClaimReceiptDetails { get; set; }
        public virtual ICollection<PatientLedger> PatientLedgers { get; set; }
    }
}