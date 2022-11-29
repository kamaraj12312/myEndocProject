using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class ProviderModel
    {
        public ProviderModel()
        {
            this.Claims = new List<ClaimModel>();
            this.NurseDiagnosis = new List<NurseDiagnosiModel>();
            this.PatientAppointments = new List<PatientAppointmentModel>();
            this.PatientEncounters = new List<PatientEncounterModel>();
            this.ProviderAddresses = new List<ProviderAddressModel>();
            this.ProviderDiagnosisCodes = new List<ProviderDiagnosisCodeModel>();
            this.ProviderFeeSchedules = new List<ProviderFeeScheduleModel>();
            this.ProviderInsurances = new List<ProviderInsuranceModel>();
            this.ProviderLocations = new List<ProviderLocationModel>();
            this.ProviderLocationTimings = new List<ProviderLocationTimingModel>();
            this.ProviderSpecialities = new List<ProviderSpecialityModel>();
            this.ProviderTreatmentCodes = new List<ProviderTreatmentCodeModel>();
            this.ProviderVacations = new List<ProviderVacationModel>();
            this.SuperBills = new List<SuperBillModel>();
            this.SuperBillTreatments = new List<SuperBillTreatmentModel>();
            this.PatientDischargeInstructions = new List<PatientDischargeInstructionModel>();
            this.ProviderStateLicense = new List<ProviderStateLicenseModel>();
            this.ProviderWhoIsWho = new List<ProviderWhoIsWhoModel>();
            this.ProviderAwardsAndRecognition = new List<ProviderAwardsAndRecognitionModel>();
            this.PatientDiagnosticImagings = new List<PatientDiagnosticImagingModel>();
            this.PatientDiagnosticImagings1 = new List<PatientDiagnosticImagingModel>();
            this.PatientLabOrderTests = new List<PatientLabOrderTestModel>();
            this.PatientLabOrderTests1 = new List<PatientLabOrderTestModel>();
            this.PatientProcedures = new List<PatientProcedureModel>();
            this.PatientReferrals = new List<PatientReferralModel>();
        }

        #region Model Properties
        public int ProviderID { get; set; }
        public string NPI { get; set; }
        public string TaxID { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public string Credential { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<int> GenderID { get; set; }
        public string MedicareID { get; set; }
        public string UPIN { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string BillingAddressLine1 { get; set; }
        public string BillingAddressLine2 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCounty { get; set; }
        public string BillingZIP { get; set; }
        public string BillingCountry { get; set; }
        public bool IsActive { get; set; }
        public bool SubscriptionFlag { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsSameAsMailingAddress { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public Nullable<int> PreferredLanguageID { get; set; }
        public string MothersMaidenName { get; set; }
        public string MedicaidID { get; set; }
        public string WebsiteName { get; set; }
        //Foreign Address Implementation Properties
        public bool IsForeign { get; set; }
        public bool IsBillingForeign { get; set; }
        public int FeeScheduleToUse { get; set; }
        public string FeeScheduleDescription { get; set; }
        #endregion

        #region Reference Properties
        public virtual ICollection<ClaimModel> Claims { get; set; }
        public virtual ICollection<NurseDiagnosiModel> NurseDiagnosis { get; set; }
        public virtual ICollection<PatientAppointmentModel> PatientAppointments { get; set; }
        public virtual ICollection<PatientEncounterModel> PatientEncounters { get; set; }
        public virtual ICollection<ProviderAddressModel> ProviderAddresses { get; set; }
        public virtual ICollection<ProviderDiagnosisCodeModel> ProviderDiagnosisCodes { get; set; }
        public virtual ICollection<ProviderFeeScheduleModel> ProviderFeeSchedules { get; set; }
        public virtual ICollection<ProviderInsuranceModel> ProviderInsurances { get; set; }
        public virtual ICollection<ProviderLocationModel> ProviderLocations { get; set; }
        public virtual ICollection<ProviderLocationTimingModel> ProviderLocationTimings { get; set; }
        public virtual ICollection<ProviderSpecialityModel> ProviderSpecialities { get; set; }
        public virtual ICollection<ProviderTreatmentCodeModel> ProviderTreatmentCodes { get; set; }
        public virtual ICollection<ProviderVacationModel> ProviderVacations { get; set; }
        public virtual ICollection<SuperBillModel> SuperBills { get; set; }
        public virtual ICollection<SuperBillTreatmentModel> SuperBillTreatments { get; set; }
        public virtual ICollection<PatientDischargeInstructionModel> PatientDischargeInstructions { get; set; }
        public virtual ICollection<ProviderStateLicenseModel> ProviderStateLicense { get; set; }
        public virtual ICollection<ProviderWhoIsWhoModel> ProviderWhoIsWho { get; set; }
        public virtual ICollection<ProviderAwardsAndRecognitionModel> ProviderAwardsAndRecognition { get; set; }
        public virtual ICollection<PatientDiagnosticImagingModel> PatientDiagnosticImagings { get; set; }
        public virtual ICollection<PatientDiagnosticImagingModel> PatientDiagnosticImagings1 { get; set; }
        public virtual ICollection<PatientLabOrderTestModel> PatientLabOrderTests { get; set; }
        public virtual ICollection<PatientLabOrderTestModel> PatientLabOrderTests1 { get; set; }
        public virtual ICollection<PatientProcedureModel> PatientProcedures { get; set; }
        public virtual ICollection<PatientReferralModel> PatientReferrals { get; set; }
        #endregion

        #region Search Properties
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion

        #region Custom Properties
        public string GroupFacilityName { get; set; }
        public string ProviderTitle { get; set; }
        public string ProviderAddressTitle { get; set; }
        public string BillingAddressTitle { get; set; }
        public string Gender { get; set; }
        public int FacilityID { get; set; }
        public string CountryName { get; set; }
        public string BillingCountryName { get; set; }
        public string Picture { get; set; }
        public string ProviderName { get; set; }
        public string FacilityAndProvider { get; set; }
        public Nullable<int> FacilityAndProviderID { get; set; }
        public string PreferredLanguage { get; set; }
        public string LanguageDescription { get; set; }
        public string BillingPhone { get; set; }
        public bool IsImageAvailable { get; set; }
        public byte[] Signature { get; set; }
        public string ProviderSignature { get; set; }
        public bool IsSignatureAvailable { get; set; }
        public bool IsSignatureChanged { get; set; }
        public bool IsImageChanged { get; set; }
        public string IsSearch { get; set; }

        //use Foreign Address
        public string CommunicationState { get; set; }
        public string CommunicationZIP { get; set; }

        public string BillingForeignState { get; set; }
        public string BillingForeignZIP { get; set; }


        #endregion

        #region portal properties


        public string BirthDateAsString { get; set; }

        public string Specialities { get; set; }

        public int UserID { get; set; }
        public string CompanyName { get; set; }

        public string Location { get; set; }

        public string Insurance { get; set; }

        public string Vacation { get; set; }
        public string StateLicenseNumber { get; set; }
        public string WhoIsWho { get; set; }
        public string AwardsAndRecognition { get; set; }

    }
}