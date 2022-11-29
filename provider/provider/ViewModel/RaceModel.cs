using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class RaceModel
    {
        public RaceModel()
        {
            this.Patients = new List<PatientModel>();
        }
        #region Model Properties
        public int RaceID { get; set; }
        public string RaceCode { get; set; }
        public string Description { get; set; }
        public Nullable<int> RaceOrder { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        #endregion
        #region Collections
        public int ParentRaceID { get; set; }
        public virtual ICollection<PatientModel> Patients { get; set; }
        #endregion
    }
}