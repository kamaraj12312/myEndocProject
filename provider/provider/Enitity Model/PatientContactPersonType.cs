using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class PatientContactPersonType
    {
        public PatientContactPersonType()
        {
            this.PatientContactPersons = new List<PatientContactPerson>();
        }

        public int PatientContactPersonTypeID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<PatientContactPerson> PatientContactPersons { get; set; }
    }
}