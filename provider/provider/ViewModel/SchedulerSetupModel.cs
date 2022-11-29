using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class SchedulerSetupModel
    {
        public SchedulerSetupModel()
        {
            this.SchedulerStatusIndicators = new List<SchedulerStatusIndicatorModel>();
            this.SchedulerStatusIndicatorList = new List<SchedulerStatusIndicatorModel>();
            this.HolidaySetupDetailList = new List<HolidaySetupDetailModel>();
        }

        public int SchedulerSetupID { get; set; }
        public Nullable<int> FacilityID { get; set; }
        public string SchedulerStartTime { get; set; }
        public string SchedulerEndTime { get; set; }
        public int NumberOfSlotsPerHour { get; set; }
        public string VacationColor { get; set; }
        public string OutOfOfficeColor { get; set; }
        public string LeaveColor { get; set; }
        public string HolidayColor { get; set; }
        public bool AllowAppInNonScheduledTime { get; set; }
        public bool AllowReminder { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> NoOfWaitingPerDay { get; set; }
        public Nullable<bool> IsCancelPastWaitingOfAppointment { get; set; }
        public bool IsCommon { get; set; }
        public bool SchedulerSetUpAvailable { get; set; }
        public Nullable<int> CancelPastWaitingOfAppointment { get; set; }

        #region Reference properties

        public virtual FacilityModel Facility { get; set; }
        public virtual ICollection<SchedulerStatusIndicatorModel> SchedulerStatusIndicators { get; set; }
        #endregion

        #region Custom Properties

        public string FacilityName { get; set; }
        public string SchedulerSetupTitle { get; set; }
        public int LowestProviderSlotTime { get; set; }
        public IList<SchedulerStatusIndicatorModel> SchedulerStatusIndicatorList { get; set; }
        public IList<HolidaySetupDetailModel> HolidaySetupDetailList { get; set; }
        public int HolidaySetupID { get; set; }
        public string HolidayYear { get; set; }
        public bool AddHoliday { get; set; }
        public Nullable<System.DateTime> DateHoliday { get; set; }
        public string HolidayDescription { get; set; }
        public string AppointmentColorTitle { get; set; }
        public string SchedulerWorkHoursTitle { get; set; }
        public string IsSearch { get; set; }

        public Nullable<int> SearchFacilityID { get; set; }
        public Nullable<System.DateTime> SearchEffectiveDate { get; set; }
        public Nullable<System.DateTime> SearchTerminationDate { get; set; }

        #endregion

        #region Custom Properties for Holiday Setup

        public string Repeat { get; set; }
        public Nullable<int> RepeatEvery { get; set; }
        public string RepeatOn { get; set; }
        public Nullable<int> RepeatAfter { get; set; }
        public Nullable<DateTime> EndOn { get; set; }
        public string Day { get; set; }
        public string Week { get; set; }
        public string WeekDay { get; set; }
        public string MonthlyMonth { get; set; }
        public string YearlyMonth { get; set; }
        public string WaitingListConfirm { get; set; }
        public string RecurrenceEditMode { get; set; }
        public string RecurrenceRule { get; set; }
        public string HolidayOnTitle { get; set; }
        public string HolidayName { get; set; }
        public bool IsRecurrence { get; set; }

    }
}