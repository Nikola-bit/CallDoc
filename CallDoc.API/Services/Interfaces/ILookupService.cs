using CallDoc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Services
{
    public interface ILookupService
    {

        #region Platform Configuration

        public List<PlatformConfigurationDTO> AppointmentStatuses();
        public List<PlatformConfigurationDTO> InstitutionStatuses();
        public List<PlatformConfigurationDTO> MemberTypes();
        public List<PlatformConfigurationDTO> MemberStatuses();
        public List<PlatformConfigurationDTO> InvitationStatuses();
        public List<PlatformConfigurationDTO> CreditCardTypes();
        public List<PlatformConfigurationDTO> PaymentStatuses();
        public List<PlatformConfigurationDTO> InstitutionTypes();

        #endregion

        #region DoctorSpecialties

        public DoctorSpecialtiesDTO CreateDoctorS(DoctorSpecialtiesCreateDTO specialties);
        public DoctorSpecialtiesDTO UpdateDoctorS(DoctorSpecialtiesDTO specialties);
        public DoctorSpecialtiesDTO SingleDoctorS(string Id);
        public DoctorSpecialtiesDTO DeleteDoctorS(string Id);
        public List<DoctorSpecialtiesDTO> ListDoctorS(PaginationFilter filter);

        #endregion

        #region InstitutionSpecialties

        public InstitutionSpecialtiesDTO CreateS(InstitutionSpecialtiesCreateDTO institution);
        public InstitutionSpecialtiesDTO UpdateS(InstitutionSpecialtiesDTO institution);
        public InstitutionSpecialtiesDTO SingleS(string institutionBranchId);
        public InstitutionSpecialtiesDTO DeleteS(string institutionBranchId);
        public List<InstitutionSpecialtiesDTO> ListS(PaginationFilter filter);
        public List<InstitutionSpecialtiesDTO> AddMultipleSpecialties(string institutionBranchId, List<string> specialtiesId);
        public List<InstitutionSpecialtiesDTO> RemoveMultipleSpecialties(string institutionBranchId, List<string> specialtiesId);

        #endregion

        #region InstitutionSubSpecialties

        public InstitutionSubSpecialtiesDTO CreateSubSpecialty(InstitutionSubSpecialtiesCreateDTO institution);
        public InstitutionSubSpecialtiesDTO UpdateSubSpecialty(InstitutionSubSpecialtiesDTO institution);
        public InstitutionSubSpecialtiesDTO SingleSubSpecialty(string institutionBranchId);
        public InstitutionSubSpecialtiesDTO DeleteSubSpecialty(string institutionBranchId);
        public List<InstitutionSubSpecialtiesDTO> ListSubSpecialties(PaginationFilter filter);
        public List<InstitutionSubSpecialtiesDTO> AddMultipleSubSpecialties(string institutionBranchId, List<string> subSpecialtiesId);
        public List<InstitutionSubSpecialtiesDTO> RemoveMultipleSubSpecialties(string institutionBranchId, List<string> subSpecialtiesId);

        #endregion

        #region InstitutionServices

        public InstitutionServicesDTO CreateService(InstitutionServicesCreateDTO institution);
        public InstitutionServicesDTO UpdateService(InstitutionServicesDTO institution);
        public InstitutionServicesDTO SingleService(string institutionBranchId);
        public InstitutionServicesDTO DeleteService(string institutionBranchId);
        public List<InstitutionServicesDTO> ListServices(PaginationFilter filter);
        public List<InstitutionServicesDTO> AddMultipleServices(string institutionBranchId, List<InstitutionServicesMultipleCreateDTO> services);
        public List<InstitutionServicesDTO> RemoveMultipleServices(string institutionBranchId, List<InstitutionServicesMultipleCreateDTO> services);

        #endregion

    }
}
