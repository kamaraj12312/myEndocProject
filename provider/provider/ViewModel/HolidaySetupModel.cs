using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class HolidaySetupModel
    {
        public HolidaySetupModel()
        {
            this.HolidaySetupDetails = new List<HolidaySetupDetailModel>();
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
        public virtual FacilityModel Facility { get; set; }
        public virtual ICollection<HolidaySetupDetailModel> HolidaySetupDetails { get; set; }

        #region Custom Properties
        public string HolidaySetupTitle { get; set; }
        public string FacilityName { get; set; }
        public string IsSearch { get; set; }

        #endregion

        #region Search Properties
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        public Nullable<int> SearchFacilityID { get; set; }
        public string SearchHolidayYear { get; set; }
        public string SearchDescription { get; set; }
    }
}