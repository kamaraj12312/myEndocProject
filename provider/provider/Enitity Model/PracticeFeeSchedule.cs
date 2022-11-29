using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class PracticeFeeSchedule
    {
        public PracticeFeeSchedule()
        {
            this.PracticeFeeScheduleCharges = new List<PracticeFeeScheduleCharge>();
            this.ProviderFeeSchedules = new List<ProviderFeeSchedule>();
        }

        public int PracticeFeeScheduleID { get; set; }
        public string FeeScheduleNO { get; set; }
        public int FeeScheduleID { get; set; }
        public string Description { get; set; }
        public string CodeQualifier { get; set; }
        public int ServiceProviderTypeID { get; set; }
        public int ServiceProviderID { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public decimal OverridedValueFromBase { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual FeeSchedule FeeSchedule { get; set; }
        public virtual ICollection<PracticeFeeScheduleCharge> PracticeFeeScheduleCharges { get; set; }
        public virtual ICollection<ProviderFeeSchedule> ProviderFeeSchedules { get; set; }
    }
}