using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class FacilityModel
    {
        public FacilityModel()
        {
            this.Claims = new List<ClaimModel>();
            this.CustomTreatmentCodes = new List<CustomTreatmentCodeModel>();
            this.FacilityDiagnosisCodes = new List<FacilityDiagnosisCodeModel>();
            this.FacilityTreatmentCodes = new List<FacilityTreatmentCodeModel>();
            this.PatientAppointments = new List<PatientAppointmentModel>();
            this.PatientEncounters = new List<PatientEncounterModel>();
            this.ProviderLocations = new List<ProviderLocationModel>();
            this.SuperBills = new List<SuperBillModel>();
            this.SchedulerSetups = new List<SchedulerSetupModel>();
            this.HolidaySetups = new List<HolidaySetupModel>();
            this.PatientDischargeInstructions = new List<PatientDischargeInstructionModel>();
            this.PatientDiagnosticImagings = new List<PatientDiagnosticImagingModel>();
            this.PatientLabOrderTests = new List<PatientLabOrderTestModel>();
            this.PatientProcedures = new List<PatientProcedureModel>();
            this.PatientReferrals = new List<PatientReferralModel>();
        }
        #region ModelProperties

        public int FacilityID { get; set; }
        public Nullable<int> GroupFacilityID { get; set; }
        public string NPI { get; set; }
        public string TaxID { get; set; }
        public string FacilityName { get; set; }
        public string OtherName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string AlternatePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int BillingLocation { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string IsSearch { get; set; }
        //Foreign Address Implementation Properties
        public bool IsForeign { get; set; }

        #endregion

        #region Reference Properties
        public List<ConfigurationPropertiesModel> ConfigurationPropertiesList { get; set; }
        public virtual ICollection<ClaimModel> Claims { get; set; }
        public virtual ICollection<CustomTreatmentCodeModel> CustomTreatmentCodes { get; set; }
        public virtual GroupFacilityModel GroupFacility { get; set; }
        public virtual ICollection<FacilityDiagnosisCodeModel> FacilityDiagnosisCodes { get; set; }
        public virtual ICollection<FacilityTreatmentCodeModel> FacilityTreatmentCodes { get; set; }
        public virtual ICollection<PatientAppointmentModel> PatientAppointments { get; set; }
        public virtual ICollection<PatientEncounterModel> PatientEncounters { get; set; }
        public virtual ICollection<ProviderLocationModel> ProviderLocations { get; set; }
        public virtual ICollection<SuperBillModel> SuperBills { get; set; }
        public virtual ICollection<HolidaySetupModel> HolidaySetups { get; set; }
        public virtual ICollection<SchedulerSetupModel> SchedulerSetups { get; set; }
        public virtual ICollection<PatientDischargeInstructionModel> PatientDischargeInstructions { get; set; }
        public virtual ICollection<PatientDiagnosticImagingModel> PatientDiagnosticImagings { get; set; }
        public virtual ICollection<PatientLabOrderTestModel> PatientLabOrderTests { get; set; }
        public virtual ICollection<PatientProcedureModel> PatientProcedures { get; set; }
        public virtual ICollection<PatientReferralModel> PatientReferrals { get; set; }
        #endregion

        #region Custom Properties
        public string FacilityTitle { get; set; }
        public string BillingDescriptions { get; set; }
        public string CountryName { get; set; }
        public string FacilityAndProvider { get; set; }
        public Nullable<int> FacilityAndProviderID { get; set; }
        public string BillingPhone { get; set; }
        public bool IsImageAvailable { get; set; }
        public string SchedulerStartTime { get; set; }
        public string SchedulerEndTime { get; set; }

        //use Foreign Address
        public string CommunicationState { get; set; }
        public string CommunicationZIP { get; set; }

        #endregion

        #region Search Properties
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
    }
}