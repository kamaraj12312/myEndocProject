using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class InsuranceCategoryModel
    {
        public InsuranceCategoryModel()
        {
            this.InsuranceCompanies = new List<InsuranceCompanyModel>();
        }

        public int InsuranceCategoryID { get; set; }

        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public bool Deleted { get; set; }

        public virtual ICollection<InsuranceCompanyModel> InsuranceCompanies { get; set; }

        public string InsuranceCategoryTitle { get; set; }
    }
}