using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace provider.Enitity_Model
{
    public class Patient
    {
        public Patient()
        {
            this.CapitationPatients = new List<CapitationPatient>();
            this.Claims = new List<Claim>();
            this.ClaimAppeals = new List<ClaimAppeal>();
            this.ClaimPaymentDetails = new List<ClaimPaymentDetail>();
            this.PatientAddresses = new List<PatientAddress>();
            this.PatientAllergies = new List<PatientAllergy>();
            this.PatientAppointments = new List<PatientAppointment>();
            this.PatientBeneficiaries = new List<PatientBeneficiary>();
            this.PatientClinicalNoteses = new List<PatientClinicalNotes>();
            this.PatientContactPersons = new List<PatientContactPerson>();
            this.PatientDocuments = new List<PatientDocument>();
            this.PatientEligibilities = new List<PatientEligibility>();
            this.PatientEmployers = new List<PatientEmployer>();
            this.PatientEncounters = new List<PatientEncounter>();
            this.PatientFamilies = new List<PatientFamily>();
            this.PatientInsurances = new List<PatientInsurance>();
            this.PatientMedications = new List<PatientMedication>();
            this.PatientNotes = new List<PatientNote>();
            this.PatientTrackings = new List<PatientTracking>();
            this.PatientTransactions = new List<PatientTransaction>();
            this.PatientWorkHistories = new List<PatientWorkHistory>();
            this.SuperBills = new List<SuperBill>();
            this.VisitNotes = new List<VisitNote>();
            this.VitalSigns = new List<VitalSign>();
            this.PatientTobaccoAlcoholHistories = new List<PatientTobaccoAlcoholHistory>();
            this.Payments = new List<Payment>();
            this.PatientLedgers = new List<PatientLedger>();
            this.PatientDischargeInstructions = new List<PatientDischargeInstruction>();
            this.PatientDiagnosticImagings = new List<PatientDiagnosticImaging>();
            this.PatientLabOrderTests = new List<PatientLabOrderTest>();
            this.PatientProcedures = new List<PatientProcedure>();
            this.PatientReferrals = new List<PatientReferral>();
            this.PatientRegistrations = new List<PatientRegistration>();
        }

        #region Model Properities
        public int PatientID { get; set; }
        public string PatientSSN { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public Nullable<int> GenderID { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<int> MaritalStatusID { get; set; }
        public string RaceID { get; set; }
        public Nullable<int> EthnicityID { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public string Email { get; set; }
        public string MailAddressLine1 { get; set; }
        public string MailAddressLine2 { get; set; }
        public string MailCity { get; set; }
        public string MailState { get; set; }
        public string MailCounty { get; set; }
        public string MailZIP { get; set; }
        public string MailCountry { get; set; }
        public bool IsActive { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string PatientAccountNumber { get; set; }
        public Nullable<int> SalutationID { get; set; }
        public string DrivingLicenseNo { get; set; }
        public string PassportNo { get; set; }
        public bool IsPhotoAvail { get; set; }
        public bool IsSameAsBillingAddress { get; set; }
        public Nullable<System.DateTime> DeathDate { get; set; }
        public string CauseOfDeath { get; set; }
        public Nullable<int> PreferredLanguageID { get; set; }
        public string MothersMaidenNameLast { get; set; }
        public string MothersMaidenNameFirst { get; set; }
        public string MedicalRecordNumber { get; set; }
        public string OtherLanguage { get; set; }
        public string OtherRace { get; set; }
        public string OtherEthnicity { get; set; }
        public string BloodTypeCode { get; set; }
        public Nullable<int> CommunicationPreferenceID { get; set; }

        public int SyndromicRecordSendStatus { get; set; }

        public string ADTType { get; set; }


        // public bool IsInEmdeon { get; set; }
        public DateTime? AddressEffectiveDate { get; set; }
        public DateTime? AddressTermDate { get; set; }

        //Foreign Address Implementation Properties
        public bool IsForeign { get; set; }
        public bool MailIsForeign { get; set; }


        public Nullable<int> ExternalPatientId { get; set; }
        #endregion

        #region Reference Properities
        public virtual ICollection<CapitationPatient> CapitationPatients { get; set; }
        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<ClaimAppeal> ClaimAppeals { get; set; }
        public virtual ICollection<ClaimPaymentDetail> ClaimPaymentDetails { get; set; }
        public virtual Ethnicity Ethnicity { get; set; }
        public virtual BloodType BloodType { get; set; }

        public virtual RegionalLanguage RegionalLanguage { get; set; }
        public virtual ICollection<PatientAddress> PatientAddresses { get; set; }
        //public virtual Race Race { get; set; }
        public virtual ICollection<PatientAllergy> PatientAllergies { get; set; }
        public virtual ICollection<PatientAppointment> PatientAppointments { get; set; }
        public virtual ICollection<PatientBeneficiary> PatientBeneficiaries { get; set; }
        public virtual ICollection<PatientClinicalNotes> PatientClinicalNoteses { get; set; }
        public virtual ICollection<PatientContactPerson> PatientContactPersons { get; set; }
        public virtual ICollection<PatientDocument> PatientDocuments { get; set; }
        public virtual ICollection<PatientEligibility> PatientEligibilities { get; set; }
        public virtual ICollection<PatientEmployer> PatientEmployers { get; set; }
        public virtual ICollection<PatientEncounter> PatientEncounters { get; set; }
        public virtual ICollection<PatientFamily> PatientFamilies { get; set; }
        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }
        public virtual ICollection<PatientMedication> PatientMedications { get; set; }
        public virtual ICollection<PatientNote> PatientNotes { get; set; }
        public virtual ICollection<PatientTracking> PatientTrackings { get; set; }
        public virtual ICollection<PatientTransaction> PatientTransactions { get; set; }
        public virtual ICollection<PatientWorkHistory> PatientWorkHistories { get; set; }
        public virtual ICollection<SuperBill> SuperBills { get; set; }
        public virtual ICollection<VisitNote> VisitNotes { get; set; }
        public virtual ICollection<VitalSign> VitalSigns { get; set; }
        public virtual ICollection<EPrescription> EPrescriptions { get; set; }
        public virtual ICollection<PatientTobaccoAlcoholHistory> PatientTobaccoAlcoholHistories { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<PatientLedger> PatientLedgers { get; set; }
        public virtual ICollection<PatientDischargeInstruction> PatientDischargeInstructions { get; set; }
        public virtual ICollection<PatientDiagnosticImaging> PatientDiagnosticImagings { get; set; }
        public virtual ICollection<PatientLabOrderTest> PatientLabOrderTests { get; set; }
        public virtual ICollection<PatientProcedure> PatientProcedures { get; set; }
        public virtual ICollection<PatientReferral> PatientReferrals { get; set; }
        public virtual ICollection<PatientRegistration> PatientRegistrations { get; set; }

        #endregion
    }
}