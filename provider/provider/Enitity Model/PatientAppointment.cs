using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class PatientAppointment
    {
        private System.DateTime _StartTime;
        private System.DateTime _EndTime;
        private System.DateTime _AppointmentDate;
        public PatientAppointment()
        {
            this.PatientAppointmentHistories = new List<PatientAppointmentHistory>();
            this.PatientEncounters = new List<PatientEncounter>();
            this.SuperBills = new List<SuperBill>();
            this.VisitNotes = new List<VisitNote>();
            this.PatientTobaccoAlcoholHistories = new List<PatientTobaccoAlcoholHistory>();
        }

        public int PatientAppointmentID { get; set; }
        public int PatientID { get; set; }
        public int FacilityID { get; set; }
        public int ProviderID { get; set; }
        public System.DateTime AppointmentDate { get { return this._AppointmentDate; } set { this._AppointmentDate = new DateTime(value.Ticks, DateTimeKind.Utc); } }
        public int VisitTypeID { get; set; }
        public System.DateTime StartTime
        {
            get { return this._StartTime; }
            set
            {
                this._StartTime = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }
        public System.DateTime EndTime
        {
            get { return this._EndTime; }
            set
            {
                this._EndTime = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }
        public decimal Duration { get; set; }
        public int SlotNumber { get; set; }
        public string AppointmentStatusCode { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsRecurrence { get; set; }
        public Nullable<int> ParentAppointID { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public bool IsWaiting { get; set; }
        public bool Deleted { get; set; }
        public bool ShowInGrid { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsMobileRequest { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public Nullable<bool> IsReminder { get; set; }
        public Nullable<int> AppointmentDateMetDateEarlierThan { get; set; }
        public Nullable<int> AppointmentDateMetDateEarlierThanHrs { get; set; }
        public Nullable<int> NumberOfMessagesToSendPerPatient { get; set; }
        public Nullable<int> IntervalPerMessage { get; set; }
        public Nullable<int> IntervalBetweenMessagesTypeId { get; set; }
        public bool IsSuperBillGenerated { get; set; }
        public string OtherAppointmentType { get; set; }
        public bool IsPrinted { get; set; }
        public Nullable<bool> IsUnScheduledAppointment { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual VisitType VisitType { get; set; }
        public virtual ICollection<PatientAppointmentHistory> PatientAppointmentHistories { get; set; }
        public virtual ICollection<PatientEncounter> PatientEncounters { get; set; }
        public virtual ICollection<SuperBill> SuperBills { get; set; }
        public virtual ICollection<VisitNote> VisitNotes { get; set; }
        public virtual ICollection<PatientTobaccoAlcoholHistory> PatientTobaccoAlcoholHistories { get; set; }
    }
}