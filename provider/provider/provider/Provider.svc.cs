using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace provider
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Provider" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Provider.svc or Provider.svc.cs at the Solution Explorer and start debugging.
    public class Provider : IProvider
    {
        public IList<ProviderModel> GetProviders()
        {
            var query = from p in _uowProviderService.Repository<Provider>().Table
                        where p.Deleted == false
                        orderby p.NameFirst
                        select new ProviderModel
                        {
                            ProviderID = p.ProviderID,
                            NPI = p.NPI,
                            TaxID = p.TaxID,
                            NameLast = p.NameLast,
                            NameFirst = p.NameLast + ", " + p.NameFirst + (p.NameMiddle == null ? "" : " " + p.NameMiddle),
                            NameMiddle = p.NameMiddle,
                            NamePrefix = p.NamePrefix,
                            NameSuffix = p.NameSuffix,
                            Credential = p.Credential,
                            Title = p.Title,
                            BirthDate = p.BirthDate,
                            GenderID = p.GenderID,
                            MedicareID = p.MedicareID,
                            UPIN = p.UPIN,
                            AddressLine1 = p.AddressLine1,
                            AddressLine2 = p.AddressLine2,
                            City = p.City,
                            State = p.State,
                            County = p.County,
                            ZIP = p.ZIP,
                            Country = p.Country,
                            Phone = p.Phone,
                            AlternatePhone = p.AlternatePhone,
                            Fax = p.Fax,
                            Email = p.Email,
                            BillingAddressLine1 = p.BillingAddressLine1,
                            BillingAddressLine2 = p.BillingAddressLine2,
                            BillingCity = p.BillingCity,
                            BillingState = p.BillingState,
                            BillingCounty = p.BillingCounty,
                            BillingZIP = p.BillingZIP,
                            BillingCountry = p.BillingCountry,
                            IsActive = p.IsActive,
                            Deleted = p.Deleted,
                            CreatedDate = p.CreatedDate,
                            CreatedBy = p.CreatedBy,
                            ModifiedDate = p.ModifiedDate,
                            ModifiedBy = p.ModifiedBy
                        };
            var providers = query.ToList();
            return providers;
        }

        public IList<InsuranceCompanyModel> GetInsuranceCompany()
        {
            var query = from ic in _uowProviderService.Repository<InsuranceCompany>().Table
                        where ic.Deleted == false
                        orderby ic.OrganizationName
                        select new InsuranceCompanyModel
                        {
                            InsuranceCompanyID = ic.InsuranceCompanyID,
                            OrganizationName = ic.OrganizationName,
                        };
            var resultInsuranceCompanyList = query.ToList();
            return resultInsuranceCompanyList;
        }




    }
}
