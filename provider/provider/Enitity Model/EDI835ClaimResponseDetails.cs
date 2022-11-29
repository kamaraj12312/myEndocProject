using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class EDI835ClaimResponseDetails
    {
        [Key]
        public int EDI835ClaimResponseID { get; set; }
        public int EDIFileDetailID { get; set; }
        public int ClaimID { get; set; }
        public string ClaimNumber { get; set; }
        public Nullable<int> InsuranceCompanyID { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public Nullable<int> PatientID { get; set; }
        public decimal TotalClaimAmount { get; set; }
        public decimal InsurancePaidAmount { get; set; }
        public decimal PatientResponsibleAmount { get; set; }
        public string ClaimFillingIndicatorCode { get; set; }
        public string ClaimStatusCode { get; set; }
        public bool IsUpdated { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string PaymentStatus { get; set; }
        public int SubmittedHistoryID { get; set; }
        public Nullable<decimal> OtherAdjustmentAmount { get; set; }

        public Nullable<decimal> TotalClaimAdjustmentAmount { get; set; }
        public Nullable<decimal> AdjustmentAmountLevel1 { get; set; }

        public Nullable<decimal> AdjustmentAmountLevel2 { get; set; }

        public string ClaimType { get; set; }
        public decimal RefundAmount { get; set; }
    }
}