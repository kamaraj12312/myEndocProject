using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class InsuranceCompanyModel
    {
        public InsuranceCompanyModel()
        {
            this.CapitationSetups = new List<CapitationSetupModel>();
            this.ClaimAppeals = new List<ClaimAppealModel>();
            this.InsuranceCompanyContactPersons = new List<InsuranceCompanyContactPersonModel>();
            this.InsuranceCompanyEDIDetails = new List<InsuranceCompanyEDIDetailModel>();
            this.PatientEligibilities = new List<PatientEligibilityModel>();
            this.PatientInsurances = new List<PatientInsuranceModel>();
            this.ProviderInsurances = new List<ProviderInsuranceModel>();
            this.Payments = new List<PaymentModel>();

        }
        #region ModelProperties
        public int InsuranceCompanyID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationID { get; set; }
        public int InsuranceCategoryID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public string Telephone { get; set; }
        public string AlternatePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonTitle { get; set; }
        public string ContactPersonPhone { get; set; }
        public string ContactPersonWorkPhone { get; set; }
        public string ContactPersonFax { get; set; }
        public string ContactPersonEmail { get; set; }
        public string PrimaryTransmissionMode { get; set; }
        public string SecondaryTransmissionMode { get; set; }
        public string TertiaryTransmissionMode { get; set; }
        public string InsuredSignatureOnFile { get; set; }
        public string PhysicianSignatureOnFile { get; set; }

        #endregion

        #region Search Properties
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        public Nullable<int> SearchInsuranceCategoryID { get; set; }
        public string SearchOrganizationName { get; set; }
        public string SearchCity { get; set; }
        public string SearchState { get; set; }
        public string SearchZIP { get; set; }

        #endregion

        #region RefranceProperties
        public virtual ICollection<CapitationSetupModel> CapitationSetups { get; set; }
        public virtual ICollection<ClaimAppealModel> ClaimAppeals { get; set; }
        public virtual InsuranceCategoryModel InsuranceCategory { get; set; }
        public virtual ICollection<InsuranceCompanyContactPersonModel> InsuranceCompanyContactPersons { get; set; }
        public virtual ICollection<InsuranceCompanyEDIDetailModel> InsuranceCompanyEDIDetails { get; set; }
        public virtual ICollection<PatientEligibilityModel> PatientEligibilities { get; set; }
        public virtual ICollection<PatientInsuranceModel> PatientInsurances { get; set; }
        public virtual ICollection<ProviderInsuranceModel> ProviderInsurances { get; set; }
        public virtual ICollection<ClaimReceiptModel> ClaimReceipts { get; set; }
        public virtual ICollection<PaymentModel> Payments { get; set; }


        #endregion

        #region CustomProperties
        public string InsuranceCategoryName { get; set; }
        public string InsuranceCompanyTitle { get; set; }
        public string CountryName { get; set; }
        public string InsuranceContactPersonTitle { get; set; }
        public string IsSearch { get; set; }
        public string InsuranceCompanyNameAndOrganizationID { get; set; }
        public string BillingInformationTitle { get; set; }
        #endregion
    }
}