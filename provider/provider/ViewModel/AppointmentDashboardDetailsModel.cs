using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public partial class AppointmentDashboardDetailsModel
    {
        //public AppointmentDashboardDetailsModel(string appointmentType, int todayCount, int weeklyCount, int monthlyCount)
        //{
        //    this.AppointmentType = appointmentType;
        //    this.TodayCount = todayCount;
        //    this.WeeklyCount = weeklyCount;
        //    this.MonthlyCount = monthlyCount;
        //}
        public string AppointmentType { get; set; }
        public int TodayCount { get; set; }
        public int WeeklyCount { get; set; }
        public int MonthlyCount { get; set; }
    }
}