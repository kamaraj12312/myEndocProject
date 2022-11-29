using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace provider.Encounter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEncounterService" in both code and config file together.
    [ServiceContract]
    public interface IEncounterService
    {

        [OperationContract]
        void CancelPastWaitingAppointments();

        [OperationContract]
        IList<FacilityMapModel> GetFacilities();

        #region Scheduler Setup


        [OperationContract]
        IList<SchedulerSetupModel> GetSchedulerSetupList();

        /// List of Holiday Setup 
        /// 
        [OperationContract]
        IList<HolidaySetupModel> GetHolidaySetupList();

        #region Dashboard
        [OperationContract]
        IList<AppointmentDashboardDetailsModel> GetAppointmentDashboardDetails();

        /// <summary>
        /// To list the Appointment Status 
        /// </summary>
        [OperationContract]
        IList<AppointmentStatuModel> GetAppointmentStatus();

        [OperationContract]
        IList<ProviderModel> GetProviderName();

        [OperationContract]
        void PastWaitingAppointmentsCancelled();
    }
}
