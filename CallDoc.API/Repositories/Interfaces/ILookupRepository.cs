using CallDoc.API.Models;
using CallDoc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace CallDoc.API.Repositories
{
    public interface ILookupRepository
    {

        #region Platform Configuration
        public List<PlatformConfiguration> AppointmentStatuses();
        public List<PlatformConfiguration> InstitutionStatuses();
        public List<PlatformConfiguration> MemberTypes();
        public List<PlatformConfiguration> MemberStatuses();
        public List<PlatformConfiguration> InvitationStatuses();
        public List<PlatformConfiguration> CreditCardTypes();
        public List<PlatformConfiguration> PaymentStatuses();
        public List<PlatformConfiguration> InstitutionTypes();

        #endregion

        #region DoctorSubSpecialties

        public DoctorSubSpecialties CreateDoctorSpecialties(DoctorSubSpecialties specialties);
        public DoctorSubSpecialties UpdateDoctorSpecialties(DoctorSubSpecialties specialties);
        public DoctorSubSpecialties SingleDoctorSpecialties(int Id);
        public DoctorSubSpecialties DeleteDoctorSpecialties(int Id);
        public List<DoctorSubSpecialties> ListDoctorSpecialties(PaginationFilter filter);

        #endregion

        #region InstitutionSpecialties

        public InstitutionSpecialties CreateSp(InstitutionSpecialties institution);
        public InstitutionSpecialties UpdateSp(InstitutionSpecialties institution);
        public InstitutionSpecialties SingleSp(int institutionBranchId);
        public InstitutionSpecialties DeleteSp(int institutionBranchId);
        public List<InstitutionSpecialties> ListSp(PaginationFilter filter);
        public List<InstitutionSpecialties> AddMultipleSpecialties(int institutionBranchId, List<int> specialtiesIds);
        public List<InstitutionSpecialties> RemoveMultipleSpecialties(int institutionBranchId, List<int> specialtiesIds);

        #endregion

        #region InstitutionSubSpecialties

        public InstitutionSubSpecialties CreateSubSp(InstitutionSubSpecialties institution);
        public InstitutionSubSpecialties UpdateSubSp(InstitutionSubSpecialties institution);
        public InstitutionSubSpecialties SingleSubSp(int institutionBranchId);
        public InstitutionSubSpecialties DeleteSubSp(int institutionBranchId);
        public List<InstitutionSubSpecialties> ListSubSp(PaginationFilter filter);
        public List<InstitutionSubSpecialties> AddMultipleSubSpecialties(int institutionBranchId, List<int> subSpecialtiesIds);
        public List<InstitutionSubSpecialties> RemoveMultipleSubSpecialties(int institutionBranchId, List<int> subSpecialtiesIds);

        #endregion

        #region InstitutionServices

        public InstitutionServices CreateService(InstitutionServices institution);
        public InstitutionServices UpdateService(InstitutionServices institution);
        public InstitutionServices SingleService(int institutionBranchId);
        public InstitutionServices DeleteService(int institutionBranchId);
        public List<InstitutionServices> ListService(PaginationFilter filter);
        public List<InstitutionServices> AddMultipleServices(int institutionBranchId, List<InstitutionServices> services);
        public List<InstitutionServices> RemoveMultipleServices(int institutionBranchId, List<InstitutionServices> services);

        #endregion
    }
}
