using provider.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace provider
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        /////---------------EncounterService--------------------
        ///
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/CancelPastWaitingAppointments", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void CancelPastWaitingAppointments();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetFacilities", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<FacilityMapModel> GetFacilities();

        #region Scheduler Setup


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GeSchedulerSetupList", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<SchedulerSetupModel> GetSchedulerSetupList();

        /// List of Holiday Setup 
        /// 
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetHolidaySetupList", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<HolidaySetupModel> GetHolidaySetupList();

        #region Dashboard
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAppointmentDashboardDetails", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<AppointmentDashboardDetailsModel> GetAppointmentDashboardDetails();

        /// <summary>
        /// To list the Appointment Status 
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAppointmentStatus", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<AppointmentStatuModel> GetAppointmentStatus();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetProviderName", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<ProviderModel> GetProviderName();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/PastWaitingAppointmentsCancelled", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void PastWaitingAppointmentsCancelled();

        //_____________________________________________________________________________________________________
        //______________________Facility Service______________________________
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetFacilityDetails", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<FacilityModel> GetFacilityDetails();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetFeeSchedules", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<FeeScheduleModel> GetFeeSchedules();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ GetFeeScheuleNos", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<PracticeFeeScheduleModel> GetFeeScheuleNos();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetFacilitiesForAppointment", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<FacilityModel> GetFacilitiesForAppointment();

        //_______________________________________________________________________________________________________
        //____________________Insurance________________________________________
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetInsuranceCategories", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<InsuranceCategoryModel> GetInsuranceCategories();
        //________________________________________________________________________________________________________

        //__________________Masters____________________________________________
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAppointmentStatus", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<AppointmentStatuModel> GetAppointmentStatus();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetRaces", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<RaceModel> GetRaces();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetEthnicities", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<EthnicityModel> GetEthnicities();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetRegionalLanguages", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<RegionalLanguageModel> GetRegionalLanguages();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetPatientRelations", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<PatientRelationModel> GetPatientRelations();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ GetPatientContactPersonTypes", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<PatientContactPersonTypeModel> GetPatientContactPersonTypes();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetPatientFamilyRelations", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<PatientRelationModel> GetPatientFamilyRelations();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ GetInsuranceTypes", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<InsuranceTypeModel> GetInsuranceTypes();

        /// Loads  patientDischargeStatus list
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ GetPatientDischargeStatusList", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<PatientDischargeStatusModel> GetPatientDischargeStatusList();

        #region Source Of Admission
        /// <summary>
        /// Loads  SourceOfAdmission list
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetSourceOfAdmissionList", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<SourceOfAdmissionModel> GetSourceOfAdmissionList();
        #endregion

        /// <summary>
        /// Loads  TypeofSubmission list
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetTypeOfSubmissionList", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<TypeOfSubmissionModel> GetTypeOfSubmissionList();

        #region Hour Code
        /// <summary>
        /// Loads  HourCode list
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetHourCodeList", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<HourCodeModel> GetHourCodeList();
        //____________________________________________________________________________________________________________
        //_____________Patients_______________________________________________
        /// Get all patients List
        /// </summary>
        /// <returns>Patients Collection</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetPatients", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<PatientModel> GetPatients();

        /// This method is used to get the description of billing method.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/getBillingMethodDescription", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<PatientInsuranceModel> getBillingMethodDescription();

        //________________________________________________________________________________________________________________
        //______________Provider_____________________________________________
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetProviders", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<ProviderModel> GetProviders();


        #region Insurance Companey List

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetInsuranceCompany", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<InsuranceCompanyModel> GetInsuranceCompany();
        //______________________________________________________________________________________________________________
        //

        //___________________Users____________________________________
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetProviders", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<ProviderModel> GetProviders();


        #region Insurance Companey List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetInsuranceCompany", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<InsuranceCompanyModel> GetInsuranceCompany();
        #region BMS Admin DashBoard
        [OperationContract]
        IList<DashboardClientSetupModel> GetClientListForDashboard();
        [OperationContract]
        IList<DashboardInquiryModel> GetInquiryListForDashboard();
        [OperationContract]
        IList<DashboardInquiryDetailModel> GetInquiryFollowupListForDashboard();
        [OperationContract]
        IList<DashboardBillModel> GetBillListForDashboard();
        [OperationContract]
        IList<DashboardReceiptModel> GetReceiptListForDashboard();

        #region "Ticket"
        /// <summary>
        /// for drop down
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<UserModel> GetUsers();
        /// <summary>
        /// List all the Modules
        /// </summary>
        /// <returns>Returns LIst of All Modules</returns>
        [OperationContract]
        IList<ModuleSetupModel> GetModuleSetups();

        [OperationContract]
        IList<DepartmentModel> GetDepartmentList();

        #region RCM CLaim Submitted
        [OperationContract]
        IList<DashboardRCMUserGridInformationListModel> GetRCMUsersPaymentEnteredDashboardList();
        [OperationContract]
        IList<DashboardEHRUserGridInformationListModel> GetPatientBilledAmountForDashboardAccountsReceivable();

        [OperationContract]
        IList<DashboardRCMUserGridInformationListModel> DashboardRCMUserPayerPatientInformationByClaimStatus();

        [OperationContract]
        IList<DashboardRCMUserGridInformationListModel> GetRCMAdminPaymentsReceived();
        [OperationContract]
        IList<DashboardRCMUserGridInformationListModel> GetRCMAdminPaymentsPending();

        #region RCM USER
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[OperationContract]
        //IList<DashboardRCMAdminGridInformationListModel> GetUserDashboardRCMAdminMessageList(int userID);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[OperationContract]
        //IList<DashboardRCMAdminGridInformationListModel> GetRCMAdminBilledAmountForDashboard();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DashboardRCMUserGridInformationListModel> GetEHRAdminPayerClaimStatus();

        #region User Dashboard EHR Admin Claim Submitted

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DashboardRCMUserGridInformationListModel> GetEHRAdminPayerClaimSubmitted();

        #region User RxOrderServiceUserSetup

        /// <summary>
        /// This method used for List for DocumentType through DocumentTypeCode and Description
        /// </summary>
        /// <param name="documentTypeCode,description">DocumentTypeCode and Description is the identifier of DocumentType</param>
        /// <returns>It returns the list of DocumentTypeTable</returns>
        [OperationContract]
        IList<RxOrderServiceUserSetupModel> GetAllRxOrderServiceUserSetup();


    }

}
