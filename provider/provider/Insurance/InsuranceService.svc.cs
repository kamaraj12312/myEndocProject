using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace provider.Insurance
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InsuranceService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InsuranceService.svc or InsuranceService.svc.cs at the Solution Explorer and start debugging.
    public class InsuranceService : IInsuranceService
    {
        public IList<InsuranceCategoryModel> GetInsuranceCategories()
        {
            var query = from dt in _uowInsuranceService.Repository<InsuranceCategory>().Table
                        where dt.Deleted == false
                        orderby dt.Description
                        select new InsuranceCategoryModel
                        {
                            InsuranceCategoryID = dt.InsuranceCategoryID,
                            Description = dt.Description
                        };
            var resultGetInsuranceCategories = query.ToList();
            return resultGetInsuranceCategories;

        }
    }
}
