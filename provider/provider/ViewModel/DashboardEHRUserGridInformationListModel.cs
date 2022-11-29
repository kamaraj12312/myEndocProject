using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class DashboardEHRUserGridInformationListModel
    {
        public bool isActive { get; set; }
        public string Patient { get; set; }
        public int Daily { get; set; }
        public int Weekly { get; set; }
        public int Monthly { get; set; }

        public string ClaimStatus { get; set; }

        public string TicketStatusDescription { get; set; }
        public int Open { get; set; }
        public int InProgress { get; set; }
        public int Completed { get; set; }
        public int Closed { get; set; }
        public int Cancelled { get; set; }

        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public Nullable<decimal> PayerBilledAmount { get; set; }
        public Nullable<decimal> PatientBilledAmount { get; set; }
        public Nullable<decimal> PayerBilledAmountToString { get; set; }
        public Nullable<decimal> PatientBilledAmountToString { get; set; }

        public Nullable<decimal> month1PayerBilledAmount { get; set; }
        public Nullable<decimal> month2PayerBilledAmount { get; set; }
        public Nullable<decimal> month3PayerBilledAmount { get; set; }
        public Nullable<decimal> month4PayerBilledAmount { get; set; }

        public Nullable<decimal> month1PatientBilledAmount { get; set; }
        public Nullable<decimal> month2PatientBilledAmount { get; set; }
        public Nullable<decimal> month3PatientBilledAmount { get; set; }
        public Nullable<decimal> month4PatientBilledAmount { get; set; }
        public Nullable<System.DateTime> AccountsReceivable { get; set; }
        public Nullable<System.DateTime> BilledDate { get; set; }

        public Nullable<decimal> PrimaryBilled { get; set; }
        public Nullable<decimal> SecondaryBilled { get; set; }
        public Nullable<decimal> TertiaryBilled { get; set; }

        public string criteria { get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }

        public string FacilityName { get; set; }
        public int FacilityID { get; set; }
    }
}