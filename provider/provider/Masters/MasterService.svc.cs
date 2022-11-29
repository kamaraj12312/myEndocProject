using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace provider.Masters
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MasterService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MasterService.svc or MasterService.svc.cs at the Solution Explorer and start debugging.
    public class MasterService : IMasterService
    {
        public IList<AppointmentStatuModel> GetAppointmentStatus()
        {
            var query = from a in _uowMasterService.Repository<AppointmentStatu>().Table
                        where a.Deleted == false
                        orderby a.Code
                        select new AppointmentStatuModel
                        {
                            AppointmentStatusID = a.AppointmentStatusID,
                            Code = a.Code,
                            Description = a.Description,
                            Deleted = a.Deleted,
                            CreatedDate = a.CreatedDate,
                            CreatedBy = a.CreatedBy,
                            ModifiedDate = a.ModifiedDate,
                            ModifiedBy = a.ModifiedBy
                        };
            var appointmentStatus = query.ToList();
            return appointmentStatus;
        }

        public IList<RaceModel> GetRaces()
        {
            var query = from e in _uowMasterService.Repository<Race>().Table
                        where e.Deleted == false
            orderby e.RaceCode
                        select new RaceModel
                        {
                            RaceID = e.RaceID,
                            RaceCode = e.RaceCode,
                            Description = e.Description,
                            RaceOrder = e.RaceOrder,
                            Deleted = e.Deleted,
                            CreatedDate = e.CreatedDate,
                            CreatedBy = e.CreatedBy,
                            ModifiedDate = e.ModifiedDate,
                            ModifiedBy = e.ModifiedBy
                        };
            var raceList = query.ToList();
            return raceList;
        }

        public IList<EthnicityModel> GetEthnicities()
        {
            var query = from e in _uowMasterService.Repository<Ethnicity>().Table
                        where e.Deleted == false
                        orderby e.EthnicityCode
                        select new EthnicityModel
                        {
                            EthnicityID = e.EthnicityID,
                            EthnicityCode = e.EthnicityCode,
                            Description = e.Description,
                            EthnicityOrder = e.EthnicityOrder,
                            Deleted = e.Deleted,
                            CreatedDate = e.CreatedDate,
                            CreatedBy = e.CreatedBy,
                            ModifiedDate = e.ModifiedDate,
                            ModifiedBy = e.ModifiedBy
                        };
            var ethnicityList = query.ToList();
            return ethnicityList;
        }

        public IList<RegionalLanguageModel> GetRegionalLanguages()
        {
            var query = from l in _uowMasterService.Repository<RegionalLanguage>().Table
                        select new RegionalLanguageModel
                        {
                            RegionalLanguageID = l.RegionalLanguageID,
                            Code = l.Code,
                            Description = l.Description,
                        };
            var regionalLanguageList = query.ToList();
            return regionalLanguageList;
        }

        public IList<PatientRelationModel> GetPatientRelations()
        {
            var query = from pr in _uowMasterService.Repository<PatientRelation>().Table
                        where (!pr.Deleted)
                        select new PatientRelationModel
                        {
                            PatientRelationID = pr.PatientRelationID,
                            RelationCode = pr.RelationCode,
                            RelationDescription = pr.RelationDescription,
                            HIPAARelationCode = pr.HIPAARelationCode,
                            RelationOrder = pr.RelationOrder,
                            Deleted = pr.Deleted,
                            CreatedDate = pr.CreatedDate,
                            CreatedBy = pr.CreatedBy,
                            ModifiedDate = pr.ModifiedDate,
                            ModifiedBy = pr.ModifiedBy
                        };
            var patientRelations = query.ToList();
            return patientRelations;
        }

        public IList<PatientContactPersonTypeModel> GetPatientContactPersonTypes()
        {

            var query = from dt in _uowMasterService.Repository<PatientContactPersonType>().Table
                        where dt.Deleted == false
                        orderby dt.Code
                        select new PatientContactPersonTypeModel
                        {
                            PatientContactPersonTypeID = dt.PatientContactPersonTypeID,
                            Code = dt.Code,
                            Description = dt.Description
                        };

            var resultPatientContactPersonTypes = query.ToList();
            return resultPatientContactPersonTypes;
        }

        public IList<PatientRelationModel> GetPatientRelations()
        {
            var query = from pr in _uowMasterService.Repository<PatientRelation>().Table
                        where (!pr.Deleted)
                        select new PatientRelationModel
                        {
                            PatientRelationID = pr.PatientRelationID,
                            RelationCode = pr.RelationCode,
                            RelationDescription = pr.RelationDescription,
                            HIPAARelationCode = pr.HIPAARelationCode,
                            RelationOrder = pr.RelationOrder,
                            Deleted = pr.Deleted,
                            CreatedDate = pr.CreatedDate,
                            CreatedBy = pr.CreatedBy,
                            ModifiedDate = pr.ModifiedDate,
                            ModifiedBy = pr.ModifiedBy
                        };
            var patientRelations = query.ToList();
            return patientRelations;
        }
        public IList<InsuranceTypeModel> GetInsuranceTypes()
        {
            var query = from it in _uowMasterService.Repository<InsuranceType>().Table
                        where it.Deleted == false
                        orderby it.TypeDescription
                        select new InsuranceTypeModel
                        {
                            InsuranceTypeID = it.InsuranceTypeID,
                            TypeDescription = it.TypeDescription,
                            Deleted = it.Deleted,
                            CreatedDate = it.CreatedDate,
                            CreatedBy = it.CreatedBy,
                            ModifiedDate = it.ModifiedDate,
                            ModifiedBy = it.ModifiedBy
                        };
            var result = query.ToList();
            return result;
        }
        public IList<PatientDischargeStatusModel> GetPatientDischargeStatusList()
        {
            var patientDischargeStatus = (from pds in _uowMasterService.Repository<PatientDischargeStatus>().Table
                                          orderby pds.Code descending
                                          select new PatientDischargeStatusModel
                                          {
                                              PatientDischargeStatusID = pds.PatientDischargeStatusID,
                                              Code = pds.Code,
                                              Description = pds.Description,
                                              Deleted = pds.Deleted,
                                              CreatedDate = pds.CreatedDate,
                                              CreatedBy = pds.CreatedBy,
                                              ModifiedDate = pds.ModifiedDate,
                                              ModifiedBy = pds.ModifiedBy
                                          }).ToList();

            return patientDischargeStatus;
        }
        public IList<SourceOfAdmissionModel> GetSourceOfAdmissionList()
        {
            var sourceOfAdmission = (from soa in _uowMasterService.Repository<SourceOfAdmission>().Table
                                     orderby soa.Code descending
                                     select new SourceOfAdmissionModel
                                     {
                                         SourceOfAdmissionID = soa.SourceOfAdmissionID,
                                         Code = soa.Code,
                                         Description = soa.Description,
                                         Category = soa.Category,
                                         Deleted = soa.Deleted,
                                         CreatedDate = soa.CreatedDate,
                                         CreatedBy = soa.CreatedBy,
                                         ModifiedDate = soa.ModifiedDate,
                                         ModifiedBy = soa.ModifiedBy
                                     }).ToList();

            return sourceOfAdmission;
        }

        public IList<TypeOfSubmissionModel> GetTypeOfSubmissionList()
        {
            var typeOfSubmission = (from tos in _uowMasterService.Repository<TypeOfSubmission>().Table
                                    orderby tos.Code descending
                                    select new TypeOfSubmissionModel
                                    {
                                        TypeOfSubmissionID = tos.TypeOfSubmissionID,
                                        Code = tos.Code,
                                        Description = tos.Description,
                                        Deleted = tos.Deleted,
                                        CreatedDate = tos.CreatedDate,
                                        CreatedBy = tos.CreatedBy,
                                        ModifiedDate = tos.ModifiedDate,
                                        ModifiedBy = tos.ModifiedBy
                                    }).ToList();

            return typeOfSubmission;
        }
        public IList<HourCodeModel> GetHourCodeList()
        {
            var hourCode = (from hc in _uowMasterService.Repository<HourCode>().Table
                            orderby hc.Code descending
                            select new HourCodeModel
                            {

                                HourCodeID = hc.HourCodeID,
                                Code = hc.Code,
                                Description = hc.Description,
                                Deleted = hc.Deleted,
                                CreatedDate = hc.CreatedDate,
                                CreatedBy = hc.CreatedBy,
                                ModifiedDate = hc.ModifiedDate,
                                ModifiedBy = hc.ModifiedBy
                            }).ToList();

            return hourCode;
        }


    }
}
