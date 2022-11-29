using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace provider.Patients
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PatientService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PatientService.svc or PatientService.svc.cs at the Solution Explorer and start debugging.
    public class PatientService : IPatientService
    {
        public IList<PatientModel> GetPatients()
        {
            var query = (from p in _uowPatientService.Repository<Patient>().Table
                         where p.Deleted == false
                         orderby p.NameFirst
                         select new
                         {
                             PatientID = p.PatientID,
                             PatientSSN = p.PatientSSN,
                             NameLast = p.NameLast,
                             NameFirst = p.NameFirst,
                             NameMiddle = p.NameMiddle,
                             NamePrefix = p.NamePrefix,
                             NameSuffix = p.NameSuffix,
                             GenderID = p.GenderID,
                             BirthDate = p.BirthDate,
                             MaritalStatusID = p.MaritalStatusID,
                             RaceID = p.RaceID,
                             EthnicityID = p.EthnicityID,
                             LanguageID = p.LanguageID,
                             AddressLine1 = p.AddressLine1,
                             AddressLine2 = p.AddressLine2,
                             City = p.City,
                             State = p.State,
                             County = p.County,
                             ZIP = p.ZIP,
                             Country = p.County,
                             Phone = p.Phone,
                             AlternatePhone = p.AlternatePhone,
                             Email = p.Email,
                             MailAddressLine1 = p.MailAddressLine1,
                             MailAddressLine2 = p.MailAddressLine2,
                             MailCity = p.MailCity,
                             MailState = p.MailState,
                             MailCounty = p.MailCounty,
                             MailZIP = p.MailZIP,
                             MailCountry = p.MailCountry,
                             IsActive = p.IsActive,
                             PassportNo = p.PassportNo,
                             DrivingLicenseNo = p.DrivingLicenseNo,
                             Deleted = p.Deleted,
                             CreatedDate = p.CreatedDate,
                             CreatedBy = p.CreatedBy,
                             ModifiedDate = p.ModifiedDate,
                             ModifiedBy = p.ModifiedBy,
                             PatientAccountNumber = p.PatientAccountNumber,
                             SalutationID = p.SalutationID,
                             DeathDate = p.DeathDate,
                             CauseOfDeath = p.CauseOfDeath,
                             PreferredLanguageID = p.PreferredLanguageID,
                             MothersMaidenNameFirst = p.MothersMaidenNameFirst,
                             MothersMaidenNameLast = p.MothersMaidenNameLast,
                             MedicalRecordNumber = p.MedicalRecordNumber
                         }).AsEnumerable()
                           .Select(x => new PatientModel
                           {
                               PatientID = x.PatientID,
                               PatientSSN = BmsCommonUtility.FormatStrings(x.PatientSSN, BmsCommonUtility.FormatStringTypes.SSNGrid),
                               NameLast = x.NameLast,
                               NameFirst = x.NameFirst,
                               NameMiddle = x.NameMiddle,
                               NamePrefix = x.NamePrefix,
                               NameSuffix = x.NameSuffix,
                               GenderID = x.GenderID,
                               BirthDate = x.BirthDate,
                               MaritalStatusID = x.MaritalStatusID,
                               RaceID = x.RaceID,
                               EthnicityID = x.EthnicityID,
                               LanguageID = x.LanguageID,
                               AddressLine1 = x.AddressLine1,
                               AddressLine2 = x.AddressLine2,
                               City = x.City,
                               State = x.State,
                               County = x.County,
                               ZIP = BmsCommonUtility.FormatStrings(x.ZIP, BmsCommonUtility.FormatStringTypes.Zip),
                               Country = x.County,
                               Phone = BmsCommonUtility.FormatStrings(x.Phone, BmsCommonUtility.FormatStringTypes.Phone),
                               AlternatePhone = BmsCommonUtility.FormatStrings(x.AlternatePhone, BmsCommonUtility.FormatStringTypes.Phone),
                               Email = x.Email,
                               MailAddressLine1 = x.MailAddressLine1,
                               MailAddressLine2 = x.MailAddressLine2,
                               MailCity = x.MailCity,
                               MailState = x.MailState,
                               MailCounty = x.MailCounty,
                               MailZIP = x.MailZIP,
                               MailCountry = x.MailCountry,
                               IsActive = x.IsActive,
                               PassportNo = x.PassportNo,
                               DrivingLicenseNo = x.DrivingLicenseNo,
                               Deleted = x.Deleted,
                               CreatedDate = x.CreatedDate,
                               CreatedBy = x.CreatedBy,
                               ModifiedDate = x.ModifiedDate,
                               ModifiedBy = x.ModifiedBy,
                               PatientAccountNumber = x.PatientAccountNumber,
                               SalutationID = x.SalutationID,
                               DeathDate = x.DeathDate,
                               CauseOfDeath = x.CauseOfDeath,
                               PreferredLanguageID = x.PreferredLanguageID,
                               MothersMaidenNameFirst = x.MothersMaidenNameFirst,
                               MothersMaidenNameLast = x.MothersMaidenNameLast,
                               MedicalRecordNumber = x.MedicalRecordNumber,
                               Age = x.BirthDate == null ? string.Empty : BmsCommonUtility.GetAgeByDateOfBirth(Convert.ToDateTime(x.BirthDate)),
                           });
            var patients = query.ToList();
            return patients;
        }
        public IList<PatientInsuranceModel> getBillingMethodDescription()
        {
            var billing = (from bim in _uowPatientService.Repository<ClaimFillingIndicator>().Table
                           where (!bim.Deleted)
                           select new PatientInsuranceModel
                           {
                               BillingMethodID = bim.Code,
                               BillingMethodDescription = bim.Description
                           }
                ).ToList();
            return billing;
        }
    }
}
