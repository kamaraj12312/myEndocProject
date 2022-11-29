using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class InsuranceType
    {
        public InsuranceType()
        {
            this.EncounterInsurances = new List<EncounterInsurance>();
            this.PatientInsurances = new List<PatientInsurance>();
        }

        public int InsuranceTypeID { get; set; }
        public string TypeDescription { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<EncounterInsurance> EncounterInsurances { get; set; }
        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }
    }
}