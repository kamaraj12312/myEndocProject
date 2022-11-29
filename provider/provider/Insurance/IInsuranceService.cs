using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace provider.Insurance
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInsuranceService" in both code and config file together.
    [ServiceContract]
    public interface IInsuranceService
    {
        [OperationContract]
        IList<InsuranceCategoryModel> GetInsuranceCategories();
    }
}
