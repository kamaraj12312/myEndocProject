using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class SchedulerSetup
    {
        public SchedulerSetup()
        {
            this.SchedulerStatusIndicators = new List<SchedulerStatusIndicator>();
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
        public virtual Facility Facility { get; set; }
        public virtual ICollection<SchedulerStatusIndicator> SchedulerStatusIndicators { get; set; }
        public Nullable<int> CancelPastWaitingOfAppointment { get; set; }
    }
}