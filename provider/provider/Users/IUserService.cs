using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace provider.Users
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
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

