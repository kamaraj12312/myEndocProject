using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace provider.Encounter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EncounterService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EncounterService.svc or EncounterService.svc.cs at the Solution Explorer and start debugging.
    public class EncounterService : IEncounterService
    {
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
    }
}
