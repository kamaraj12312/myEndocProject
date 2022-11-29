using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.ServiceModel;
using System.Text;

namespace provider.Users
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        public IList<DashboardClientSetupModel> GetClientListForDashboard()
        {
            var query = (from cl in _uowUserService.Repository<ClientSetup>().Table
                         join ca in _uowUserService.Repository<ClientAccountSetup>().Table on cl.ClientSetupID equals ca.ClientSetupID
                         join pr in _uowUserService.Repository<Product>().Table on ca.ProductID equals pr.ProductID
                         where (!cl.Deleted) && (!ca.Deleted)
                         orderby cl.ClientName ascending
                         select new DashboardClientSetupModel
                         {
                             ClientName = cl.ClientName,
                             ProductName = pr.ProductName,
                             ProductActiveFrom = ca.ActivateFrom,
                             ProductActivateTo = ca.ActivateTo
                         });

            var clientInfo = query.ToList();
            return clientInfo;
        }

        public IList<DashboardInquiryModel> GetInquiryListForDashboard()
        {
            var query = (from iq in _uowUserService.Repository<Inquiry>().Table
                         where (!iq.Deleted)
                         orderby iq.CreatedDate descending
                         select new DashboardInquiryModel
                         {
                             CreatedDate = iq.CreatedDate,
                             InquirerName = (iq.NameFirst == null ? "" : iq.NameFirst) + " " + (iq.NameLast == null ? "" : iq.NameLast),
                             InterestedProductID = iq.InterestedProductID
                         });

            var inquiryList = query.ToList();
            return inquiryList;
        }

        public IList<DashboardInquiryDetailModel> GetInquiryFollowupListForDashboard()
        {
            var query = (from iqd in _uowUserService.Repository<InquiryDetail>().Table
                         join iq in _uowUserService.Repository<Inquiry>().Table on iqd.InquiryID equals iq.InquiryID
                         join sp in _uowUserService.Repository<SalesPerson>().Table on iqd.SalesPersonID equals sp.SalesPersonID
                         where (!iqd.Deleted) && (!iq.Deleted) && (!sp.Deleted)
                         select new DashboardInquiryDetailModel
                         {
                             SalesPersonName = (sp.NameFirst == null ? "" : sp.NameFirst) + " " + (sp.NameLast == null ? "" : sp.NameLast),
                             InquirerName = (iq.NameFirst == null ? "" : iq.NameFirst) + " " + (iq.NameLast == null ? "" : iq.NameLast),
                             CreatedDate = iq.CreatedDate,
                             InterestedProductID = iq.InterestedProductID,
                             NextFollowupDateTime = iqd.NextFollowupDateTime
                         });

            var inquiryFollowup = query.ToList();
            return inquiryFollowup;
        }

        public IList<DashboardBillModel> GetBillListForDashboard()
        {
            var query = (from bl in _uowUserService.Repository<Bill>().Table
                         join ca in _uowUserService.Repository<ClientSetup>().Table on bl.ClientID equals ca.ClientSetupID
                         join pr in _uowUserService.Repository<Product>().Table on bl.ProductID equals pr.ProductID
                         where (!bl.Deleted) && (!ca.Deleted)
                         select new DashboardBillModel
                         {
                             ClientName = ca.ClientName,
                             ProductName = pr.ProductName,
                             Amount = bl.Amount

                         });

            var bill = query.ToList();
            return bill;
        }
        public IList<DashboardReceiptModel> GetReceiptListForDashboard()
        {
            var query = (from rs in _uowUserService.Repository<Receipt>().Table
                         join bl in _uowUserService.Repository<Bill>().Table on rs.BillID equals bl.BillID
                         join ca in _uowUserService.Repository<ClientSetup>().Table on bl.ClientID equals ca.ClientSetupID
                         join pr in _uowUserService.Repository<Product>().Table on bl.ProductID equals pr.ProductID
                         where (!bl.Deleted) && (!ca.Deleted)
                         select new DashboardReceiptModel
                         {
                             ReceiptNo = rs.ReceiptNo,
                             ClientName = ca.ClientName,
                             ProductName = pr.ProductName,
                             ReceivedAmount = rs.ReceivedAmount
                         });

            var recipt = query.ToList();
            return recipt;
        }
        public IList<UserModel> GetUsers()
        {
            var query = from us in _uowUserService.Repository<User>().Table
                        where (!us.Deleted)
                        orderby us.UserName ascending
                        select new UserModel
                        {
                            UserID = us.UserID,
                            UserName = us.UserName
                        };
            var userData = query.ToList();
            return userData;
        }
        public IList<ModuleSetupModel> GetModuleSetups()
        {
            var query = from ms in _uowUserService.Repository<ModuleSetup>().Table
                        orderby ms.ModuleName ascending
                        select new ModuleSetupModel
                        {
                            ModuleSetupID = ms.ModuleSetupID,
                            ModuleName = ms.ModuleName,
                            ModuleDescription = ms.ModuleDescription,
                            ControllerName = ms.MenuActionLink,
                            MainIconPath = ms.MainIconPath,
                            SubIconPath = ms.SubIconPath
                        };
            var result = query.ToList();
            return result;
        }
        public IList<DepartmentModel> GetDepartmentList()
        {
            var query = from dpt in _uowUserService.Repository<Department>().Table
                        where (!dpt.Deleted)
                        orderby dpt.DepartmentName ascending
                        select new DepartmentModel
                        {
                            DepartmentID = dpt.DepartmentID,
                            DepartmentName = dpt.DepartmentName,
                            Deleted = dpt.Deleted,
                            CreatedDate = dpt.CreatedDate,
                            CreatedBy = dpt.CreatedBy,
                            ModifiedDate = dpt.ModifiedDate,
                            ModifiedBy = dpt.ModifiedBy
                        };
            var departmentResult = query.ToList();
            return departmentResult;
        }
        public IList<DashboardRCMUserGridInformationListModel> GetRCMUsersPaymentEnteredDashboardList()
        {
            DateTime dtToday = DateTime.Now;

            var billedAmount = (from c in _uowUserService.Repository<Claim>().Table
                                join f in _uowUserService.Repository<Facility>().Table on c.FacilityID equals f.FacilityID
                                into fac
                                from f in fac.DefaultIfEmpty()
                                join cs in _uowUserService.Repository<ClaimStatus>().Table on c.ClaimStatusID equals cs.ClaimStatusID
                                where SqlFunctions.DateDiff("MM", c.ClaimSubmittedDate, dtToday) < 2 && cs.Code == "PI"
                                orderby c.ClaimSubmittedDate descending
                                select new
                                {
                                    FacilityID = f.FacilityID,
                                    FacilityName = f.FacilityName,
                                    ClaimStatus = cs.Description,
                                    DailyBA = (DbFunctions.TruncateTime(c.ClaimSubmittedDate) == DbFunctions.TruncateTime(dtToday)) ? c.TotalCharges : 0,
                                    YesterDayBA = (DbFunctions.TruncateTime(c.ClaimSubmittedDate) == DbFunctions.TruncateTime(DbFunctions.AddDays(dtToday, -1))) ? c.TotalCharges : 0,
                                    WeeklyBA = ((DbFunctions.TruncateTime(c.ClaimSubmittedDate) >= DbFunctions.AddDays(dtToday, -7) && DbFunctions.TruncateTime(c.ClaimSubmittedDate) <= DbFunctions.TruncateTime(dtToday)) ? c.TotalCharges : 0),
                                });



            var billedAmountList = (from a in billedAmount
                                    group a by a.FacilityName into ag
                                    select new DashboardRCMUserGridInformationListModel
                                    {
                                        FacilityName = ag.Key,
                                        DailyBA = ag.Sum(t => t.DailyBA),
                                        YesterDayBA = ag.Sum(t => t.YesterDayBA),
                                        WeeklyBA = ag.Sum(t => t.WeeklyBA),
                                        //FacilityName = ag.Contains(t => t.)
                                    });
            var billedAmountresult = billedAmountList.ToList();
            return billedAmountresult;
        }
        public IList<DashboardEHRUserGridInformationListModel> GetPatientBilledAmountForDashboardAccountsReceivable()
        {

            //List<int> EDIGenStatus = new List<string> { "1", "2" };  //need to skip New and Generated

            DateTime dtToday = DateTime.Now;

            //Medical claim
            var medClaimAmmountReceivalbleAgingByPayer = (from edi in _uowUserService.Repository<EDI837PTransaction>().Table.Where(x => !x.Deleted && (x.EDIGeneratedStatusID != 1 && x.EDIGeneratedStatusID != 2) && (x.BilledAmount - x.PaidByInsurance) > 0)
                                                          select new DashboardEHRUserGridInformationListModel
                                                          {
                                                              ClaimStatus = "RE",
                                                              month1PayerBilledAmount = edi.SentDate >= (DbFunctions.AddDays(dtToday, -30)) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                              month1PatientBilledAmount = 0,

                                                              month2PayerBilledAmount = (edi.SentDate < (DbFunctions.AddDays(dtToday, -30)) && edi.SentDate >= (DbFunctions.AddDays(dtToday, -60))) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                              month2PatientBilledAmount = 0,

                                                              month3PayerBilledAmount = (edi.SentDate < (DbFunctions.AddDays(dtToday, -60)) && edi.SentDate >= (DbFunctions.AddDays(dtToday, -90))) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                              month3PatientBilledAmount = 0,

                                                              month4PayerBilledAmount = (edi.SentDate > (DbFunctions.AddDays(dtToday, -90))) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                              month4PatientBilledAmount = 0,
                                                          }).ToList();
            //Hospital claim
            var hospClaimAmmountReceivalbleAgingByPayer = (from edi in _uowUserService.Repository<EDIHospitalClaimSubmittedHistory>().Table.Where(x => !x.Deleted && (x.EDIGeneratedStatusID != 1 && x.EDIGeneratedStatusID != 2) && (x.BilledAmount - x.PaidByInsurance) > 0)
                                                           select new DashboardEHRUserGridInformationListModel
                                                           {
                                                               ClaimStatus = "RE",
                                                               month1PayerBilledAmount = edi.SentDate >= (DbFunctions.AddDays(dtToday, -30)) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                               month1PatientBilledAmount = 0,

                                                               month2PayerBilledAmount = (edi.SentDate < (DbFunctions.AddDays(dtToday, -30)) && edi.SentDate >= (DbFunctions.AddDays(dtToday, -60))) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                               month2PatientBilledAmount = 0,

                                                               month3PayerBilledAmount = (edi.SentDate < (DbFunctions.AddDays(dtToday, -60)) && edi.SentDate >= (DbFunctions.AddDays(dtToday, -90))) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                               month3PatientBilledAmount = 0,

                                                               month4PayerBilledAmount = (edi.SentDate > (DbFunctions.AddDays(dtToday, -90))) ? (edi.BilledAmount - edi.PaidByInsurance) : 0,
                                                               month4PatientBilledAmount = 0,
                                                           }).ToList();

            ////Combine hospital and medical claim
            //var ammountReceivalbleAgingByPayer = medClaimAmmountReceivalbleAgingByPayer.Concat(hospClaimAmmountReceivalbleAgingByPayer)
            //                                            .GroupBy(t => t.StatusCode).Select(
            //                                                         t => new DashboardEHRUserGridInformationListModel
            //                                                         {
            //                                                             ProviderName = t.Key,
            //                                                             month1PayerBilledAmount = t.Sum(x => x.Month1PayerBilled),
            //                                                             month1PatientBilledAmount = t.Sum(x => x.Month2PatientBilled),
            //                                                             month2PayerBilledAmount = t.Sum(x => x.Month2PayerBilled),
            //                                                             month2PatientBilledAmount = t.Sum(x => x.Month2PatientBilled),
            //                                                             month3PayerBilledAmount = t.Sum(x => x.Month3PayerBilled),
            //                                                             month3PatientBilledAmount = t.Sum(x => x.Month3PatientBilled),
            //                                                             month4PayerBilledAmount = t.Sum(x => x.Month4PayerBilled),
            //                                                             month4PatientBilledAmount = t.Sum(x => x.Month4PatientBilled)
            //                                                         }).ToList();

            var ammountReceivalbleAgingBYPatient = (from cb in _uowUserService.Repository<ClaimBill>().Table.Where(y => !y.Deleted && (y.Charges - y.PaidByPatient) > 0)
                                                    select new DashboardEHRUserGridInformationListModel
                                                    {
                                                        ClaimStatus = "RE",
                                                        month1PayerBilledAmount = 0,
                                                        month1PatientBilledAmount = cb.BillDate >= (DbFunctions.AddDays(dtToday, -30)) ? (cb.Charges - cb.PaidByInsurance) : 0,

                                                        month2PayerBilledAmount = 0,
                                                        month2PatientBilledAmount = (cb.BillDate < (DbFunctions.AddDays(dtToday, -30)) && cb.BillDate >= (DbFunctions.AddDays(dtToday, -60))) ? (cb.Charges - cb.PaidByInsurance) : 0,

                                                        month3PayerBilledAmount = 0,
                                                        month3PatientBilledAmount = (cb.BillDate < (DbFunctions.AddDays(dtToday, -60)) && cb.BillDate >= (DbFunctions.AddDays(dtToday, -90))) ? (cb.Charges - cb.PaidByInsurance) : 0,

                                                        month4PayerBilledAmount = 0,
                                                        month4PatientBilledAmount = (cb.BillDate > (DbFunctions.AddDays(dtToday, -90))) ? (cb.Charges - cb.PaidByInsurance) : 0,
                                                    }).ToList();

            //.AsEnumerable().GroupBy(t => t.StatusCode).Select(
            //                                             t => new DashboardEHRUserGridInformationListModel
            //                                             {
            //                                                 ProviderName = t.Key,
            //                                                 month1PayerBilledAmount = t.Sum(x => x.Month1PayerBilled),
            //                                                 month1PatientBilledAmount = t.Sum(x => x.Month2PatientBilled),
            //                                                 month2PayerBilledAmount = t.Sum(x => x.Month2PayerBilled),
            //                                                 month2PatientBilledAmount = t.Sum(x => x.Month2PatientBilled),
            //                                                 month3PayerBilledAmount = t.Sum(x => x.Month3PayerBilled),
            //                                                 month3PatientBilledAmount = t.Sum(x => x.Month3PatientBilled),
            //                                                 month4PayerBilledAmount = t.Sum(x => x.Month4PayerBilled),
            //                                                 month4PatientBilledAmount = t.Sum(x => x.Month4PatientBilled)
            //                                             }).ToList()

            var ammountReceivalbleAsAging = medClaimAmmountReceivalbleAgingByPayer.Concat(hospClaimAmmountReceivalbleAgingByPayer).Concat(ammountReceivalbleAgingBYPatient)
                        .GroupBy(x => x.ClaimStatus).Select(
                          t => new DashboardEHRUserGridInformationListModel
                          {
                              month1PayerBilledAmount = t.Sum(x => x.month1PayerBilledAmount),
                              month1PatientBilledAmount = t.Sum(x => x.month1PatientBilledAmount),
                              month2PayerBilledAmount = t.Sum(x => x.month2PayerBilledAmount),
                              month2PatientBilledAmount = t.Sum(x => x.month2PatientBilledAmount),
                              month3PayerBilledAmount = t.Sum(x => x.month3PayerBilledAmount),
                              month3PatientBilledAmount = t.Sum(x => x.month3PatientBilledAmount),
                              month4PayerBilledAmount = t.Sum(x => x.month4PayerBilledAmount),
                              month4PatientBilledAmount = t.Sum(x => x.month4PatientBilledAmount)
                          }).ToList();


            return ammountReceivalbleAsAging;
        }
        public IList<DashboardRCMUserGridInformationListModel> DashboardRCMUserPayerPatientInformationByClaimStatus()
        {
            List<string> claimStatus = new List<string>() { "SB", "PI" };

            var payerPatientMedClaimPaymentInfo = (from c in _uowUserService.Repository<Claim>().Table.Where(t => !t.Deleted)
                                                   join cs in _uowUserService.Repository<ClaimStatus>().Table.Where(t => claimStatus.Contains(t.Code)) on c.ClaimStatusID equals cs.ClaimStatusID
                                                   join edi in _uowUserService.Repository<EDI837PTransaction>().Table.Where(y => !y.Deleted) on c.ClaimID equals edi.ClaimID into ed
                                                   from e in ed.DefaultIfEmpty()
                                                   join cb in _uowUserService.Repository<ClaimBill>().Table.Where(z => !z.Deleted && z.ClaimTypeCode.Equals("M")) on c.ClaimID equals cb.ClaimID into bill
                                                   from cl in bill.DefaultIfEmpty()
                                                   select new DashboardRCMUserGridInformationListModel
                                                   {
                                                       ClaimStatus = cs.Code,
                                                       PayerSubmitted = (e != null ? (e.TotalCharges != null ? e.TotalCharges : 0) ?? 0 : 0),
                                                       PatientSubmitted = (cl != null ? (cl.Charges != null ? cl.Charges : 0) : 0),

                                                       PayerRecieved = (e != null ? (e.PaidByInsurance != null ? e.PaidByInsurance : 0) ?? 0 : 0),
                                                       PatientRecieved = (cl != null ? (cl.PaidByPatient != null ? cl.PaidByPatient : 0) : 0),

                                                       PayerBalance = (e != null ? ((e.TotalCharges != null ? e.TotalCharges : 0) - (e.PaidByInsurance != null ? e.PaidByInsurance : 0)) ?? 0 : 0),
                                                       PatientBalance = (cl != null ? ((cl.Charges != null ? cl.Charges : 0) - (cl.PaidByPatient != null ? cl.PaidByPatient : 0)) : 0),
                                                   });

            var payerPatientHospClaimPaymentInfo = (from c in _uowUserService.Repository<HospitalClaim>().Table.Where(t => !t.Deleted)
                                                    join cs in _uowUserService.Repository<ClaimStatus>().Table.Where(t => claimStatus.Contains(t.Code)) on c.ClaimStatusID equals cs.ClaimStatusID
                                                    join edi in _uowUserService.Repository<EDIHospitalClaimSubmittedHistory>().Table.Where(y => !y.Deleted) on c.HospitalClaimID equals edi.HospitalClaimID into ed
                                                    from e in ed.DefaultIfEmpty()
                                                    join cb in _uowUserService.Repository<ClaimBill>().Table.Where(z => !z.Deleted && z.ClaimTypeCode.Equals("H")) on c.HospitalClaimID equals cb.ClaimID into bill
                                                    from cl in bill.DefaultIfEmpty()
                                                    select new DashboardRCMUserGridInformationListModel
                                                    {
                                                        ClaimStatus = cs.Code,
                                                        PayerSubmitted = (e != null ? (e.TotalCharges != null ? e.TotalCharges : 0) : 0),
                                                        PatientSubmitted = (cl != null ? (cl.Charges != null ? cl.Charges : 0) : 0),

                                                        PayerRecieved = (e != null ? (e.PaidByInsurance != null ? e.PaidByInsurance : 0) ?? 0 : 0),
                                                        PatientRecieved = (cl != null ? (cl.PaidByPatient != null ? cl.PaidByPatient : 0) : 0),

                                                        PayerBalance = (e != null ? ((e.TotalCharges != null ? e.TotalCharges : 0) - (e.PaidByInsurance != null ? e.PaidByInsurance : 0)) ?? 0 : 0),
                                                        PatientBalance = (cl != null ? ((cl.Charges != null ? cl.Charges : 0) - (cl.PaidByPatient != null ? cl.PaidByPatient : 0)) : 0),
                                                    });

            //combine medical and hospital claim and aggregate the values
            var payerPatientPaymentInfo = payerPatientMedClaimPaymentInfo.Concat(payerPatientHospClaimPaymentInfo).ToList().GroupBy(g => g.ClaimStatus).Select(
                                                ag => new DashboardRCMUserGridInformationListModel
                                                {
                                                    ClaimStatus = ag.Key,
                                                    PayerSubmittedAmount = ag.Sum(t => t.PayerSubmitted),
                                                    PatientSubmittedAmount = ag.Sum(t => t.PatientSubmitted),
                                                    PayerRecievedAmount = ag.Sum(t => t.PayerRecieved),
                                                    PatientRecievedAmount = ag.Sum(t => t.PatientRecieved),
                                                    PayerBalanceAmount = ag.Sum(t => t.PayerBalance),
                                                    PatientBalanceAmount = ag.Sum(t => t.PatientBalance),
                                                }).ToList();

            return payerPatientPaymentInfo;
        }
        public IList<DashboardRCMUserGridInformationListModel> GetRCMAdminPaymentsReceived()
        {
            DateTime dtToday = DateTime.Now;

            //medical claim
            var medClaimInsPayments = (from pa in _uowUserService.Repository<EDI835ClaimResponseDetails>().Table
                                       where !pa.Deleted && (SqlFunctions.DateDiff("WW", pa.CreatedDate, dtToday) == 0 || (DbFunctions.TruncateTime(pa.CreatedDate) == DbFunctions.TruncateTime(SqlFunctions.DateAdd("DD", -(dtToday.Day), dtToday))))
                                       select new
                                       {
                                           Code = "CB",
                                           Daily = (DbFunctions.TruncateTime(pa.CreatedDate) == DbFunctions.TruncateTime(dtToday)) ? pa.InsurancePaidAmount : 0,
                                           YesterDay = (DbFunctions.TruncateTime(pa.CreatedDate) == DbFunctions.TruncateTime(DbFunctions.AddDays(dtToday, -1))) ? pa.InsurancePaidAmount : 0,
                                           Weekly = (SqlFunctions.DateDiff("WW", pa.CreatedDate, dtToday) == 0) ? pa.InsurancePaidAmount : 0,
                                       });
            //hospital claim
            var medClaimPatientPayments = (from pp in _uowUserService.Repository<ClaimReceipt>().Table
                                           where !pp.Deleted && (SqlFunctions.DateDiff("WW", pp.ReceiptDate, dtToday) == 0 || (DbFunctions.TruncateTime(pp.ReceiptDate) == DbFunctions.TruncateTime(SqlFunctions.DateAdd("DD", -(dtToday.Day), dtToday))))
                                           select new
                                           {
                                               Code = "CB",
                                               Daily = (DbFunctions.TruncateTime(pp.ReceiptDate) == DbFunctions.TruncateTime(dtToday)) ? pp.PaidAmount : 0,
                                               YesterDay = (DbFunctions.TruncateTime(pp.ReceiptDate) == DbFunctions.TruncateTime(DbFunctions.AddDays(dtToday, -1))) ? pp.PaidAmount : 0,
                                               Weekly = (SqlFunctions.DateDiff("WW", pp.ReceiptDate, dtToday) == 0) ? pp.PaidAmount : 0,
                                           });

            //combine medical and hospital claim
            var allClaimPayments = medClaimInsPayments.Concat(medClaimPatientPayments).GroupBy(t => t.Code).Select(
                        t => new DashboardRCMUserGridInformationListModel
                        {
                            DailyBA = t.Sum(x => x.Daily),
                            YesterDayBA = t.Sum(x => x.YesterDay),
                            WeeklyBA = t.Sum(x => x.Weekly)
                        }).ToList();

            return allClaimPayments;
        }
        public IList<DashboardRCMUserGridInformationListModel> GetRCMAdminPaymentsPending()
        {
            List<string> claimStatus = new List<string> { "NW", "GE" };  //this codes needs to be exclude  "New and Generated"

            //Medical Claim
            var medClaimPendingPayment = (from c in _uowUserService.Repository<Claim>().Table.Where(t => !t.Deleted)
                                          join cs in _uowUserService.Repository<ClaimStatus>().Table.Where(t => !claimStatus.Contains(t.Code)) on c.ClaimStatusID equals cs.ClaimStatusID
                                          select new
                                          {
                                              ClaimStatus = "PP",
                                              PendingPayments = (c.TotalCharges - (c.PaidByPatient + c.PaidByInsurance)),
                                          });
            //Hospital Claim                                     
            var hospClaimPendingPayment = (from c in _uowUserService.Repository<HospitalClaim>().Table.Where(t => !t.Deleted)
                                           join cs in _uowUserService.Repository<ClaimStatus>().Table.Where(t => !claimStatus.Contains(t.Code)) on c.ClaimStatusID equals cs.ClaimStatusID
                                           select new
                                           {
                                               ClaimStatus = "PP",
                                               PendingPayments = (c.TotalCharges - (c.PaidByPatient + c.PaidByInsurance)),
                                           });

            //Combine Medical and hospital claim
            var allClaimPendingPayment = medClaimPendingPayment.Concat(hospClaimPendingPayment)
                                     .GroupBy(t => t.ClaimStatus).Select(
                                            t => new DashboardRCMUserGridInformationListModel
                                            {
                                                TotalPendingClaim = t.Count(),
                                                TotalPendingAmount = t.Sum(x => x.PendingPayments)
                                            }).ToList();

            return allClaimPendingPayment;
        }
        public IList<DashboardRCMUserGridInformationListModel> GetEHRAdminPayerClaimStatus()
        {
            DateTime dtToday = DateTime.Now;
            var claimSubmitted = from Edi in _uowUserService.Repository<EDI837PTransaction>().Table
                                 join cs in _uowUserService.Repository<ClaimStatus>().Table on Edi.ClaimStatusID equals cs.ClaimStatusID
                                 into cStatus
                                 from cs in cStatus.DefaultIfEmpty()
                                 where (cs.Code == "SB" || cs.Code == "PI")
                                 select new
                                 {
                                     ClaimId = cs.Description,
                                     submitted = Edi.TotalCharges,
                                     Claimstatus = cs.Code,
                                     Accepted = Edi.PaidByInsurance,
                                     Rejected = ((Edi.TotalCharges == null ? 0 : Edi.TotalCharges) - ((Edi.PaidByPatient == null ? 0 : Edi.PaidByPatient) + (Edi.PaidByInsurance == null ? 0 : Edi.PaidByInsurance)))

                                 };

            var claimSubmittedList = (from a in claimSubmitted
                                      group a by a.ClaimId into ag
                                      select new DashboardRCMUserGridInformationListModel
                                      {
                                          ClaimStatus = ag.Key,

                                          PayerSubmittedAmount = ag.Sum(t => t.submitted),
                                          PayerRecievedAmount = ag.Sum(t => t.Accepted),
                                          PayerBalanceAmount = ag.Sum(t => t.Rejected),
                                          ClaimSubmittedCount = ag.Count(t => t.Claimstatus == "SB"),
                                          ClaimAcceptedCount = ag.Count(t => t.Claimstatus == "PI"),
                                          ClaimRejectedCount = ag.Count(t => t.Claimstatus == "DE")
                                      });
            var claimSubmittedresult = claimSubmittedList.ToList();
            return claimSubmittedresult;

        }
        public IList<DashboardRCMUserGridInformationListModel> GetEHRAdminPayerClaimSubmitted()
        {
            List<string> claimStatus = new List<string>() { "SB", "SE", "PP", "PI", "CL", "RS", "DE" };

            //medical claim
            var medClaimSubmitted = (from Edi in _uowUserService.Repository<EDI837PTransaction>().Table
                                     join cs in _uowUserService.Repository<ClaimStatus>().Table.Where(t => claimStatus.Contains(t.Code)) on Edi.ClaimStatusID equals cs.ClaimStatusID
                                     select new DashboardRCMUserGridInformationListModel
                                     {
                                         ClaimStatus = cs.Description,
                                         PayerSubmittedAmount = (Edi.TotalCharges == null ? 0 : Edi.TotalCharges),
                                         PayerRecievedAmount = (Edi.PaidByInsurance == null ? 0 : Edi.PaidByInsurance),
                                         PayerBalanceAmount = ((Edi.TotalCharges == null ? 0 : Edi.TotalCharges) - (Edi.PaidByPatient == null ? 0 : Edi.PaidByPatient))
                                     });

            //hospital claim
            var hospClaimSubmitted = (from Edi in _uowUserService.Repository<EDIHospitalClaimSubmittedHistory>().Table
                                      join cs in _uowUserService.Repository<ClaimStatus>().Table.Where(t => claimStatus.Contains(t.Code)) on Edi.ClaimStatusID equals cs.ClaimStatusID
                                      select new DashboardRCMUserGridInformationListModel
                                      {
                                          ClaimStatus = cs.Description,
                                          PayerSubmittedAmount = (Edi.TotalCharges == null ? 0 : Edi.TotalCharges),
                                          PayerRecievedAmount = (Edi.PaidByInsurance == null ? 0 : Edi.PaidByInsurance),
                                          PayerBalanceAmount = ((Edi.TotalCharges == null ? 0 : Edi.TotalCharges) - (Edi.PaidByPatient == null ? 0 : Edi.PaidByPatient))
                                      });

            //combine medical and hospital claim
            var claimSubmittedList = medClaimSubmitted.Concat(hospClaimSubmitted).GroupBy(g => g.ClaimStatus).Select(
                        ag => new DashboardRCMUserGridInformationListModel
                        {
                            ClaimStatus = ag.Key,
                            PayerSubmittedAmount = ag.Sum(t => t.PayerSubmittedAmount),
                            PayerRecievedAmount = ag.Sum(t => t.PayerRecievedAmount),
                            PayerBalanceAmount = ag.Sum(t => t.PayerBalanceAmount)
                        }).ToList();

            return claimSubmittedList;

        }

        public IList<RxOrderServiceUserSetupModel> GetAllRxOrderServiceUserSetup()
        {
            var query = (from r in _uowUserService.Repository<RxOrderServiceUserSetup>().Table
                         where (!r.Deleted)
                         select new RxOrderServiceUserSetupModel
                         {
                             RxOrderServiceUserSetupID = r.RxOrderServiceUserSetupID,
                             UserName = r.UserName,
                             Password = r.Password,
                             UserCredential = r.UserCredential,
                             CreatedDate = r.CreatedDate,
                             CreatedBy = r.CreatedBy,
                             ModifiedDate = r.ModifiedDate,
                             ModifiedBy = r.ModifiedBy

                         }
                           ).AsEnumerable().Select(x => new RxOrderServiceUserSetupModel
                           {
                               RxOrderServiceUserSetupID = x.RxOrderServiceUserSetupID,
                               UserName = x.UserName,
                               Password = Decrypt(x.Password),
                               UserCredential = x.UserCredential,
                               CreatedDate = x.CreatedDate,
                               CreatedBy = x.CreatedBy,
                               ModifiedDate = x.ModifiedDate,
                               ModifiedBy = x.ModifiedBy


                           }).ToList();
            // var Password = new IList<RxOrderServiceUserSetup> { List = query.ToList(), TotalCount = query.TotalItemCount };

            return query;
        }


    }
}
