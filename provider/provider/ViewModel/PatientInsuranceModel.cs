using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class PatientInsuranceModel
    {
        public PatientInsuranceModel()
        {
            this.Copay = 0;
        }

        #region Model Properties
        public int PatientInsuranceID { get; set; }
        public int PatientID { get; set; }
        public bool SelfInsured { get; set; }
        public Nullable<int> InsuranceTypeID { get; set; }
        public string BillingMethodID { get; set; }
        public int InsuranceCompanyID { get; set; }
        public Nullable<int> PatientRelationID { get; set; }
        public string SSN { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public Nullable<int> GenderID { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public string Email { get; set; }
        public string GroupName { get; set; }
        public string GroupNumber { get; set; }
        public string PolicyNumber { get; set; }
        public decimal Copay { get; set; }
        public string SubscriberInsuredID { get; set; }
        public string PatientInsuredID { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public Nullable<System.DateTime> EligibilityRequestedDate { get; set; }
        public string EligibilityStatus { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        //Foreign Address Implementation Properties
        public bool IsForeign { get; set; }

        #endregion

        #region Reference Properties
        public virtual ICollection<EncounterInsuranceModel> EncounterInsurances { get; set; }
        public virtual InsuranceCompanyModel InsuranceCompany { get; set; }
        public virtual InsuranceTypeModel InsuranceType { get; set; }
        public virtual PatientModel Patient { get; set; }

        public virtual ICollection<PatientDermatologyModel> PatientDermatologies { get; set; }
        #region Address
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }

        #endregion

        #endregion

        #region Custom Properties
        public string PatientInsuranceTitle { get; set; }
        public string PatientRelation { get; set; }
        public string InsuranceTypeDescription { get; set; }
        public string BillingMethodDescription { get; set; }
        public string OrganizationName { get; set; }
        public string GenderDescription { get; set; }
        public string InsuranceCategoryDescription { get; set; }
        public string OrganizationID { get; set; }
        public string InsuranceAddress1 { get; set; }
        public string InsuranceAddress2 { get; set; }
        public string InsuranceZIP { get; set; }
        public string InsuranceCity { get; set; }
        public string InsuranceState { get; set; }
        public string InsuredorAuthorizedPersonSignature { get; set; }
        public int InsuranceCategoryID { get; set; }
        public int Age { get; set; }
        public string CountryName { get; set; }
        public string SubscriberName { get; set; }
        public string EmdeonSSN { get; set; }
        public string EmdeonRelationCode { get; set; }
        public string RxURLText { get; set; }
        public bool IsFromEmdeon { get; set; }
        public string IsSearch { get; set; }
        //use Foreign Address
        public string CommunicationState { get; set; }
        public string CommunicationZIP { get; set; }
        #endregion

        #region Search Properties
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string SearchInsuranceCompanyName { get; set; }
        #endregion
    }
}