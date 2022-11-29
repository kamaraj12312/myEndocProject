using provider.client;
using provider.Enitity_Model;
using provider.Patient_Model;
using provider.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace provider
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //__________________________EncounterService____________________________
        public void CancelPastWaitingAppointments()
        {
            DateTime date = DateTime.UtcNow.Date;

            var schedulerSetupFacilityIDs = (from ss in _uowEncounterService.Repository<SchedulerSetup>().Table
                                             where !ss.Deleted
                                             && ss.IsCancelPastWaitingOfAppointment == true
                                             && (ss.EffectiveDate <= date && date <= ss.TerminationDate)
                                             select ss.FacilityID).ToList();

            if (schedulerSetupFacilityIDs != null)
            {
                string cancel = clsCommon.GetEnumDescription(clsCommon.AppointmentStatus.Cancel);
                var query = (from pa in _uowEncounterService.Repository<PatientAppointment>().Table
                             where !pa.Deleted
                             && schedulerSetupFacilityIDs.Contains(pa.FacilityID)
                             && pa.IsWaiting
                             && pa.AppointmentStatusCode != cancel
                             && pa.EndTime <= date
                             select new PatientAppointmentModel
                             {
                                 PatientAppointmentID = pa.PatientAppointmentID,
                                 PatientID = pa.PatientID,
                                 FacilityID = pa.FacilityID,
                                 ProviderID = pa.ProviderID,
                                 AppointmentDate = pa.AppointmentDate,
                                 VisitTypeID = pa.VisitTypeID,
                                 StartTime = pa.StartTime,
                                 EndTime = pa.EndTime,
                                 Duration = pa.Duration,
                                 SlotNumber = pa.SlotNumber,
                                 AppointmentStatusCode = pa.AppointmentStatusCode,
                                 Description = pa.Description,
                                 IsWaiting = pa.IsWaiting,
                                 Deleted = pa.Deleted,
                                 CreatedDate = pa.CreatedDate,
                                 CreatedBy = pa.CreatedBy,
                                 ModifiedDate = pa.ModifiedDate,
                                 ModifiedBy = pa.ModifiedBy,
                                 IsRecurrence = pa.IsRecurrence,
                                 RecurrenceRule = pa.RecurrenceRule
                             });

                if (query != null)
                {
                    List<PatientAppointmentModel> appointments = query.ToList();
                    foreach (PatientAppointmentModel patientAppointmentModel in appointments)
                    {
                        patientAppointmentModel.AppointmentStatusCode = cancel;
                        int result = AppointmentUpdate(patientAppointmentModel);
                    }
                }
            }
        }

        // <summary>
        /// Gets a collection of All Facilities
        /// </summary>
        public IList<FacilityMapModel> GetFacilities()
        {

            var facilities = (from f in _uowEncounterService.Repository<Facility>().Table.Where(f => !f.Deleted)
                              join pl in _uowEncounterService.Repository<ProviderLocation>().Table.Where(pl => !pl.Deleted) on f.FacilityID equals pl.FacilityID
                              select new FacilityMapModel
                              {
                                  FacilityID = f.FacilityID,
                                  FacilityName = f.FacilityName
                              }).Distinct().OrderBy(x => x.FacilityName).ToList();

            return facilities;
        }

        public IList<SchedulerSetupModel> GetSchedulerSetupList()
        {
            return null;
        }
        public IList<HolidaySetupModel> GetHolidaySetupList()
        {
            var query = _uowEncounterService.Repository<HolidaySetup>().Table;
            query = query.Where(c => !c.Deleted);
            query = query.OrderByDescending(c => c.HolidayYear);

            var holidysQuery = (from t in query
                                select new HolidaySetupModel
                                {
                                    HolidaySetupID = t.HolidaySetupID,
                                    FacilityID = t.FacilityID,
                                    Description = t.Description,
                                    HolidayYear = t.HolidayYear,
                                    SetupStartMonth = t.SetupStartMonth,
                                    SetupEndMonth = t.SetupEndMonth,
                                    Deleted = t.Deleted,
                                    CreatedDate = t.CreatedDate,
                                    CreatedBy = t.CreatedBy,
                                    ModifiedDate = t.ModifiedDate,
                                    ModifiedBy = t.ModifiedBy
                                }).ToList();


            return holidysQuery;
        }

        public IList<AppointmentDashboardDetailsModel> GetAppointmentDashboardDetails()
        {
            DateTime currentDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            DateTime firstDayOfTheMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 01);
            DateTime lastDayOfTheMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.DaysInMonth(DateTime.UtcNow.Year, DateTime.UtcNow.Month));

            DateTime firstDayOfTheWeek, lastDayOfTheWeek;
            firstDayOfTheWeek = BmsCommonUtility.GetFirstDayOfWeek(DateTime.UtcNow);
            lastDayOfTheWeek = firstDayOfTheWeek.AddDays(6);


            var currentDateList = (from pa in _uowEncounterService.Repository<PatientAppointment>().Table
                                   join aps in _uowEncounterService.Repository<AppointmentStatu>().Table on pa.AppointmentStatusCode equals aps.Code
                                   where (!pa.Deleted) && (!aps.Deleted) && (pa.AppointmentDate == currentDate)
                                   group pa by aps.Description into newGroup
                                   select new AppointmentStatusList
                                   {
                                       Key = newGroup.Key,
                                       Value = newGroup.Count()
                                   }).ToList();

            var currentWeekList = (from pa in _uowEncounterService.Repository<PatientAppointment>().Table
                                   join aps in _uowEncounterService.Repository<AppointmentStatu>().Table on pa.AppointmentStatusCode equals aps.Code
                                   where (!pa.Deleted) && (!aps.Deleted) && (pa.AppointmentDate >= firstDayOfTheWeek && pa.AppointmentDate <= lastDayOfTheWeek)
                                   group pa by aps.Description into newGroup
                                   select new AppointmentStatusList
                                   {
                                       Key = newGroup.Key,
                                       Value = newGroup.Count()
                                   }).ToList();

            var currentMonthList = (from pa in _uowEncounterService.Repository<PatientAppointment>().Table
                                    join aps in _uowEncounterService.Repository<AppointmentStatu>().Table on pa.AppointmentStatusCode equals aps.Code
                                    where (!pa.Deleted) && (!aps.Deleted) && (pa.AppointmentDate >= firstDayOfTheMonth && pa.AppointmentDate <= lastDayOfTheMonth)
                                    group pa by aps.Description into newGroup
                                    select new AppointmentStatusList
                                    {
                                        Key = newGroup.Key,
                                        Value = newGroup.Count()
                                    }).ToList();

            var appointmentStatusList = (from aps in _uowEncounterService.Repository<AppointmentStatu>().Table
                                         where (!aps.Deleted)
                                         select new AppointmentStatuModel
                                         {
                                             AppointmentStatusID = aps.AppointmentStatusID,
                                             Code = aps.Code,
                                             Description = aps.Description
                                         }).ToList();

            List<AppointmentDashboardDetailsModel> resultList = new List<AppointmentDashboardDetailsModel>();

            foreach (var item in appointmentStatusList)
            {
                resultList.Add(new AppointmentDashboardDetailsModel { AppointmentType = item.Description, TodayCount = GetStatusCount(currentDateList, item.Description), WeeklyCount = GetStatusCount(currentWeekList, item.Description), MonthlyCount = GetStatusCount(currentMonthList, item.Description) });
            }

            return resultList;
        }


        public IList<AppointmentStatuModel> GetAppointmentStatus()
        {
            var query = from ap in _uowEncounterService.Repository<AppointmentStatu>().Table
                        where (!ap.Deleted) && ((ap.Code == "CN") || (ap.Code == "AR") || (ap.Code == "RQ"))
                        select new AppointmentStatuModel
                        {
                            AppointmentStatusID = ap.AppointmentStatusID,
                            Code = ap.Code,
                            Description = ap.Description
                        };
            var result = query.ToList();
            return result;
        }

        public IList<ProviderModel> GetProviderName()
        {
            var query = from p in _uowEncounterService.Repository<Provider>().Table
                        where (!p.Deleted)
                        select new ProviderModel
                        {
                            ProviderID = p.ProviderID,
                            ProviderName = p.NameLast + ", " + p.NameFirst + (p.NameMiddle == null ? "" : " " + p.NameMiddle),
                        };
            var result = query.ToList();
            return result;
        }

        public void PastWaitingAppointmentsCancelled()
        {
            DateTime date = DateTime.UtcNow.Date;

            var schedulerSetupFacilityIDs = (from ss in _uowEncounterService.Repository<SchedulerSetup>().Table
                                             where !ss.Deleted
                                             && ss.IsCancelPastWaitingOfAppointment == true
                                             && (ss.EffectiveDate <= date && date <= ss.TerminationDate)
                                             select ss.FacilityID).ToList();

            if (schedulerSetupFacilityIDs != null)
            {
                string cancel = clsCommon.GetEnumDescription(clsCommon.AppointmentStatus.Cancel);
                var query = (from pa in _uowEncounterService.Repository<PatientAppointment>().Table
                             where !pa.Deleted
                             && schedulerSetupFacilityIDs.Contains(pa.FacilityID)
                             && pa.IsWaiting
                             && pa.AppointmentStatusCode != cancel
                             && pa.EndTime <= date
                             select new PatientAppointmentModel
                             {
                                 PatientAppointmentID = pa.PatientAppointmentID,
                                 PatientID = pa.PatientID,
                                 FacilityID = pa.FacilityID,
                                 ProviderID = pa.ProviderID,
                                 AppointmentDate = pa.AppointmentDate,
                                 VisitTypeID = pa.VisitTypeID,
                                 StartTime = pa.StartTime,
                                 EndTime = pa.EndTime,
                                 Duration = pa.Duration,
                                 SlotNumber = pa.SlotNumber,
                                 AppointmentStatusCode = pa.AppointmentStatusCode,
                                 Description = pa.Description,
                                 IsWaiting = pa.IsWaiting,
                                 Deleted = pa.Deleted,
                                 CreatedDate = pa.CreatedDate,
                                 CreatedBy = pa.CreatedBy,
                                 ModifiedDate = pa.ModifiedDate,
                                 ModifiedBy = pa.ModifiedBy,
                                 IsRecurrence = pa.IsRecurrence,
                                 RecurrenceRule = pa.RecurrenceRule
                             });

                if (query != null)
                {
                    List<PatientAppointmentModel> appointments = query.ToList();
                    foreach (PatientAppointmentModel patientAppointmentModel in appointments)
                    {
                        patientAppointmentModel.AppointmentStatusCode = cancel;
                        int result = AppointmentUpdate(patientAppointmentModel);
                    }
                }
            }
        }
        //__________________________________________________________________________________________________________________________________________________________

        //___________________________Facility Service_____________________________________
        public IList<FacilityModel> GetFacilityDetails()
        {
            var query = from fm in _uowFacilityService.Repository<Facility>().Table
                        where (!fm.Deleted)
                        orderby fm.FacilityName ascending
                        select new FacilityModel
                        {
                            FacilityID = fm.FacilityID,
                            GroupFacilityID = fm.GroupFacilityID,
                            NPI = fm.NPI,
                            TaxID = fm.TaxID,
                            FacilityName = fm.FacilityName,
                            OtherName = fm.OtherName,

                        };
            var facilityDetails = query.ToList();

            foreach (FacilityModel item in facilityDetails.ToList())
            {
                item.TaxID = BmsCommonUtility.FormatStrings(item.TaxID, BmsCommonUtility.FormatStringTypes.TaxId);
            }

            return facilityDetails;
        }

        public IList<FeeScheduleModel> GetFeeSchedules()
        {
            var query = from fs in _uowFacilityService.Repository<FeeSchedule>().Table
                        orderby fs.FeeScheduleNO ascending
                        where (!fs.Deleted)
                        select new FeeScheduleModel
                        {
                            FeeScheduleID = fs.FeeScheduleID,
                            FeeScheduleNO = fs.FeeScheduleNO,
                            CodeQualifier = fs.CodeQualifier,
                            FeeScheduleStatus = fs.FeeScheduleStatus,
                            EffectiveDate = fs.EffectiveDate,
                            TerminationDate = fs.TerminationDate
                        };
            var feeSchedules = query.Distinct().ToList();
            return feeSchedules;
        }

        public IList<PracticeFeeScheduleModel> GetFeeScheuleNos()
        {
            var query = from pfs in _uowFacilityService.Repository<PracticeFeeSchedule>().Table
                        orderby pfs.FeeScheduleNO ascending
                        where (!pfs.Deleted)
                        select new PracticeFeeScheduleModel
                        {
                            PracticeFeeScheduleID = pfs.PracticeFeeScheduleID,
                            FeeScheduleNO = pfs.FeeScheduleNO,
                            Description = pfs.Description
                        };
            var feeScheduleNos = query.Distinct().ToList();
            return feeScheduleNos;
        }

        public IList<FacilityModel> GetFacilitiesForAppointment()
        {

            var query = (from fm in _uowFacilityService.Repository<Facility>().Table
                         join cm in _uowFacilityService.Repository<CommonMaster>().Table on fm.BillingLocation equals cm.CommonMasterID
                         into billingLocationJoin
                         from bl in billingLocationJoin.DefaultIfEmpty()
                         where (!fm.Deleted && bl.Description.Trim().ToUpper() != "BILLING")
                         orderby fm.FacilityName ascending
                         select new
                         {
                             FacilityID = fm.FacilityID,
                             GroupFacilityID = fm.GroupFacilityID,
                             NPI = fm.NPI,
                             TaxID = fm.TaxID,
                             FacilityName = fm.FacilityName,
                             OtherName = fm.OtherName,

                         }).AsEnumerable().Select(x => new FacilityModel
                         {
                             FacilityID = x.FacilityID,
                             GroupFacilityID = x.GroupFacilityID,
                             NPI = x.NPI,
                             TaxID = BmsCommonUtility.FormatStrings(x.TaxID, BmsCommonUtility.FormatStringTypes.TaxId),
                             FacilityName = x.FacilityName,
                             OtherName = x.OtherName,
                         }
                        ).ToList();
            var facilityDetails = query.ToList();


            return facilityDetails;

        }
        //____________________________________________________________________________________________________________________________________________
        //______________________________InsuranceService_________________________________________

        public IList<InsuranceCategoryModel> GetInsuranceCategories()
        {
            var query = from dt in _uowInsuranceService.Repository<InsuranceCategory>().Table
                        where dt.Deleted == false
                        orderby dt.Description
                        select new InsuranceCategoryModel
                        {
                            InsuranceCategoryID = dt.InsuranceCategoryID,
                            Description = dt.Description
                        };
            var resultGetInsuranceCategories = query.ToList();
            return resultGetInsuranceCategories;

        }
        //______________________________________________________________________________________________________________________________________________
        //__________________________MasterService________________________________
        public IList<AppointmentStatuModel> GetAppointmentStatus()
        {
            var query = from a in _uowMasterService.Repository<AppointmentStatu>().Table
                        where a.Deleted == false
                        orderby a.Code
                        select new AppointmentStatuModel
                        {
                            AppointmentStatusID = a.AppointmentStatusID,
                            Code = a.Code,
                            Description = a.Description,
                            Deleted = a.Deleted,
                            CreatedDate = a.CreatedDate,
                            CreatedBy = a.CreatedBy,
                            ModifiedDate = a.ModifiedDate,
                            ModifiedBy = a.ModifiedBy
                        };
            var appointmentStatus = query.ToList();
            return appointmentStatus;
        }

        public IList<RaceModel> GetRaces()
        {
            var query = from e in _uowMasterService.Repository<Race>().Table
                        where e.Deleted == false
            orderby e.RaceCode
                        select new RaceModel
                        {
                            RaceID = e.RaceID,
                            RaceCode = e.RaceCode,
                            Description = e.Description,
                            RaceOrder = e.RaceOrder,
                            Deleted = e.Deleted,
                            CreatedDate = e.CreatedDate,
                            CreatedBy = e.CreatedBy,
                            ModifiedDate = e.ModifiedDate,
                            ModifiedBy = e.ModifiedBy
                        };
            var raceList = query.ToList();
            return raceList;
        }

        public IList<EthnicityModel> GetEthnicities()
        {
            var query = from e in _uowMasterService.Repository<Ethnicity>().Table
                        where e.Deleted == false
                        orderby e.EthnicityCode
                        select new EthnicityModel
                        {
                            EthnicityID = e.EthnicityID,
                            EthnicityCode = e.EthnicityCode,
                            Description = e.Description,
                            EthnicityOrder = e.EthnicityOrder,
                            Deleted = e.Deleted,
                            CreatedDate = e.CreatedDate,
                            CreatedBy = e.CreatedBy,
                            ModifiedDate = e.ModifiedDate,
                            ModifiedBy = e.ModifiedBy
                        };
            var ethnicityList = query.ToList();
            return ethnicityList;
        }

        public IList<RegionalLanguageModel> GetRegionalLanguages()
        {
            var query = from l in _uowMasterService.Repository<RegionalLanguage>().Table
                        select new RegionalLanguageModel
                        {
                            RegionalLanguageID = l.RegionalLanguageID,
                            Code = l.Code,
                            Description = l.Description,
                        };
            var regionalLanguageList = query.ToList();
            return regionalLanguageList;
        }

        public IList<PatientRelationModel> GetPatientRelations()
        {
            var query = from pr in _uowMasterService.Repository<PatientRelation>().Table
                        where (!pr.Deleted)
                        select new PatientRelationModel
                        {
                            PatientRelationID = pr.PatientRelationID,
                            RelationCode = pr.RelationCode,
                            RelationDescription = pr.RelationDescription,
                            HIPAARelationCode = pr.HIPAARelationCode,
                            RelationOrder = pr.RelationOrder,
                            Deleted = pr.Deleted,
                            CreatedDate = pr.CreatedDate,
                            CreatedBy = pr.CreatedBy,
                            ModifiedDate = pr.ModifiedDate,
                            ModifiedBy = pr.ModifiedBy
                        };
            var patientRelations = query.ToList();
            return patientRelations;
        }

        public IList<PatientContactPersonTypeModel> GetPatientContactPersonTypes()
        {

            var query = from dt in _uowMasterService.Repository<PatientContactPersonType>().Table
                        where dt.Deleted == false
                        orderby dt.Code
                        select new PatientContactPersonTypeModel
                        {
                            PatientContactPersonTypeID = dt.PatientContactPersonTypeID,
                            Code = dt.Code,
                            Description = dt.Description
                        };

            var resultPatientContactPersonTypes = query.ToList();
            return resultPatientContactPersonTypes;
        }

        public IList<PatientRelationModel> GetPatientRelations()
        {
            var query = from pr in _uowMasterService.Repository<PatientRelation>().Table
                        where (!pr.Deleted)
                        select new PatientRelationModel
                        {
                            PatientRelationID = pr.PatientRelationID,
                            RelationCode = pr.RelationCode,
                            RelationDescription = pr.RelationDescription,
                            HIPAARelationCode = pr.HIPAARelationCode,
                            RelationOrder = pr.RelationOrder,
                            Deleted = pr.Deleted,
                            CreatedDate = pr.CreatedDate,
                            CreatedBy = pr.CreatedBy,
                            ModifiedDate = pr.ModifiedDate,
                            ModifiedBy = pr.ModifiedBy
                        };
            var patientRelations = query.ToList();
            return patientRelations;
        }
        public IList<InsuranceTypeModel> GetInsuranceTypes()
        {
            var query = from it in _uowMasterService.Repository<InsuranceType>().Table
                        where it.Deleted == false
                        orderby it.TypeDescription
                        select new InsuranceTypeModel
                        {
                            InsuranceTypeID = it.InsuranceTypeID,
                            TypeDescription = it.TypeDescription,
                            Deleted = it.Deleted,
                            CreatedDate = it.CreatedDate,
                            CreatedBy = it.CreatedBy,
                            ModifiedDate = it.ModifiedDate,
                            ModifiedBy = it.ModifiedBy
                        };
            var result = query.ToList();
            return result;
        }
        public IList<PatientDischargeStatusModel> GetPatientDischargeStatusList()
        {
            var patientDischargeStatus = (from pds in _uowMasterService.Repository<PatientDischargeStatus>().Table
                                          orderby pds.Code descending
                                          select new PatientDischargeStatusModel
                                          {
                                              PatientDischargeStatusID = pds.PatientDischargeStatusID,
                                              Code = pds.Code,
                                              Description = pds.Description,
                                              Deleted = pds.Deleted,
                                              CreatedDate = pds.CreatedDate,
                                              CreatedBy = pds.CreatedBy,
                                              ModifiedDate = pds.ModifiedDate,
                                              ModifiedBy = pds.ModifiedBy
                                          }).ToList();

            return patientDischargeStatus;
        }
        public IList<SourceOfAdmissionModel> GetSourceOfAdmissionList()
        {
            var sourceOfAdmission = (from soa in _uowMasterService.Repository<SourceOfAdmission>().Table
                                     orderby soa.Code descending
                                     select new SourceOfAdmissionModel
                                     {
                                         SourceOfAdmissionID = soa.SourceOfAdmissionID,
                                         Code = soa.Code,
                                         Description = soa.Description,
                                         Category = soa.Category,
                                         Deleted = soa.Deleted,
                                         CreatedDate = soa.CreatedDate,
                                         CreatedBy = soa.CreatedBy,
                                         ModifiedDate = soa.ModifiedDate,
                                         ModifiedBy = soa.ModifiedBy
                                     }).ToList();

            return sourceOfAdmission;
        }

        public IList<TypeOfSubmissionModel> GetTypeOfSubmissionList()
        {
            var typeOfSubmission = (from tos in _uowMasterService.Repository<TypeOfSubmission>().Table
                                    orderby tos.Code descending
                                    select new TypeOfSubmissionModel
                                    {
                                        TypeOfSubmissionID = tos.TypeOfSubmissionID,
                                        Code = tos.Code,
                                        Description = tos.Description,
                                        Deleted = tos.Deleted,
                                        CreatedDate = tos.CreatedDate,
                                        CreatedBy = tos.CreatedBy,
                                        ModifiedDate = tos.ModifiedDate,
                                        ModifiedBy = tos.ModifiedBy
                                    }).ToList();

            return typeOfSubmission;
        }
        public IList<HourCodeModel> GetHourCodeList()
        {
            var hourCode = (from hc in _uowMasterService.Repository<HourCode>().Table
                            orderby hc.Code descending
                            select new HourCodeModel
                            {

                                HourCodeID = hc.HourCodeID,
                                Code = hc.Code,
                                Description = hc.Description,
                                Deleted = hc.Deleted,
                                CreatedDate = hc.CreatedDate,
                                CreatedBy = hc.CreatedBy,
                                ModifiedDate = hc.ModifiedDate,
                                ModifiedBy = hc.ModifiedBy
                            }).ToList();

            return hourCode;
        }
        //____________________________________________________________________________________________________________________
        //_____________________Patients_____________________________________
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
        //______________________________________________________________________________________________________________________________________
        //__________________Provider___________________________________________
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
        //_________________________________________________________________________________________________________________

        //__________________________Users_________________________________
        public IList<DashboardClientSetupModel> GetClientListForDashboard()
        {
            var query = (from cl in _uowUserService.Repository<ClientSetup>().Table
                         join ca in _uowUserService.Repository<ClientAccountSetup>().Table on cl.ClientSetupID equals ca.ClientSetupID
                         join pr in _uowUserService.Repository<Product>().Table on ca.ProductID equals pr.ProductID
                         where (!cl.Deleted) && (!ca.Deleted)
                         orderby cl.ClientName ascending
                         select new DashboardClientSetupModel
                         {
                             ClientName = cl.ClientName,
                             ProductName = pr.ProductName,
                             ProductActiveFrom = ca.ActivateFrom,
                             ProductActivateTo = ca.ActivateTo
                         });

            var clientInfo = query.ToList();
            return clientInfo;
        }

        public IList<DashboardInquiryModel> GetInquiryListForDashboard()
        {
            var query = (from iq in _uowUserService.Repository<Inquiry>().Table
                         where (!iq.Deleted)
                         orderby iq.CreatedDate descending
                         select new DashboardInquiryModel
                         {
                             CreatedDate = iq.CreatedDate,
                             InquirerName = (iq.NameFirst == null ? "" : iq.NameFirst) + " " + (iq.NameLast == null ? "" : iq.NameLast),
                             InterestedProductID = iq.InterestedProductID
                         });

            var inquiryList = query.ToList();
            return inquiryList;
        }

        public IList<DashboardInquiryDetailModel> GetInquiryFollowupListForDashboard()
        {
            var query = (from iqd in _uowUserService.Repository<InquiryDetail>().Table
                         join iq in _uowUserService.Repository<Inquiry>().Table on iqd.InquiryID equals iq.InquiryID
                         join sp in _uowUserService.Repository<SalesPerson>().Table on iqd.SalesPersonID equals sp.SalesPersonID
                         where (!iqd.Deleted) && (!iq.Deleted) && (!sp.Deleted)
                         select new DashboardInquiryDetailModel
                         {
                             SalesPersonName = (sp.NameFirst == null ? "" : sp.NameFirst) + " " + (sp.NameLast == null ? "" : sp.NameLast),
                             InquirerName = (iq.NameFirst == null ? "" : iq.NameFirst) + " " + (iq.NameLast == null ? "" : iq.NameLast),
                             CreatedDate = iq.CreatedDate,
                             InterestedProductID = iq.InterestedProductID,
                             NextFollowupDateTime = iqd.NextFollowupDateTime
                         });

            var inquiryFollowup = query.ToList();
            return inquiryFollowup;
        }

        public IList<DashboardBillModel> GetBillListForDashboard()
        {
            var query = (from bl in _uowUserService.Repository<Bill>().Table
                         join ca in _uowUserService.Repository<ClientSetup>().Table on bl.ClientID equals ca.ClientSetupID
                         join pr in _uowUserService.Repository<Product>().Table on bl.ProductID equals pr.ProductID
                         where (!bl.Deleted) && (!ca.Deleted)
                         select new DashboardBillModel
                         {
                             ClientName = ca.ClientName,
                             ProductName = pr.ProductName,
                             Amount = bl.Amount

                         });

            var bill = query.ToList();
            return bill;
        }
        public IList<DashboardReceiptModel> GetReceiptListForDashboard()
        {
            var query = (from rs in _uowUserService.Repository<Receipt>().Table
                         join bl in _uowUserService.Repository<Bill>().Table on rs.BillID equals bl.BillID
                         join ca in _uowUserService.Repository<ClientSetup>().Table on bl.ClientID equals ca.ClientSetupID
                         join pr in _uowUserService.Repository<Product>().Table on bl.ProductID equals pr.ProductID
                         where (!bl.Deleted) && (!ca.Deleted)
                         select new DashboardReceiptModel
                         {
                             ReceiptNo = rs.ReceiptNo,
                             ClientName = ca.ClientName,
                             ProductName = pr.ProductName,
                             ReceivedAmount = rs.ReceivedAmount
                         });

            var recipt = query.ToList();
            return recipt;
        }
        public IList<UserModel> GetUsers()
        {
            var query = from us in _uowUserService.Repository<User>().Table
                        where (!us.Deleted)
                        orderby us.UserName ascending
                        select new UserModel
                        {
                            UserID = us.UserID,
                            UserName = us.UserName
                        };
            var userData = query.ToList();
            return userData;
        }
        public IList<ModuleSetupModel> GetModuleSetups()
        {
            var query = from ms in _uowUserService.Repository<ModuleSetup>().Table
                        orderby ms.ModuleName ascending
                        select new ModuleSetupModel
                        {
                            ModuleSetupID = ms.ModuleSetupID,
                            ModuleName = ms.ModuleName,
                            ModuleDescription = ms.ModuleDescription,
                            ControllerName = ms.MenuActionLink,
                            MainIconPath = ms.MainIconPath,
                            SubIconPath = ms.SubIconPath
                        };
            var result = query.ToList();
            return result;
        }
        public IList<DepartmentModel> GetDepartmentList()
        {
            var query = from dpt in _uowUserService.Repository<Department>().Table
                        where (!dpt.Deleted)
                        orderby dpt.DepartmentName ascending
                        select new DepartmentModel
                        {
                            DepartmentID = dpt.DepartmentID,
                            DepartmentName = dpt.DepartmentName,
                            Deleted = dpt.Deleted,
                            CreatedDate = dpt.CreatedDate,
                            CreatedBy = dpt.CreatedBy,
                            ModifiedDate = dpt.ModifiedDate,
                            ModifiedBy = dpt.ModifiedBy
                        };
            var departmentResult = query.ToList();
            return departmentResult;
        }
        public IList<DashboardRCMUserGridInformationListModel> GetRCMUsersPaymentEnteredDashboardList()
        {
            DateTime dtToday = DateTime.Now;

            var billedAmount = (from c in _uowUserService.Repository<Claim>().Table
                                join f in _uowUserService.Repository<Facility>().Table on c.FacilityID equals f.FacilityID
                                into fac
                                from f in fac.DefaultIfEmpty()
                                join cs in _uowUserService.Repository<ClaimStatus>().Table on c.ClaimStatusID equals cs.ClaimStatusID
                                where SqlFunctions.DateDiff("MM", c.ClaimSubmittedDate, dtToday) < 2 && cs.Code == "PI"
                                orderby c.ClaimSubmittedDate descending
                                select new
                                {
                                    FacilityID = f.FacilityID,
                                    FacilityName = f.FacilityName,
                                    ClaimStatus = cs.Description,
                                    DailyBA = (DbFunctions.TruncateTime(c.ClaimSubmittedDate) == DbFunctions.TruncateTime(dtToday)) ? c.TotalCharges : 0,
                                    YesterDayBA = (DbFunctions.TruncateTime(c.ClaimSubmittedDate) == DbFunctions.TruncateTime(DbFunctions.AddDays(dtToday, -1))) ? c.TotalCharges : 0,
                                    WeeklyBA = ((DbFunctions.TruncateTime(c.ClaimSubmittedDate) >= DbFunctions.AddDays(dtToday, -7) && DbFunctions.TruncateTime(c.ClaimSubmittedDate) <= DbFunctions.TruncateTime(dtToday)) ? c.TotalCharges : 0),
                                });



            var billedAmountList = (from a in billedAmount
                                    group a by a.FacilityName into ag
                                    select new DashboardRCMUserGridInformationListModel
                                    {
                                        FacilityName = ag.Key,
                                        DailyBA = ag.Sum(t => t.DailyBA),
                                        YesterDayBA = ag.Sum(t => t.YesterDayBA),
                                        WeeklyBA = ag.Sum(t => t.WeeklyBA),
                                        //FacilityName = ag.Contains(t => t.)
                                    });
            var billedAmountresult = billedAmountList.ToList();
            return billedAmountresult;
        }
        public IList<DashboardEHRUserGridInformationListModel> GetPatientBilledAmountForDashboardAccountsReceivable()
        {

            //List<int> EDIGenStatus = new List<string> { "1", "2" };  //need to skip New and Generated

            DateTime dtToday = DateTime.Now;

            //Medical claim
            var medClaimAmmountReceivalbleAgingByPayer = (from edi in _uowUserService.Repository<EDI837PTransaction>().Table.Where(x => !x.Deleted && (x.EDIGeneratedStatusID != 1 && x.EDIGeneratedStatusID != 2) && (x.BilledAmount - x.PaidByInsurance) > 0)
                                                          select new DashboardEHRUserGridInformationListModel
                                                          {
                                                              ClaimStatus = "RE",
                                                              month1PayerBilledAmount = edi.SentDate >= (DbFunctions.AddDays(dtToday, -30)) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                              month1PatientBilledAmount = 0,

                                                              month2PayerBilledAmount = (edi.SentDate < (DbFunctions.AddDays(dtToday, -30)) && edi.SentDate >= (DbFunctions.AddDays(dtToday, -60))) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                              month2PatientBilledAmount = 0,

                                                              month3PayerBilledAmount = (edi.SentDate < (DbFunctions.AddDays(dtToday, -60)) && edi.SentDate >= (DbFunctions.AddDays(dtToday, -90))) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                              month3PatientBilledAmount = 0,

                                                              month4PayerBilledAmount = (edi.SentDate > (DbFunctions.AddDays(dtToday, -90))) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                              month4PatientBilledAmount = 0,
                                                          }).ToList();
            //Hospital claim
            var hospClaimAmmountReceivalbleAgingByPayer = (from edi in _uowUserService.Repository<EDIHospitalClaimSubmittedHistory>().Table.Where(x => !x.Deleted && (x.EDIGeneratedStatusID != 1 && x.EDIGeneratedStatusID != 2) && (x.BilledAmount - x.PaidByInsurance) > 0)
                                                           select new DashboardEHRUserGridInformationListModel
                                                           {
                                                               ClaimStatus = "RE",
                                                               month1PayerBilledAmount = edi.SentDate >= (DbFunctions.AddDays(dtToday, -30)) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                               month1PatientBilledAmount = 0,

                                                               month2PayerBilledAmount = (edi.SentDate < (DbFunctions.AddDays(dtToday, -30)) && edi.SentDate >= (DbFunctions.AddDays(dtToday, -60))) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                               month2PatientBilledAmount = 0,

                                                               month3PayerBilledAmount = (edi.SentDate < (DbFunctions.AddDays(dtToday, -60)) && edi.SentDate >= (DbFunctions.AddDays(dtToday, -90))) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                               month3PatientBilledAmount = 0,

                                                               month4PayerBilledAmount = (edi.SentDate > (DbFunctions.AddDays(dtToday, -90))) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                               month4PatientBilledAmount = 0,
                                                           }).ToList();

            ////Combine hospital and medical claim
            //var ammountReceivalbleAgingByPayer = medClaimAmmountReceivalbleAgingByPayer.Concat(hospClaimAmmountReceivalbleAgingByPayer)
            //                                            .GroupBy(t => t.StatusCode).Select(
            //                                                         t => new DashboardEHRUserGridInformationListModel
            //                                                         {
            //                                                             ProviderName = t.Key,
            //                                                             month1PayerBilledAmount = t.Sum(x => x.Month1PayerBilled),
            //                                                             month1PatientBilledAmount = t.Sum(x => x.Month2PatientBilled),
            //                                                             month2PayerBilledAmount = t.Sum(x => x.Month2PayerBilled),
            //                                                             month2PatientBilledAmount = t.Sum(x => x.Month2PatientBilled),
            //                                                             month3PayerBilledAmount = t.Sum(x => x.Month3PayerBilled),
            //                                                             month3PatientBilledAmount = t.Sum(x => x.Month3PatientBilled),
            //                                                             month4PayerBilledAmount = t.Sum(x => x.Month4PayerBilled),
            //                                                             month4PatientBilledAmount = t.Sum(x => x.Month4PatientBilled)
            //                                                         }).ToList();

            var ammountReceivalbleAgingBYPatient = (from cb in _uowUserService.Repository<ClaimBill>().Table.Where(y => !y.Deleted && (y.Charges - y.PaidByPatient) > 0)
                                                    select new DashboardEHRUserGridInformationListModel
                                                    {
                                                        ClaimStatus = "RE",
                                                        month1PayerBilledAmount = 0,
                                                        month1PatientBilledAmount = cb.BillDate >= (DbFunctions.AddDays(dtToday, -30)) ? (cb.Charges - cb.PaidByInsurance) : 0,

                                                        month2PayerBilledAmount = 0,
                                                        month2PatientBilledAmount = (cb.BillDate < (DbFunctions.AddDays(dtToday, -30)) && cb.BillDate >= (DbFunctions.AddDays(dtToday, -60))) ? (cb.Charges - cb.PaidByInsurance) : 0,

                                                        month3PayerBilledAmount = 0,
                                                        month3PatientBilledAmount = (cb.BillDate < (DbFunctions.AddDays(dtToday, -60)) && cb.BillDate >= (DbFunctions.AddDays(dtToday, -90))) ? (cb.Charges - cb.PaidByInsurance) : 0,

                                                        month4PayerBilledAmount = 0,
                                                        month4PatientBilledAmount = (cb.BillDate > (DbFunctions.AddDays(dtToday, -90))) ? (cb.Charges - cb.PaidByInsurance) : 0,
                                                    }).ToList();

            //.AsEnumerable().GroupBy(t => t.StatusCode).Select(
            //                                             t => new DashboardEHRUserGridInformationListModel
            //                                             {
            //                                                 ProviderName = t.Key,
            //                                                 month1PayerBilledAmount = t.Sum(x => x.Month1PayerBilled),
            //                                                 month1PatientBilledAmount = t.Sum(x => x.Month2PatientBilled),
            //                                                 month2PayerBilledAmount = t.Sum(x => x.Month2PayerBilled),
            //                                                 month2PatientBilledAmount = t.Sum(x => x.Month2PatientBilled),
            //                                                 month3PayerBilledAmount = t.Sum(x => x.Month3PayerBilled),
            //                                                 month3PatientBilledAmount = t.Sum(x => x.Month3PatientBilled),
            //                                                 month4PayerBilledAmount = t.Sum(x => x.Month4PayerBilled),
            //                                                 month4PatientBilledAmount = t.Sum(x => x.Month4PatientBilled)
            //                                             }).ToList()

            var ammountReceivalbleAsAging = medClaimAmmountReceivalbleAgingByPayer.Concat(hospClaimAmmountReceivalbleAgingByPayer).Concat(ammountReceivalbleAgingBYPatient)
                        .GroupBy(x => x.ClaimStatus).Select(
                          t => new DashboardEHRUserGridInformationListModel
                          {
                              month1PayerBilledAmount = t.Sum(x => x.month1PayerBilledAmount),
                              month1PatientBilledAmount = t.Sum(x => x.month1PatientBilledAmount),
                              month2PayerBilledAmount = t.Sum(x => x.month2PayerBilledAmount),
                              month2PatientBilledAmount = t.Sum(x => x.month2PatientBilledAmount),
                              month3PayerBilledAmount = t.Sum(x => x.month3PayerBilledAmount),
                              month3PatientBilledAmount = t.Sum(x => x.month3PatientBilledAmount),
                              month4PayerBilledAmount = t.Sum(x => x.month4PayerBilledAmount),
                              month4PatientBilledAmount = t.Sum(x => x.month4PatientBilledAmount)
                          }).ToList();


            return ammountReceivalbleAsAging;
        }
        public IList<DashboardRCMUserGridInformationListModel> DashboardRCMUserPayerPatientInformationByClaimStatus()
        {
            List<string> claimStatus = new List<string>() { "SB", "PI" };

            var payerPatientMedClaimPaymentInfo = (from c in _uowUserService.Repository<Claim>().Table.Where(t => !t.Deleted)
                                                   join cs in _uowUserService.Repository<ClaimStatus>().Table.Where(t => claimStatus.Contains(t.Code)) on c.ClaimStatusID equals cs.ClaimStatusID
                                                   join edi in _uowUserService.Repository<EDI837PTransaction>().Table.Where(y => !y.Deleted) on c.ClaimID equals edi.ClaimID into ed
                                                   from e in ed.DefaultIfEmpty()
                                                   join cb in _uowUserService.Repository<ClaimBill>().Table.Where(z => !z.Deleted && z.ClaimTypeCode.Equals("M")) on c.ClaimID equals cb.ClaimID into bill
                                                   from cl in bill.DefaultIfEmpty()
                                                   select new DashboardRCMUserGridInformationListModel
                                                   {
                                                       ClaimStatus = cs.Code,
                                                       PayerSubmitted = (e != null ? (e.TotalCharges != null ? e.TotalCharges : 0) ?? 0 : 0),
                                                       PatientSubmitted = (cl != null ? (cl.Charges != null ? cl.Charges : 0) : 0),

                                                       PayerRecieved = (e != null ? (e.PaidByInsurance != null ? e.PaidByInsurance : 0) ?? 0 : 0),
                                                       PatientRecieved = (cl != null ? (cl.PaidByPatient != null ? cl.PaidByPatient : 0) : 0),

                                                       PayerBalance = (e != null ? ((e.TotalCharges != null ? e.TotalCharges : 0) - (e.PaidByInsurance != null ? e.PaidByInsurance : 0)) ?? 0 : 0),
                                                       PatientBalance = (cl != null ? ((cl.Charges != null ? cl.Charges : 0) - (cl.PaidByPatient != null ? cl.PaidByPatient : 0)) : 0),
                                                   });

            var payerPatientHospClaimPaymentInfo = (from c in _uowUserService.Repository<HospitalClaim>().Table.Where(t => !t.Deleted)
                                                    join cs in _uowUserService.Repository<ClaimStatus>().Table.Where(t => claimStatus.Contains(t.Code)) on c.ClaimStatusID equals cs.ClaimStatusID
                                                    join edi in _uowUserService.Repository<EDIHospitalClaimSubmittedHistory>().Table.Where(y => !y.Deleted) on c.HospitalClaimID equals edi.HospitalClaimID into ed
                                                    from e in ed.DefaultIfEmpty()
                                                    join cb in _uowUserService.Repository<ClaimBill>().Table.Where(z => !z.Deleted && z.ClaimTypeCode.Equals("H")) on c.HospitalClaimID equals cb.ClaimID into bill
                                                    from cl in bill.DefaultIfEmpty()
                                                    select new DashboardRCMUserGridInformationListModel
                                                    {
                                                        ClaimStatus = cs.Code,
                                                        PayerSubmitted = (e != null ? (e.TotalCharges != null ? e.TotalCharges : 0) : 0),
                                                        PatientSubmitted = (cl != null ? (cl.Charges != null ? cl.Charges : 0) : 0),

                                                        PayerRecieved = (e != null ? (e.PaidByInsurance != null ? e.PaidByInsurance : 0) ?? 0 : 0),
                                                        PatientRecieved = (cl != null ? (cl.PaidByPatient != null ? cl.PaidByPatient : 0) : 0),

                                                        PayerBalance = (e != null ? ((e.TotalCharges != null ? e.TotalCharges : 0) - (e.PaidByInsurance != null ? e.PaidByInsurance : 0)) ?? 0 : 0),
                                                        PatientBalance = (cl != null ? ((cl.Charges != null ? cl.Charges : 0) - (cl.PaidByPatient != null ? cl.PaidByPatient : 0)) : 0),
                                                    });

            //combine medical and hospital claim and aggregate the values
            var payerPatientPaymentInfo = payerPatientMedClaimPaymentInfo.Concat(payerPatientHospClaimPaymentInfo).ToList().GroupBy(g => g.ClaimStatus).Select(
                                                ag => new DashboardRCMUserGridInformationListModel
                                                {
                                                    ClaimStatus = ag.Key,
                                                    PayerSubmittedAmount = ag.Sum(t => t.PayerSubmitted),
                                                    PatientSubmittedAmount = ag.Sum(t => t.PatientSubmitted),
                                                    PayerRecievedAmount = ag.Sum(t => t.PayerRecieved),
                                                    PatientRecievedAmount = ag.Sum(t => t.PatientRecieved),
                                                    PayerBalanceAmount = ag.Sum(t => t.PayerBalance),
                                                    PatientBalanceAmount = ag.Sum(t => t.PatientBalance),
                                                }).ToList();

            return payerPatientPaymentInfo;
        }
        public IList<DashboardRCMUserGridInformationListModel> GetRCMAdminPaymentsReceived()
        {
            DateTime dtToday = DateTime.Now;

            //medical claim
            var medClaimInsPayments = (from pa in _uowUserService.Repository<EDI835ClaimResponseDetails>().Table
                                       where !pa.Deleted && (SqlFunctions.DateDiff("WW", pa.CreatedDate, dtToday) == 0 || (DbFunctions.TruncateTime(pa.CreatedDate) == DbFunctions.TruncateTime(SqlFunctions.DateAdd("DD", -(dtToday.Day), dtToday))))
                                       select new
                                       {
                                           Code = "CB",
                                           Daily = (DbFunctions.TruncateTime(pa.CreatedDate) == DbFunctions.TruncateTime(dtToday)) ? pa.InsurancePaidAmount : 0,
                                           YesterDay = (DbFunctions.TruncateTime(pa.CreatedDate) == DbFunctions.TruncateTime(DbFunctions.AddDays(dtToday, -1))) ? pa.InsurancePaidAmount : 0,
                                           Weekly = (SqlFunctions.DateDiff("WW", pa.CreatedDate, dtToday) == 0) ? pa.InsurancePaidAmount : 0,
                                       });
            //hospital claim
            var medClaimPatientPayments = (from pp in _uowUserService.Repository<ClaimReceipt>().Table
                                           where !pp.Deleted && (SqlFunctions.DateDiff("WW", pp.ReceiptDate, dtToday) == 0 || (DbFunctions.TruncateTime(pp.ReceiptDate) == DbFunctions.TruncateTime(SqlFunctions.DateAdd("DD", -(dtToday.Day), dtToday))))
                                           select new
                                           {
                                               Code = "CB",
                                               Daily = (DbFunctions.TruncateTime(pp.ReceiptDate) == DbFunctions.TruncateTime(dtToday)) ? pp.PaidAmount : 0,
                                               YesterDay = (DbFunctions.TruncateTime(pp.ReceiptDate) == DbFunctions.TruncateTime(DbFunctions.AddDays(dtToday, -1))) ? pp.PaidAmount : 0,
                                               Weekly = (SqlFunctions.DateDiff("WW", pp.ReceiptDate, dtToday) == 0) ? pp.PaidAmount : 0,
                                           });

            //combine medical and hospital claim
            var allClaimPayments = medClaimInsPayments.Concat(medClaimPatientPayments).GroupBy(t => t.Code).Select(
                        t => new DashboardRCMUserGridInformationListModel
                        {
                            DailyBA = t.Sum(x => x.Daily),
                            YesterDayBA = t.Sum(x => x.YesterDay),
                            WeeklyBA = t.Sum(x => x.Weekly)
                        }).ToList();

            return allClaimPayments;
        }
        public IList<DashboardRCMUserGridInformationListModel> GetRCMAdminPaymentsPending()
        {
            List<string> claimStatus = new List<string> { "NW", "GE" };  //this codes needs to be exclude  "New and Generated"

            //Medical Claim
            var medClaimPendingPayment = (from c in _uowUserService.Repository<Claim>().Table.Where(t => !t.Deleted)
                                          join cs in _uowUserService.Repository<ClaimStatus>().Table.Where(t => !claimStatus.Contains(t.Code)) on c.ClaimStatusID equals cs.ClaimStatusID
                                          select new
                                          {
                                              ClaimStatus = "PP",
                                              PendingPayments = (c.TotalCharges - (c.PaidByPatient + c.PaidByInsurance)),
                                          });
            //Hospital Claim                                     
            var hospClaimPendingPayment = (from c in _uowUserService.Repository<HospitalClaim>().Table.Where(t => !t.Deleted)
                                           join cs in _uowUserService.Repository<ClaimStatus>().Table.Where(t => !claimStatus.Contains(t.Code)) on c.ClaimStatusID equals cs.ClaimStatusID
                                           select new
                                           {
                                               ClaimStatus = "PP",
                                               PendingPayments = (c.TotalCharges - (c.PaidByPatient + c.PaidByInsurance)),
                                           });

            //Combine Medical and hospital claim
            var allClaimPendingPayment = medClaimPendingPayment.Concat(hospClaimPendingPayment)
                                     .GroupBy(t => t.ClaimStatus).Select(
                                            t => new DashboardRCMUserGridInformationListModel
                                            {
                                                TotalPendingClaim = t.Count(),
                                                TotalPendingAmount = t.Sum(x => x.PendingPayments)
                                            }).ToList();

            return allClaimPendingPayment;
        }
        public IList<DashboardRCMUserGridInformationListModel> GetEHRAdminPayerClaimStatus()
        {
            DateTime dtToday = DateTime.Now;
            var claimSubmitted = from Edi in _uowUserService.Repository<EDI837PTransaction>().Table
                                 join cs in _uowUserService.Repository<ClaimStatus>().Table on Edi.ClaimStatusID equals cs.ClaimStatusID
                                 into cStatus
                                 from cs in cStatus.DefaultIfEmpty()
                                 where (cs.Code == "SB" || cs.Code == "PI")
                                 select new
                                 {
                                     ClaimId = cs.Description,
                                     submitted = Edi.TotalCharges,
                                     Claimstatus = cs.Code,
                                     Accepted = Edi.PaidByInsurance,
                                     Rejected = ((Edi.TotalCharges == null ? 0 : Edi.TotalCharges) - ((Edi.PaidByPatient == null ? 0 : Edi.PaidByPatient) + (Edi.PaidByInsurance == null ? 0 : Edi.PaidByInsurance)))

                                 };

            var claimSubmittedList = (from a in claimSubmitted
                                      group a by a.ClaimId into ag
                                      select new DashboardRCMUserGridInformationListModel
                                      {
                                          ClaimStatus = ag.Key,

                                          PayerSubmittedAmount = ag.Sum(t => t.submitted),
                                          PayerRecievedAmount = ag.Sum(t => t.Accepted),
                                          PayerBalanceAmount = ag.Sum(t => t.Rejected),
                                          ClaimSubmittedCount = ag.Count(t => t.Claimstatus == "SB"),
                                          ClaimAcceptedCount = ag.Count(t => t.Claimstatus == "PI"),
                                          ClaimRejectedCount = ag.Count(t => t.Claimstatus == "DE")
                                      });
            var claimSubmittedresult = claimSubmittedList.ToList();
            return claimSubmittedresult;

        }
        public IList<DashboardRCMUserGridInformationListModel> GetEHRAdminPayerClaimSubmitted()
        {
            List<string> claimStatus = new List<string>() { "SB", "SE", "PP", "PI", "CL", "RS", "DE" };

            //medical claim
            var medClaimSubmitted = (from Edi in _uowUserService.Repository<EDI837PTransaction>().Table
                                     join cs in _uowUserService.Repository<ClaimStatus>().Table.Where(t => claimStatus.Contains(t.Code)) on Edi.ClaimStatusID equals cs.ClaimStatusID
                                     select new DashboardRCMUserGridInformationListModel
                                     {
                                         ClaimStatus = cs.Description,
                                         PayerSubmittedAmount = (Edi.TotalCharges == null ? 0 : Edi.TotalCharges),
                                         PayerRecievedAmount = (Edi.PaidByInsurance == null ? 0 : Edi.PaidByInsurance),
                                         PayerBalanceAmount = ((Edi.TotalCharges == null ? 0 : Edi.TotalCharges) - (Edi.PaidByPatient == null ? 0 : Edi.PaidByPatient))
                                     });

            //hospital claim
            var hospClaimSubmitted = (from Edi in _uowUserService.Repository<EDIHospitalClaimSubmittedHistory>().Table
                                      join cs in _uowUserService.Repository<ClaimStatus>().Table.Where(t => claimStatus.Contains(t.Code)) on Edi.ClaimStatusID equals cs.ClaimStatusID
                                      select new DashboardRCMUserGridInformationListModel
                                      {
                                          ClaimStatus = cs.Description,
                                          PayerSubmittedAmount = (Edi.TotalCharges == null ? 0 : Edi.TotalCharges),
                                          PayerRecievedAmount = (Edi.PaidByInsurance == null ? 0 : Edi.PaidByInsurance),
                                          PayerBalanceAmount = ((Edi.TotalCharges == null ? 0 : Edi.TotalCharges) - (Edi.PaidByPatient == null ? 0 : Edi.PaidByPatient))
                                      });

            //combine medical and hospital claim
            var claimSubmittedList = medClaimSubmitted.Concat(hospClaimSubmitted).GroupBy(g => g.ClaimStatus).Select(
                        ag => new DashboardRCMUserGridInformationListModel
                        {
                            ClaimStatus = ag.Key,
                            PayerSubmittedAmount = ag.Sum(t => t.PayerSubmittedAmount),
                            PayerRecievedAmount = ag.Sum(t => t.PayerRecievedAmount),
                            PayerBalanceAmount = ag.Sum(t => t.PayerBalanceAmount)
                        }).ToList();

            return claimSubmittedList;

        }

        public IList<RxOrderServiceUserSetupModel> GetAllRxOrderServiceUserSetup()
        {
            var query = (from r in _uowUserService.Repository<RxOrderServiceUserSetup>().Table
                         where (!r.Deleted)
                         select new RxOrderServiceUserSetupModel
                         {
                             RxOrderServiceUserSetupID = r.RxOrderServiceUserSetupID,
                             UserName = r.UserName,
                             Password = r.Password,
                             UserCredential = r.UserCredential,
                             CreatedDate = r.CreatedDate,
                             CreatedBy = r.CreatedBy,
                             ModifiedDate = r.ModifiedDate,
                             ModifiedBy = r.ModifiedBy

                         }
                           ).AsEnumerable().Select(x => new RxOrderServiceUserSetupModel
                           {
                               RxOrderServiceUserSetupID = x.RxOrderServiceUserSetupID,
                               UserName = x.UserName,
                               Password = Decrypt(x.Password),
                               UserCredential = x.UserCredential,
                               CreatedDate = x.CreatedDate,
                               CreatedBy = x.CreatedBy,
                               ModifiedDate = x.ModifiedDate,
                               ModifiedBy = x.ModifiedBy


                           }).ToList();
            // var Password = new IList<RxOrderServiceUserSetup> { List = query.ToList(), TotalCount = query.TotalItemCount };

            return query;
        }

        public IList<PatientRelationModel> GetPatientFamilyRelations()
        {
            throw new NotImplementedException();
        }
    }
}

