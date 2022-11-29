using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class PracticeFeeScheduleModel
    {
        public PracticeFeeScheduleModel()
        {
            this.PracticeFeeScheduleCharges = new List<PracticeFeeScheduleChargeModel>();
            this.ProviderFeeSchedules = new List<ProviderFeeScheduleModel>();
        }

        #region Model Properties
        public int PracticeFeeScheduleID { get; set; }
        public int ServiceProviderTypeID { get; set; }
        public Nullable<int> ServiceProviderID { get; set; }
        public int FeeScheduleID { get; set; }
        public string FeeScheduleNO { get; set; }
        public string CodeQualifier { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public decimal OverridedValueFromBase { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        #endregion

        #region Reference Properties
        public virtual ICollection<PracticeFeeScheduleChargeModel> PracticeFeeScheduleCharges { get; set; }
        public virtual ICollection<ProviderFeeScheduleModel> ProviderFeeSchedules { get; set; }

        #region Pager
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion

        #endregion

        #region Custom Properties
        public string ServiceProviderType { get; set; }
        public string ServiceProvider { get; set; }
        public string FeeScheduleTitle { get; set; }
        public string IsSearch { get; set; }

        #endregion
    }
}