using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class PatientRelationModel
    {
        public PatientRelationModel()
        {
            this.PatientFamilies = new List<PatientFamilyModel>();
            this.PatientInsurances = new List<PatientInsuranceModel>();
        }
        #region Model Properties

        public int PatientRelationID { get; set; }
        public string RelationCode { get; set; }
        public string EmdeonRelationCode { get; set; }
        public string RelationDescription { get; set; }
        public string HIPAARelationCode { get; set; }
        public Nullable<int> RelationOrder { get; set; }
        public string ImmunizationRegistryRelationCode { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<PatientFamilyModel> PatientFamilies { get; set; }
        public virtual ICollection<PatientInsuranceModel> PatientInsurances { get; set; }

        #endregion

        #region Custom properties

        public string PatientRelationTitle { get; set; }
        public string IsSearch { get; set; }

        #endregion

        #region PageList Properties
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion
    }
}