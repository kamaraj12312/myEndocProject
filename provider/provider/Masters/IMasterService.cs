using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace provider.Masters
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMasterService" in both code and config file together.
    [ServiceContract]
    public interface IMasterService
    {
        [OperationContract]
        IList<AppointmentStatuModel> GetAppointmentStatus();

        [OperationContract]
        IList<RaceModel> GetRaces();

        [OperationContract]
        IList<EthnicityModel> GetEthnicities();

        [OperationContract]
        IList<RegionalLanguageModel> GetRegionalLanguages();

        [OperationContract]
        IList<PatientRelationModel> GetPatientRelations();

        [OperationContract]
        IList<PatientContactPersonTypeModel> GetPatientContactPersonTypes();

        [OperationContract]
        IList<PatientRelationModel> GetPatientFamilyRelations();

        [OperationContract]
        IList<InsuranceTypeModel> GetInsuranceTypes();

        /// Loads  patientDischargeStatus list
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<PatientDischargeStatusModel> GetPatientDischargeStatusList();

        #region Source Of Admission
        /// <summary>
        /// Loads  SourceOfAdmission list
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<SourceOfAdmissionModel> GetSourceOfAdmissionList();
        #endregion

        /// <summary>
        /// Loads  TypeofSubmission list
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<TypeOfSubmissionModel> GetTypeOfSubmissionList();

        #region Hour Code
        /// <summary>
        /// Loads  HourCode list
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<HourCodeModel> GetHourCodeList();
        #endregion
    }
}
