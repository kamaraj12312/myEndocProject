using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace provider.Patients
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPatientService" in both code and config file together.
    [ServiceContract]
    public interface IPatientService
    {
        /// Get all patients List
        /// </summary>
        /// <returns>Patients Collection</returns>
        [OperationContract]
        IList<PatientModel> GetPatients();

        /// This method is used to get the description of billing method.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<PatientInsuranceModel> getBillingMethodDescription();
    }
}
