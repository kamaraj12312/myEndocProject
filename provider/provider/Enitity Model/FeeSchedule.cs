using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class FeeSchedule
    {
        public FeeSchedule()
        {
            this.FeeScheduleCharges = new List<FeeScheduleCharge>();
            this.PracticeFeeSchedules = new List<PracticeFeeSchedule>();
        }

        public int FeeScheduleID { get; set; }
        public string FeeScheduleNO { get; set; }
        public string CodeQualifier { get; set; }
        public string FeeScheduleStatus { get; set; }
        public string StateCode { get; set; }
        public string Locality { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<FeeScheduleCharge> FeeScheduleCharges { get; set; }
        public virtual ICollection<PracticeFeeSchedule> PracticeFeeSchedules { get; set; }
    }
}
}