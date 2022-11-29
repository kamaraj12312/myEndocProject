using provider.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Patient_Model
{
    public class PatientAppointmentModel
    {
        #region Private variables

        private DateTime appointmentDate;
        private DateTime startTime;
        private DateTime endTime;
        private DateTime start;
        private DateTime end;

        #endregion


        public PatientAppointmentModel()
        {
            this.PatientEncounters = new List<PatientEncounterModel>();
            this.SuperBills = new List<SuperBillModel>();
            this.VisitNotes = new List<VisitNoteModel>();
            AppointmentDate = DateTime.UtcNow.Date;
        }

        public int PatientAppointmentID { get; set; }
        public Nullable<int> PatientAppointmentIDs { get; set; }
        public int PatientID { get; set; }
        public int FacilityID { get; set; }
        public int ProviderID { get; set; }
        //public System.DateTime AppointmentDate { get; set; }
        public DateTime AppointmentDate
        {
            get { return this.appointmentDate; }
            set
            {
                this.appointmentDate = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }

        public string AppointmentDateDetails { get; set; }
        public int VisitTypeID { get; set; }
        public decimal Duration { get; set; }
        public int SlotNumber { get; set; }
        public string AppointmentStatusCode { get; set; }
        public Nullable<bool> IsRecurrence { get; set; }
        public Nullable<int> ParentAppointID { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public bool Deleted { get; set; }
        public bool ShowInGrid { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public bool IsPrinted { get; set; }
        public Nullable<bool> IsMobileRequest { get; set; }
        public virtual AppointmentStatuModel AppointmentStatu { get; set; }
        public virtual FacilityModel Facility { get; set; }
        public virtual PatientModel Patient { get; set; }
        public virtual ProviderModel Provider { get; set; }
        public virtual VisitTypeModel VisitTypeModel { get; set; }
        public virtual ICollection<PatientEncounterModel> PatientEncounters { get; set; }
        public virtual ICollection<SuperBillModel> SuperBills { get; set; }
        public virtual ICollection<VisitNoteModel> VisitNotes { get; set; }
        //public System.DateTime StartTime { get; set; }
        public DateTime StartTime
        {
            get { return this.startTime; }
            set
            {
                this.startTime = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }
        //public System.DateTime EndTime { get; set; }
        public DateTime EndTime
        {
            get { return this.endTime; }
            set
            {
                this.endTime = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }

        public bool IsWaiting { get; set; }
        public Nullable<bool> IsReminder { get; set; }
        public Nullable<int> AppointmentDateMetDateEarlierThan { get; set; }
        public Nullable<int> AppointmentDateMetDateEarlierThanHrs { get; set; }
        public Nullable<int> NumberOfMessagesToSendPerPatient { get; set; }
        public Nullable<int> IntervalPerMessage { get; set; }
        public Nullable<int> IntervalBetweenMessagesTypeId { get; set; }
        public bool IsSuperBillGenerated { get; set; }
        public Nullable<bool> IsUnScheduledAppointment { get; set; }


        #region Custom Properties

        public string RedirectToVisit { get; set; }
        public string PatientName { get; set; }
        public string FacilityName { get; set; }
        public string ProviderName { get; set; }
        public string VisitTypeDescription { get; set; }
        public string AppointmentStatus { get; set; }
        public string PatientAppointmentTitle { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ProviderNameLast { get; set; }
        public string ProviderNameFirst { get; set; }
        public string ProviderNameMiddle { get; set; }
        public string NameMiddle { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int GenderID { get; set; }
        public string GenderDescription { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public bool New { get; set; }
        public bool Waiting { get; set; }
        public string RescheduleReason { get; set; }
        public string CancelReason { get; set; }
        public string DeleteReason { get; set; }
        public string WaitingListTitle { get; set; }
        public string FormatTime { get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public string DateOfBirthAge { get; set; }
        public int TodaysNewCount { get; set; }
        public int TodaysCancelCount { get; set; }
        public int TodaysCompletedCount { get; set; }
        public int WeeksNewCount { get; set; }
        public int WeeksCancelCount { get; set; }
        public int WeeksCompletedCount { get; set; }
        public int MonthsNewCount { get; set; }
        public int MonthsCancelCount { get; set; }
        public int MonthsCompletedCount { get; set; }
        public string NewTitle { get; set; }
        public string CancelledTitle { get; set; }
        public string WaitingTitle { get; set; }
        public string IntervalBetweenMessagesTypeDescription { get; set; }
        public string PatientAccountNumber { get; set; }
        public string MedicalRecordNumber { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> PatientTransactionDate { get; set; }
        public string VisitTime { get; set; }
        public string PatientTransactionDateString { get; set; }
        public Nullable<bool> IsMobileAppointmentRequest { get; set; }
        //public DateTime End { get; set; }
        public DateTime End
        {
            get { return this.end; }
            set
            {
                this.end = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }
        public string EndTimezone { get; set; }
        public bool IsAllDay { get; set; }
        //public DateTime Start { get; set; }
        public DateTime Start
        {
            get { return this.start; }
            set
            {
                this.start = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }

        public string StartTimezone { get; set; }
        public string Title { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string OtherReason { get; set; }
        public string OtherAppointmentType { get; set; }
        public string PatientInformationTitle { get; set; }
        public string AppointmentInformationTitle { get; set; }
        public string RecurrenceInformationTitle { get; set; }
        public string ReminderInformationTitle { get; set; }
        public string Length { get; set; }
        public string ScreenMode { get; set; }
        public Nullable<int> NumberOfSlotsPerProvider { get; set; }
        public Nullable<int> Booked { get; set; }
        public Nullable<int> Opened { get; set; }
        public Nullable<int> BookedPercentage { get; set; }
        public string SelectedView { get; set; }
        public string BirthDateDisPlay { get; set; }
        public string PatientPanelDisplay { get; set; }
        public string PhonePanelDisplay { get; set; }
        public string AlternatePhonePanelDisplay { get; set; }
        public bool IsDuplicatePatientConfirm { get; set; }
        public bool IsMoreThanOneAppointmentOnDayConfirm { get; set; }
        public int NoOfAvailableAppointments { get; set; }
        public int NoOfAvailableWaitingListAppointments { get; set; }
        public bool IsPastDateAppointmentConfirm { get; set; }
        public string IsSearch { get; set; }
        public string NamePrefix { get; set; }
        public string ProviderNameTitle { get; set; }
        public int IsUnscheduledAppointmentCount { get; set; }
        public Nullable<int> NumberOfSlots { get; set; }
        public string PatientAppointmentStatusTrack { get; set; }
        public string PatientVisitNotes { get; set; }
        public string PatientAppointmentNotes { get; set; }
        public string ChiefCompliantNotes { get; set; }
        #endregion

        #region Custom Properties for Redirecting to Appointment Scheduler

        public string RedirectTo { get; set; }
        public string SelectedDate { get; set; }
        public string SelectedTime { get; set; }
        public string SelectedFacilityID { get; set; }
        public string SelectedProviderID { get; set; }
        public string SelectedProviderIDs { get; set; }
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




        #endregion

        #region Custom Properties for Payment Summary

        public decimal TotalCharges { get; set; }
        public decimal PaidByInsurance { get; set; }
        public decimal PaidByPatient { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }

        #endregion

        #region Enumerators
        public clsCommon.AppointmentPortalCriteriaRequested AppointmentPortalCriteriaRequested { get; set; }
        public clsCommon.AppointmentPortalCriteriaNotRequested AppointmentPortalCriteriaNotRequested { get; set; }
        public clsCommon.AppointmentPortalCriteriaIsWaiting AppointmentPortalCriteriaIsWaiting { get; set; }
        public clsCommon.AppointmentPortalCriteriaIsNotWaiting AppointmentPortalCriteriaIsNotWaiting { get; set; }



        #endregion

        #region Search properties

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string SearchByID { get; set; }
        public string SearchBy { get; set; }

        #endregion

        public Nullable<int> WaitingCount { get; set; }
    }
}