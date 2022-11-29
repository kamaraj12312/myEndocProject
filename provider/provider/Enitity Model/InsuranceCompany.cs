using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class InsuranceCompany
    {
        public InsuranceCompany()
        {
            this.CapitationSetups = new List<CapitationSetup>();
            this.ClaimAppeals = new List<ClaimAppeal>();
            this.InsuranceCompanyContactPersons = new List<InsuranceCompanyContactPerson>();
            this.InsuranceCompanyEDIDetails = new List<InsuranceCompanyEDIDetail>();
            this.PatientEligibilities = new List<PatientEligibility>();
            this.PatientInsurances = new List<PatientInsurance>();
            this.ProviderInsurances = new List<ProviderInsurance>();
            this.FacilityInsurances = new List<FacilityInsurance>();
            this.ClaimReceipts = new List<ClaimReceipt>();
            this.Payments = new List<Payment>();
            this.PatientLedgers = new List<PatientLedger>();
        }

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
        public virtual ICollection<CapitationSetup> CapitationSetups { get; set; }
        public virtual ICollection<ClaimAppeal> ClaimAppeals { get; set; }
        public virtual InsuranceCategory InsuranceCategory { get; set; }
        public virtual ICollection<InsuranceCompanyContactPerson> InsuranceCompanyContactPersons { get; set; }
        public virtual ICollection<InsuranceCompanyEDIDetail> InsuranceCompanyEDIDetails { get; set; }
        public virtual ICollection<PatientEligibility> PatientEligibilities { get; set; }
        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }
        public virtual ICollection<ProviderInsurance> ProviderInsurances { get; set; }
        public virtual ICollection<ClaimReceipt> ClaimReceipts { get; set; }
        public virtual ICollection<FacilityInsurance> FacilityInsurances { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<PatientLedger> PatientLedgers { get; set; }
    }
}