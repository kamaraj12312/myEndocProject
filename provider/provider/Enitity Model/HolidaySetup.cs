using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class HolidaySetup
    {
        public HolidaySetup()
        {
            this.HolidaySetupDetails = new List<HolidaySetupDetail>();
        }

        public int HolidaySetupID { get; set; }
        public int FacilityID { get; set; }
        public string Description { get; set; }
        public string HolidayYear { get; set; }
        public string SetupStartMonth { get; set; }
        public string SetupEndMonth { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual ICollection<HolidaySetupDetail> HolidaySetupDetails { get; set; }
    }
}