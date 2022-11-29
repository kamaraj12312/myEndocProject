using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace provider.Enitity_Model
{
    public class Facility
    {
        public Facility()
        {
            this.Claims = new List<Claim>();
            this.FacilityDiagnosisCodes = new List<FacilityDiagnosisCode>();
            this.FacilityTreatmentCodes = new List<FacilityTreatmentCode>();
            this.PatientAppointments = new List<PatientAppointment>();
            this.PatientEncounters = new List<PatientEncounter>();
            this.ProviderLocations = new List<ProviderLocation>();
            this.SuperBills = new List<SuperBill>();
            this.SchedulerSetups = new List<SchedulerSetup>();
            this.HolidaySetups = new List<HolidaySetup>();
            this.PatientDischargeInstructions = new List<PatientDischargeInstruction>();
            this.PatientDiagnosticImagings = new List<PatientDiagnosticImaging>();
            this.PatientLabOrderTests = new List<PatientLabOrderTest>();
            this.PatientProcedures = new List<PatientProcedure>();
            this.PatientReferrals = new List<PatientReferral>();
        }
        #region Model Properties
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
        public bool IsForeign { get; set; }
        #endregion
        #region Reference Properties
        public virtual ICollection<Claim> Claims { get; set; }
        public virtual GroupFacility GroupFacility { get; set; }
        public virtual ICollection<FacilityDiagnosisCode> FacilityDiagnosisCodes { get; set; }
        public virtual ICollection<FacilityTreatmentCode> FacilityTreatmentCodes { get; set; }
        public virtual ICollection<PatientAppointment> PatientAppointments { get; set; }
        public virtual ICollection<PatientEncounter> PatientEncounters { get; set; }
        public virtual ICollection<ProviderLocation> ProviderLocations { get; set; }
        public virtual ICollection<SuperBill> SuperBills { get; set; }
        public virtual ICollection<FacilitySpecialty> FacilitySpecialties { get; set; }
        public virtual ICollection<FacilityInsurance> FacilityInsurances { get; set; }
        public virtual ICollection<SchedulerSetup> SchedulerSetups { get; set; }
        public virtual ICollection<HolidaySetup> HolidaySetups { get; set; }
        public virtual ICollection<PatientDischargeInstruction> PatientDischargeInstructions { get; set; }
        public virtual ICollection<PatientDiagnosticImaging> PatientDiagnosticImagings { get; set; }
        public virtual ICollection<PatientLabOrderTest> PatientLabOrderTests { get; set; }
        public virtual ICollection<PatientProcedure> PatientProcedures { get; set; }
        public virtual ICollection<PatientReferral> PatientReferrals { get; set; }
    }
}