using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class DashboardRCMUserGridInformationListModel
    {
        public int ClaimID { get; set; }
        public int ClaimAcceptedCount { get; set; }

        public int ClaimSubmittedCount { get; set; }
        public int ClaimRejectedCount { get; set; }
        public string FacilityName { get; set; }
        public int FacilityID { get; set; }
        public int Daily { get; set; }
        public int Weekly { get; set; }
        public int YesterDay { get; set; }
        public string ClaimStatus { get; set; }
        public decimal DailyBA { get; set; }
        public decimal WeeklyBA { get; set; }
        public decimal YesterDayBA { get; set; }
        public Nullable<decimal> PayerBilledAmount { get; set; }
        public Nullable<decimal> PatientBilledAmount { get; set; }

        public Nullable<decimal> month1PayerBilledAmount { get; set; }
        public Nullable<decimal> month2PayerBilledAmount { get; set; }
        public Nullable<decimal> month3PayerBilledAmount { get; set; }
        public Nullable<decimal> month4PayerBilledAmount { get; set; }

        public decimal DailyPending { get; set; }
        public decimal YesterDayPending { get; set; }
        public decimal BilledAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public Nullable<decimal> BalanceAmount { get; set; }

        public Nullable<decimal> month1PatientBilledAmount { get; set; }
        public Nullable<decimal> month2PatientBilledAmount { get; set; }
        public Nullable<decimal> month3PatientBilledAmount { get; set; }
        public Nullable<decimal> month4PatientBilledAmount { get; set; }
        public Nullable<System.DateTime> AccountsReceivable { get; set; }
        public Nullable<System.DateTime> BilledDate { get; set; }

        public Nullable<decimal> PayerSubmitted { get; set; }
        public Nullable<decimal> PayerRecieved { get; set; }
        public Nullable<decimal> PayerBalance { get; set; }

        public Nullable<decimal> PatientSubmitted { get; set; }
        public Nullable<decimal> PatientRecieved { get; set; }
        public Nullable<decimal> PatientBalance { get; set; }

        public Nullable<decimal> PayerSubmittedAmount { get; set; }
        public Nullable<decimal> PayerRecievedAmount { get; set; }
        public Nullable<decimal> PayerBalanceAmount { get; set; }

        public Nullable<decimal> PatientSubmittedAmount { get; set; }
        public Nullable<decimal> PatientRecievedAmount { get; set; }
        public Nullable<decimal> PatientBalanceAmount { get; set; }

        public Nullable<int> TotalPendingClaim { get; set; }
        public Nullable<decimal> TotalPendingAmount { get; set; }
    }
}