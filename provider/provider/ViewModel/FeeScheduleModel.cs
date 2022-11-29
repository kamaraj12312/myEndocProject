using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class FeeScheduleModel
    {
        public FeeScheduleModel()
        {
            this.FeeScheduleCharges = new List<FeeScheduleChargeModel>();
        }

        #region Model Properties
        public int FeeScheduleID { get; set; }
        public string FeeScheduleNO { get; set; }
        public string CodeQualifier { get; set; }
        public string FeeScheduleStatus { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        #endregion

        #region Reference Properties
        public virtual ICollection<FeeScheduleChargeModel> FeeScheduleCharges { get; set; }

        #region Pager
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion

        #endregion
    }
}