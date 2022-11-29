using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class RegionalLanguageModel
    {
        public RegionalLanguageModel()
        {
            this.Patients = new List<PatientModel>();
        }
        #region Model Properties
        public int RegionalLanguageID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<PatientModel> Patients { get; set; }
        #endregion
    }
}