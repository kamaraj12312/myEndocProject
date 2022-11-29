using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class EDI837PTransaction
    {
        public int EDI837PTransactionID { get; set; }
        public int ClaimID { get; set; }
        public string ClaimNumber { get; set; }
        public Nullable<int> PatientEncounterID { get; set; }
        public int ClaimTypeID { get; set; }
        public int PatientID { get; set; }
        public int FacilityID { get; set; }

        public int InsuranceTypeID { get; set; }
        public Nullable<int> InsuranceCategoryID { get; set; }
        public int RenderingProviderID { get; set; }
        public Nullable<int> PatientInsuranceID { get; set; }

        public string SubscriberName { get; set; }

        public Nullable<int> ClaimStatusID { get; set; }

        public string SubscriberInsuranceID { get; set; }
        public string SubscriberGroupID { get; set; }
        public Nullable<int> InsuranceCompanyID { get; set; }

        public Nullable<System.DateTime> EncounterDate { get; set; }

        public Nullable<System.DateTime> DateofServiceFrom { get; set; }

        public Nullable<System.DateTime> DateofServiceTo { get; set; }

        public int FileID { get; set; }

        public bool Deleted { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public string RemovedBy { get; set; }

        public Nullable<System.DateTime> RemovedDate { get; set; }

        public string EdiTransactionType { get; set; }

        public string EDITransactionNumber { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverName { get; set; }
        public Nullable<int> EDIRequestMode { get; set; }
        public Nullable<decimal> ClaimAdjustmentAmount { get; set; }//Adjustment Amount
        public int RecID { get; set; }//Need to be increment

        public Nullable<decimal> PaidByPatient { get; set; }
        public Nullable<decimal> TotalClaimAmount { get; set; }
        public Nullable<decimal> TotalCharges { get; set; }

        public Nullable<decimal> PaidByInsurance { get; set; }

        public string BillingProviderType { get; set; }
        public int BillingProviderID { get; set; }
        public Nullable<int> EncounterInsuranceID { get; set; }
        public Nullable<int> PatientFamilyID { get; set; }
        public Nullable<int> ReferralProviderID { get; set; }

        public string BillingProviderNPI { get; set; }
        public string BillingProviderTaxID { get; set; }

        public string InsuranceCompanyName { get; set; }
        public string ProviderNPI { get; set; }
        public string ProviderTaxID { get; set; }
        public string BillingProviderTaxonomy { get; set; }
        public string FacilityNPI { get; set; }
        public string FacilityStateLicenceNbr { get; set; }
        public string ProviderComercialNbr { get; set; }
        public string ReferringProviderNPI { get; set; }
        public string EPSDTFamilyPlan { get; set; }
        public Nullable<System.DateTime> PatientSignatureDate { get; set; }
        public Nullable<System.DateTime> InsuredSignatureDate { get; set; }
        public Nullable<System.DateTime> IllnessDate { get; set; }
        public Nullable<System.DateTime> UnableToWorkFromDate { get; set; }
        public Nullable<System.DateTime> UnableToWorkToDate { get; set; }

        public bool IsOutsideLabService { get; set; }
        public decimal OutsideLabServiceCharges { get; set; }
        public string ResubmissionCode { get; set; }
        public string OriginalReferenceNumber { get; set; }
        public string PreAuthorizationNo { get; set; }
        public Nullable<System.DateTime> OtherDate { get; set; }
        public decimal TotalCopay { get; set; }
        public decimal TotalDeductible { get; set; }
        public decimal TotalCoInsurance { get; set; }

        public Nullable<System.DateTime> ClaimGeneratedDate { get; set; }
        public Nullable<System.DateTime> ClaimSubmittedDate { get; set; }

        public Nullable<System.DateTime> ClaimStatusDate { get; set; }
        public Nullable<System.DateTime> EncounteredDate { get; set; }
        public Nullable<System.DateTime> ClaimdDate { get; set; }

        public string ICDCode1 { get; set; }
        public string ICDCode2 { get; set; }
        public string ICDCode3 { get; set; }
        public string ICDCode4 { get; set; }
        public string ICDCode5 { get; set; }
        public string ICDCode6 { get; set; }
        public string ICDCode7 { get; set; }
        public string ICDCode8 { get; set; }
        public string ICDCode9 { get; set; }
        public string ICDCode10 { get; set; }
        public string ICDCode11 { get; set; }
        public string ICDCode12 { get; set; }
        public string EncounterNumber { get; set; }
        public int EDIGeneratedStatusID { get; set; }
        public string BIllingProviderInsuranceID { get; set; }
        public string ReferringProviderInsuranceID { get; set; }
        public Nullable<int> PayToID { get; set; }
        public string Notes { get; set; }
        public Nullable<DateTime> SimilarIllnessDate { get; set; }
        public Nullable<DateTime> AccidentDate { get; set; }
        public Nullable<bool> Billed { get; set; }
        public Nullable<DateTime> BillProcessed { get; set; }
        public string AccidentState { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public Nullable<System.DateTime> HospitalizedFromDate { get; set; }
        public Nullable<System.DateTime> HospitalizedToDate { get; set; }
        public Nullable<decimal> BilledAmount { get; set; }
        public Nullable<System.DateTime> SentDate { get; set; }

        public Nullable<decimal> PatientResponsibleAmount { get; set; }
        public Nullable<decimal> OtherAdjustmentAmount { get; set; }
        public string RejectReason { get; set; }

        public bool MoveToPatient { get; set; }
        public int IsPayerSent { get; set; }
        public string TransmissionMode { get; set; }
    }
}