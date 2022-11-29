using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class PatientRelation
    {
        public PatientRelation()
        {
            this.PatientFamilies = new List<PatientFamily>();
            this.PatientInsurances = new List<PatientInsurance>();
        }

        public int PatientRelationID { get; set; }
        public string RelationCode { get; set; }
        public string EmdeonRelationCode { get; set; }
        public string RelationDescription { get; set; }
        public string HIPAARelationCode { get; set; }
        public Nullable<int> RelationOrder { get; set; }
        public string ImmunizationRegistryRelationCode { get; set; }
        public bool ViewInPatientFamily { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<PatientFamily> PatientFamilies { get; set; }
        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }
    }
}