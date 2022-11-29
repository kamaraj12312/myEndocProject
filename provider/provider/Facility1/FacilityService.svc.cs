using provider.Enitity_Model;
using provider.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace provider.Facility1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FacilityService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FacilityService.svc or FacilityService.svc.cs at the Solution Explorer and start debugging.
    public class FacilityService : IFacilityService
    {
        public IList<FacilityModel> GetFacilityDetails()
        {
            var query = from fm in _uowFacilityService.Repository<Facility>().Table
                        where (!fm.Deleted)
                        orderby fm.FacilityName ascending
                        select new FacilityModel
                        {
                            FacilityID = fm.FacilityID,
                            GroupFacilityID = fm.GroupFacilityID,
                            NPI = fm.NPI,
                            TaxID = fm.TaxID,
                            FacilityName = fm.FacilityName,
                            OtherName = fm.OtherName,

                        };
            var facilityDetails = query.ToList();

            foreach (FacilityModel item in facilityDetails.ToList())
            {
                item.TaxID = BmsCommonUtility.FormatStrings(item.TaxID, BmsCommonUtility.FormatStringTypes.TaxId);
            }

            return facilityDetails;
        }

        public IList<FeeScheduleModel> GetFeeSchedules()
        {
            var query = from fs in _uowFacilityService.Repository<FeeSchedule>().Table
                        orderby fs.FeeScheduleNO ascending
                        where (!fs.Deleted)
                        select new FeeScheduleModel
                        {
                            FeeScheduleID = fs.FeeScheduleID,
                            FeeScheduleNO = fs.FeeScheduleNO,
                            CodeQualifier = fs.CodeQualifier,
                            FeeScheduleStatus = fs.FeeScheduleStatus,
                            EffectiveDate = fs.EffectiveDate,
                            TerminationDate = fs.TerminationDate
                        };
            var feeSchedules = query.Distinct().ToList();
            return feeSchedules;
        }

        public IList<PracticeFeeScheduleModel> GetFeeScheuleNos()
        {
            var query = from pfs in _uowFacilityService.Repository<PracticeFeeSchedule>().Table
                        orderby pfs.FeeScheduleNO ascending
                        where (!pfs.Deleted)
                        select new PracticeFeeScheduleModel
                        {
                            PracticeFeeScheduleID = pfs.PracticeFeeScheduleID,
                            FeeScheduleNO = pfs.FeeScheduleNO,
                            Description = pfs.Description
                        };
            var feeScheduleNos = query.Distinct().ToList();
            return feeScheduleNos;
        }

        public IList<FacilityModel> GetFacilitiesForAppointment()
        {

            var query = (from fm in _uowFacilityService.Repository<Facility>().Table
                         join cm in _uowFacilityService.Repository<CommonMaster>().Table on fm.BillingLocation equals cm.CommonMasterID
                         into billingLocationJoin
                         from bl in billingLocationJoin.DefaultIfEmpty()
                         where (!fm.Deleted && bl.Description.Trim().ToUpper() != "BILLING")
                         orderby fm.FacilityName ascending
                         select new
                         {
                             FacilityID = fm.FacilityID,
                             GroupFacilityID = fm.GroupFacilityID,
                             NPI = fm.NPI,
                             TaxID = fm.TaxID,
                             FacilityName = fm.FacilityName,
                             OtherName = fm.OtherName,

                         }).AsEnumerable().Select(x => new FacilityModel
                         {
                             FacilityID = x.FacilityID,
                             GroupFacilityID = x.GroupFacilityID,
                             NPI = x.NPI,
                             TaxID = BmsCommonUtility.FormatStrings(x.TaxID, BmsCommonUtility.FormatStringTypes.TaxId),
                             FacilityName = x.FacilityName,
                             OtherName = x.OtherName,
                         }
                        ).ToList();
            var facilityDetails = query.ToList();


            return facilityDetails;

        }

    }
}
