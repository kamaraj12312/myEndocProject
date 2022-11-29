using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace provider.Facility1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFacilityService" in both code and config file together.
    [ServiceContract]
    public interface IFacilityService
    {
        [OperationContract]
        IList<FacilityModel> GetFacilityDetails();

        [OperationContract]
        IList<FeeScheduleModel> GetFeeSchedules();

        [OperationContract]
        IList<PracticeFeeScheduleModel> GetFeeScheuleNos();

        [OperationContract]
        IList<FacilityModel> GetFacilitiesForAppointment();

    }
}
