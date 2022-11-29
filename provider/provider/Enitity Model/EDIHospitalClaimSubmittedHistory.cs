using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class EDIHospitalClaimSubmittedHistory
    {
        [Key]
        public int EDIHospitalClaimSubmittedHistoryID { get; set; }
        public int HospitalClaimID { get; set; }
        public string ClaimNumber { get; set; }
        public Nullable<int> PatientEncounterID { get; set; }
        public string EncounterNumber { get; set; }
        public Nullable<System.DateTime> EncounteredDate { get; set; }
        public int ClaimTypeID { get; set; }
        public int PatientID { get; set; }
        public int FacilityID { get; set; }
        public int RenderingProviderID { get; set; }
        public string PayToTypeID { get; set; }
        public int PayToID { get; set; }
        public Nullable<int> ReferralProviderID { get; set; }
        //public string PatientInsuranceID { get; set; }
        public Nullable<int> PatientInsuranceID { get; set; }
        public Nullable<int> SubscriberID { get; set; }
        public Nullable<int> PatientRelationshipID { get; set; }
        public string SubscriberInsuredID { get; set; }
        public string SubscriberGroupID { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string FacilityNPI { get; set; }
        public string FacilityStateLicenceNbr { get; set; }
        public string ProviderNPI { get; set; }
        public string ProviderTaxID { get; set; }
        public string BillingProviderNPI { get; set; }
        public string BillingProviderTaxID { get; set; }
        public string BillingProviderTaxonomy { get; set; }
        public string ProviderComercialNbr { get; set; }
        public string ReferringProviderNPI { get; set; }
        public string EPSDTFamilyPlan { get; set; }
        public string EPSDTReferralConditionIndicator { get; set; }
        public string EPSDTReferralNumber { get; set; }
        public Nullable<System.DateTime> PatientSignatureDate { get; set; }
        public Nullable<System.DateTime> InsuredSignatureDate { get; set; }
        public Nullable<System.DateTime> IllnessDate { get; set; }
        public Nullable<System.DateTime> AdmissionDate { get; set; }
        public Nullable<int> AdmissionHoursCodeID { get; set; }
        public Nullable<int> TypeOfVisitID { get; set; }
        public Nullable<System.DateTime> DischargeDate { get; set; }
        public Nullable<int> DischargeHoursCodeID { get; set; }
        public Nullable<int> DischargeStatusID { get; set; }
        public Nullable<System.DateTime> OccurrenceDate { get; set; }
        public Nullable<System.DateTime> AccidentDate { get; set; }
        public string AccidentState { get; set; }
        public string PayToPlanName { get; set; }
        public Nullable<int> PayToPlanID { get; set; }
        public string PayToPlanOrganizationalName { get; set; }
        public string PayToPlanAddressLine1 { get; set; }
        public string PayToPlanAddressLine2 { get; set; }
        public string PayToPlanCity { get; set; }
        public string PayToPlanState { get; set; }
        public string PayToPlanZip { get; set; }
        public string PayToPlanTaxID { get; set; }
        public Nullable<System.DateTime> UnableToWorkFromDate { get; set; }
        public Nullable<System.DateTime> UnableToWorkToDate { get; set; }
        //public Nullable<System.DateTime> HospitalizedFromDate { get; set; }
        //public Nullable<System.DateTime> HospitalizedToDate { get; set; }
        public bool IsOutsideLabService { get; set; }
        public decimal OutsideLabServiceCharges { get; set; }
        public string ResubmissionCode { get; set; }
        public string OriginalReferenceNumber { get; set; }
        public string PreAuthorizationNo { get; set; }
        public string RepricedClaimNo { get; set; }
        public string PrincipalDiagnosisCode { get; set; }
        public string AdmittingDiagnosisCode { get; set; }
        public string PatientsReasonForVisitCode { get; set; }
        public string ExternalCauseOfInjuryCode { get; set; }
        public string DiagnosisRelatedGroupCode { get; set; }
        public string OtherDiagnosisCode { get; set; }
        public string PrincipalProcedureCode { get; set; }
        public Nullable<System.DateTime> PrincipalProcedureDate { get; set; }
        public string OtherProcedureCode { get; set; }
        public Nullable<System.DateTime> OtherProcedureDate { get; set; }
        public Nullable<int> ConditionCodeID { get; set; }
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
        public string Notes { get; set; }
        public decimal TotalCopay { get; set; }
        public decimal TotalCoInsurance { get; set; }
        public decimal TotalDeductible { get; set; }
        public decimal TotalCharges { get; set; }
        [Obsolete(message: "Currently this property is not used ,Please use 'TotalCharges' instead of  TotalClaimAmount.Further details please refer EDIHospitalClaimSubmittedHistory table", error: true)]
        public Nullable<decimal> TotalClaimAmount { get; set; }
        public Nullable<decimal> PaidByInsurance { get; set; }
        public Nullable<decimal> PaidByPatient { get; set; }
        public Nullable<System.DateTime> ClaimGeneratedDate { get; set; }
        public Nullable<System.DateTime> ClaimSubmittedDate { get; set; }
        public Nullable<int> ClaimStatusID { get; set; }
        public Nullable<System.DateTime> ClaimStatusDate { get; set; }
        public Nullable<System.DateTime> ClaimdDate { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string BIllingProviderInsuranceID { get; set; }
        public string ReferingProviderInsuranceID { get; set; }
        public string EDITransactionNumber { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverName { get; set; }
        public Nullable<int> EDIRequestMode { get; set; }
        public Nullable<int> EDIGeneratedStatusID { get; set; }

        public int FileID { get; set; }
        public Nullable<decimal> ClaimAdjustmentAmount { get; set; }//Adjustment Amount
        public int RecID { get; set; }//Need to be increment
        public Nullable<int> InsuranceCompanyID { get; set; }

        public Nullable<int> BillingProviderID { get; set; }

        public int TypeOfBillID { get; set; }
        public int InsuranceTypeID { get; set; }
        public Nullable<System.DateTime> DateofServiceFrom { get; set; }
        public Nullable<System.DateTime> DateofServiceTo { get; set; }
        public Nullable<decimal> BilledAmount { get; set; }
        public Nullable<System.DateTime> SentDate { get; set; }
        public int SourceOfAdmissionID { get; set; }
        public string OtherProcedureCode1 { get; set; }
        public Nullable<System.DateTime> OtherProcedureDate1 { get; set; }
        public string OtherProcedureCode2 { get; set; }
        public Nullable<System.DateTime> OtherProcedureDate2 { get; set; }
        public string OtherProcedureCode3 { get; set; }
        public Nullable<System.DateTime> OtherProcedureDate3 { get; set; }
        public string ExternalCauseOfInjuryCode1 { get; set; }
        public string ExternalCauseOfInjuryCode2 { get; set; }

        public Nullable<decimal> PatientResponsibleAmount { get; set; }
        public Nullable<decimal> OtherAdjustmentAmount { get; set; }
        public string RejectReason { get; set; }

        public bool MoveToPatient { get; set; }
        public int IsPayerSent { get; set; }
        public string TransmissionMode { get; set; }
    }
}