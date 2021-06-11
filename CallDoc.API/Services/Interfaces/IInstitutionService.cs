using CallDoc.DTO;
using CallDoc.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Services
{
    public interface IInstitutionService
    {

        #region Institution

        public InstitutionDTO CreateInstitution(InstitutionUpdateDTO institution);
        public InstitutionDTO UpdateInstitution(InstitutionUpdateDTO institution);
        public InstitutionDTO SingleInstitution(string institutionId);
        public InstitutionDTO DeleteInstitution(string institutionId);
        public List<InstitutionDTO> ListInstitutions(PaginationFilter filter);
        public List<InstitutionDTO> ListByTypeid(string id);
        public List<InstitutionDTO> ListByStatusid(string id);

        #endregion

        #region PlatformSpecialty

        public PlatformSpecialtyDTO CreatePlatformSpecialty(PlatformSpecialtyUpdateDTO specialty);
        public PlatformSpecialtyDTO UpdatePlatformSpecialty(PlatformSpecialtyUpdateDTO specialty);
        public PlatformSpecialtyDTO SinglePlatformSpecialty(string specialtyId);
        public PlatformSpecialtyDTO DeletePlatformSpecialty(string specialtyId);
        public List<PlatformSpecialtyDTO> ListSpecialties(PaginationFilter filter);

        #endregion

        #region PlatformSubSpecialty

        public PlatformSubSpecialtyDTO CreatePlatformSubSpecialty(PlatformSubSpecialtyUpdateDTO subSpecialty);
        public PlatformSubSpecialtyDTO UpdatePlatformSubSpecialty(PlatformSubSpecialtyUpdateDTO subSpecialty);
        public PlatformSubSpecialtyDTO SinglePlatformSubSpecialty(string subSpecialtyId);
        public PlatformSubSpecialtyDTO DeletePlatformSubSpecialty(string subSpecialtyId);
        public List<PlatformSubSpecialtyDTO> ListSubSpecialties(PaginationFilter filter);
        public List<PlatformSubSpecialtyDTO> ListSubSpecialtiesUnderSpecialty(UnderSpecialtyPaginationFilter filter);

        #endregion

        #region PlatformService

        public PlatformServiceDTO CreatePlatformService(PlatformServiceUpdateDTO service);
        public PlatformServiceDTO UpdatePlatformService(PlatformServiceUpdateDTO service);
        public PlatformServiceDTO SinglePlatformService(string service);
        public PlatformServiceDTO DeletePlatformService(string service);
        public List<PlatformServiceDTO> ListServices(PaginationFilter filter);
        public List<PlatformServiceDTO> ListServicesUnderSpecialtySubSpecialty(UnderSpecialtySubSpecialtyPaginationFilter filter);

        #endregion

        #region InstitutionBranch

        public InstitutionBranchDTO Create(InstitutionBranchDTO institution);
        public InstitutionBranchDTO UpdateBranch(InstitutionBranchDTO institution);
        public InstitutionBranchDTO SingleBranch(string institutionBranchId);
        public InstitutionBranchDTO DeleteBranch(string institutionBranchId);
        public List<InstitutionBranchDTO> ListBranch(PaginationFilter filter);
        public List<InstitutionBranchDTO> ListbranchByInstid(string Id);
        public InstitutionBranchDTO SingleBranchByAddrid(string Id);
        #endregion

    }
}
