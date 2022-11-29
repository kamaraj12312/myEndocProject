using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class ProviderLocation
    {
        public ProviderLocation()
        {
            this.ProviderLocationTimings = new List<ProviderLocationTiming>();
        }

        public int ProviderLocationID { get; set; }
        public int ProviderID { get; set; }
        public int FacilityID { get; set; }
        public System.DateTime EffectiveDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ICollection<ProviderLocationTiming> ProviderLocationTimings { get; set; }
    }
}