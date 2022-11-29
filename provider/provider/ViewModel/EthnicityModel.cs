using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class EthnicityModel
    {
        public EthnicityModel()
        {

            this.Patients = new List<PatientModel>();
        }
        #region Model Properties
        public int EthnicityID { get; set; }
        public string EthnicityCode { get; set; }
        public string Description { get; set; }
        public Nullable<int> EthnicityOrder { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<PatientModel> Patients { get; set; }
        public int ParentEthnicityID { get; set; }
    }
}