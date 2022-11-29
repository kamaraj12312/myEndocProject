using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class PatientModel
    {
        public PatientModel()
        {
            this.IsActive = true;
            this.CapitationPatients = new List<CapitationPatientModel>();
            this.Claims = new List<ClaimModel>();
            this.ClaimAppeals = new List<ClaimAppealModel>();
            this.ClaimPaymentDetails = new List<ClaimPaymentDetailModel>();
            this.PatientAddresses = new List<PatientAddressModel>();
            this.PatientAllergies = new List<PatientAllergyModel>();
            this.PatientAppointments = new List<PatientAppointmentModel>();
            this.PatientBeneficiaries = new List<PatientBeneficiaryModel>();
            this.PatientClinicalNoteses = new List<PatientClinicalNotesModel>();
            this.PatientContactPersons = new List<PatientContactPersonModel>();
            this.PatientDocuments = new List<PatientDocumentModel>();
            this.PatientEligibilities = new List<PatientEligibilityModel>();
            this.PatientEmployers = new List<PatientEmployerModel>();
            this.PatientEncounters = new List<PatientEncounterModel>();
            this.PatientFamilies = new List<PatientFamilyModel>();
            this.PatientInsurances = new List<PatientInsuranceModel>();
            this.PatientMedications = new List<PatientMedicationModel>();
            this.PatientNotes = new List<PatientNoteModel>();
            this.PatientTrackings = new List<PatientTrackingModel>();
            this.PatientWorkHistories = new List<PatientWorkHistoryModel>();
            this.SuperBills = new List<SuperBillModel>();
            this.VisitNotes = new List<VisitNoteModel>();
            this.VitalSigns = new List<VitalSignModel>();
            this.Payments = new List<PaymentModel>();
            this.PatientDischargeInstructions = new List<PatientDischargeInstructionModel>();
            this.PatientDiagnosticImagings = new List<PatientDiagnosticImagingModel>();
            this.PatientLabOrderTests = new List<PatientLabOrderTestModel>();
            this.PatientProcedures = new List<PatientProcedureModel>();
            this.PatientReferrals = new List<PatientReferralModel>();
        }

        DateTime _birthDate;
        #region Model Properties
        public int PatientID { get; set; }
        public int BloodTypeID { get; set; }
        public string PatientSSN { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public Nullable<int> GenderID { get; set; }
        public Nullable<System.DateTime> BirthDate
        {
            get; set;

        }
        public Nullable<int> MaritalStatusID { get; set; }
        public string RaceID { get; set; }
        public Nullable<int> EthnicityID { get; set; }
        public Nullable<int> LanguageID { get; set; }
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
        public Nullable<System.DateTime> DeathDate { get; set; }
        public string CauseOfDeath { get; set; }
        public Nullable<int> PreferredLanguageID { get; set; }
        public string MothersMaidenNameLast { get; set; }
        public string MothersMaidenNameFirst { get; set; }
        public string MedicalRecordNumber { get; set; }
        public int SyndromicRecordSendStatus { get; set; }
        public string ADTType { get; set; }
        public DateTime? AddressEffectiveDate { get; set; }
        public DateTime? AddressTermDate { get; set; }

        //Foreign Address Implementation Properties
        public bool IsForeign { get; set; }
        public bool MailIsForeign { get; set; }

        public Nullable<int> ExternalPatientId { get; set; }

        #endregion

        #region Reference Properities
        public virtual ICollection<CapitationPatientModel> CapitationPatients { get; set; }
        public virtual ICollection<ClaimModel> Claims { get; set; }
        public virtual ICollection<ClaimAppealModel> ClaimAppeals { get; set; }
        public virtual ICollection<ClaimPaymentDetailModel> ClaimPaymentDetails { get; set; }
        public virtual EthnicityModel Ethnicity { get; set; }
        public virtual RegionalLanguageModel RegionalLanguage { get; set; }
        public virtual ICollection<PatientAddressModel> PatientAddresses { get; set; }
        public virtual RaceModel Race { get; set; }
        public virtual ICollection<PatientAllergyModel> PatientAllergies { get; set; }
        public virtual ICollection<PatientAppointmentModel> PatientAppointments { get; set; }
        public virtual ICollection<PatientBeneficiaryModel> PatientBeneficiaries { get; set; }
        public virtual ICollection<PatientClinicalNotesModel> PatientClinicalNoteses { get; set; }
        public virtual ICollection<PatientContactPersonModel> PatientContactPersons { get; set; }
        public virtual ICollection<PatientDocumentModel> PatientDocuments { get; set; }
        public virtual ICollection<PatientEligibilityModel> PatientEligibilities { get; set; }
        public virtual ICollection<PatientEmployerModel> PatientEmployers { get; set; }
        public virtual ICollection<PatientEncounterModel> PatientEncounters { get; set; }
        public virtual ICollection<PatientFamilyModel> PatientFamilies { get; set; }
        public virtual ICollection<PatientInsuranceModel> PatientInsurances { get; set; }
        public virtual ICollection<PatientMedicationModel> PatientMedications { get; set; }
        public virtual ICollection<PatientNoteModel> PatientNotes { get; set; }
        public virtual ICollection<PatientTrackingModel> PatientTrackings { get; set; }
        public virtual ICollection<PatientWorkHistoryModel> PatientWorkHistories { get; set; }
        public virtual ICollection<SuperBillModel> SuperBills { get; set; }
        public virtual ICollection<VisitNoteModel> VisitNotes { get; set; }
        public virtual ICollection<VitalSignModel> VitalSigns { get; set; }
        public virtual ICollection<PaymentModel> Payments { get; set; }
        public virtual ICollection<PatientDischargeInstructionModel> PatientDischargeInstructions { get; set; }
        public virtual ICollection<PatientDiagnosticImagingModel> PatientDiagnosticImagings { get; set; }
        public virtual ICollection<PatientLabOrderTestModel> PatientLabOrderTests { get; set; }
        public virtual ICollection<PatientProcedureModel> PatientProcedures { get; set; }
        public virtual ICollection<PatientReferralModel> PatientReferrals { get; set; }

        #endregion

        #region Custom Properties
        public string BloodTypeCode { get; set; }
        public string BloodTypeDescription { get; set; }

        public string GenderDescription { get; set; }
        public string MaritalStatusDescription { get; set; }
        public string RaceDescription { get; set; }
        public string EthnicityDescription { get; set; }
        public string LanguageDescription { get; set; }
        public string SalutationDescription { get; set; }
        public string PatientTitle { get; set; }
        public string PatientAddressTitle { get; set; }
        public string PatientBillingAddressTitle { get; set; }
        public string Age { get; set; }
        public bool IsSameAsBillingAddress { get; set; }
        public string CountryName { get; set; }
        public string MailCountryName { get; set; }
        public string Picture { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string PatientName { get; set; }
        public int PatientFamilyID { get; set; }
        public string Status { get; set; }
        public string PreferredLanguage { get; set; }
        public bool IsImageAvailable { get; set; }

        public string OtherLanguage { get; set; }
        public string OtherRace { get; set; }
        public string OtherEthnicity { get; set; }
        public string SelectedRace { get; set; }

        public int UserID { get; set; }

        public string BirthDateAsString { get; set; }
        public string DeathDateAsString { get; set; }

        public bool PatientInformation { get; set; }
        public bool PatientInsurance { get; set; }
        public bool VitalInformation { get; set; }
        public bool Medication { get; set; }
        public bool Allergy { get; set; }
        public bool MedicalHistory { get; set; }

        public bool SocialHistory { get; set; }
        public bool FamilyHealthHistory { get; set; }
        public bool Family { get; set; }
        public bool WorkHistory { get; set; }
        public bool EdiclaimDetails { get; set; }
        public bool DischargeInsutruction { get; set; }
        public bool Document { get; set; }
        public bool IsAdvanced { get; set; }

        public bool PatientImmunization { get; set; }
        public bool PatientEducation { get; set; }
        public bool LabResults { get; set; }
        public byte[] Signature { get; set; }
        public string PatientSignature { get; set; }
        public bool IsSignatureAvailable { get; set; }
        public bool IsSignatureChanged { get; set; }
        public bool IsImageChanged { get; set; }
        public string RxURLText { get; set; }
        public string EthnicityCode { get; set; }
        public string RaceCode { get; set; }
        public bool IsFromEmdeon { get; set; }

        public bool CommonicationMode { get; set; }

        public Nullable<int> CommunicationPreferenceID { get; set; }
        public string CommunicationPreferenceDescription { get; set; }
        public string IsSearch { get; set; }
        public Nullable<int> OtherEthnicityID { get; set; }
        public Nullable<int> OtherRaceID { get; set; }
        public string OtherLanguageDescription { get; set; }
        public int PatientAlertCount { get; set; }
        public int AlertID { get; set; }
        public string PatientAddress { get; set; }
        public int PatientAddressCount { get; set; }

        public Nullable<int> CDSPatientAge { get; set; }
        public string CDSMessage { get; set; }
        public string TempDataName { get; set; }

        //use Foreign Address
        public string CommunicationState { get; set; }
        public string CommunicationZIP { get; set; }

        public string BillingState { get; set; }
        public string BillingZIP { get; set; }


        #endregion

        #region Search Properties
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion
    }
}