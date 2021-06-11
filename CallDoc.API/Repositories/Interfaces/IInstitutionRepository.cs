using CallDoc.API.Models;
using CallDoc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Repositories
{
    public interface IInstitutionRepository
    {

        #region Institution

        public Institution CreateInstitution(Institution institution);
        public Institution UpdateInstitution(Institution institution);
        public Institution SingleInstitution(int institutionId);
        public Institution DeleteInstitution(int institutionId);
        public List<Institution> ListInstitutions(PaginationFilter filter);
        //List institution by typeId, statusId
        public List<Institution> ListByTypeId(int id);
        public List<Institution> ListByStatusId(int id);

        #endregion

        #region PlatformSpecialty

        public PlatformSpecialty CreatePlatformSpecialty(PlatformSpecialty specialty);
        public PlatformSpecialty UpdatePlatformSpecialty(PlatformSpecialty specialty);
        public PlatformSpecialty SinglePlatformSpecialty(int specialtyId);
        public PlatformSpecialty DeletePlatformSpecialty(int specialtyId);
        public List<PlatformSpecialty> ListSpecialties(PaginationFilter filter);
        #endregion

        #region PlatformSubSpecialty

        public PlatformSubSpecialty CreatePlatformSubSpecialty(PlatformSubSpecialty subSpecialty);
        public PlatformSubSpecialty UpdatePlatformSubSpecialty(PlatformSubSpecialty subSpecialty);
        public PlatformSubSpecialty SinglePlatformSubSpecialty(int subSpecialtyId);
        public PlatformSubSpecialty DeletePlatformSubSpecialty(int subSpecialtyId);
        public List<PlatformSubSpecialty> ListSubSpecialties(PaginationFilter filter);
        public List<PlatformSubSpecialty> ListSubSpecialtiesUnderSpecialty(UnderSpecialtyPaginationFilter filter);

        #endregion

        #region PlatformService

        public PlatformService CreatePlatformService(PlatformService service);
        public PlatformService UpdatePlatformService(PlatformService service);
        public PlatformService SinglePlatformService(int service);
        public PlatformService DeletePlatformService(int service);
        public List<PlatformService> ListServices(PaginationFilter filter);
        public List<PlatformService> ListServicesUnderSpecialtySubSpecialty(UnderSpecialtySubSpecialtyPaginationFilter filter);

        #endregion

        #region InstitutionBranch
        //InstitutionBranch
        public InstitutionBranch Create(InstitutionBranch institution);
        public InstitutionBranch UpdateBranch(InstitutionBranch institution);
        public InstitutionBranch SingleBranch(int institutionBranchId);
        public InstitutionBranch DeleteBranch(int institutionBranchId);
        public List<InstitutionBranch> ListBranch(PaginationFilter filter);
        //List institttion branch by institutionId
        //      Single institttion branch by addressId
        public List<InstitutionBranch> ListbranchByInstId(int Id);
        public InstitutionBranch SingleBranchByAddrId(int Id);
        #endregion

    }
}
