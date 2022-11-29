using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class AppointmentStatuModel
    {
        public AppointmentStatuModel()
        {
            this.PatientAppointments = new List<PatientAppointmentModel>();
            this.SchedulerStatusIndicators = new List<SchedulerStatusIndicatorModel>();
        }
        #region Model Properties
        public int AppointmentStatusID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        #endregion
        #region Collections
        public virtual ICollection<PatientAppointmentModel> PatientAppointments { get; set; }
        public virtual ICollection<SchedulerStatusIndicatorModel> SchedulerStatusIndicators { get; set; }
    }
}