using AutoMapper;
using CallDoc.API.Models;
using CallDoc.API.Repositories;
using CallDoc.API.Utilities;
using CallDoc.DTO;
using CallDoc.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Services
{
    public class InstitutionService : IInstitutionService
    {

        #region Dependency Injection

        private IInstitutionRepository repository { get; set; }
        private IMapper mapper { get; set; }
        public InstitutionService(IInstitutionRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        #endregion

        #region Institution

        public InstitutionDTO CreateInstitution(InstitutionUpdateDTO institution)
        {
            InstitutionCreateDTO helper = mapper.Map<InstitutionCreateDTO>(institution);

            Institution request = mapper.Map<Institution>(helper);

            Institution result = repository.CreateInstitution(request);

            InstitutionDTO response = mapper.Map<InstitutionDTO>(result);

            return response;
        }
        public InstitutionDTO UpdateInstitution(InstitutionUpdateDTO institution)
        {
            Institution request = mapper.Map<Institution>(institution);

            Institution result = repository.UpdateInstitution(request);

            InstitutionDTO response = mapper.Map<InstitutionDTO>(result);

            return response;
        }
        public InstitutionDTO SingleInstitution(string institutionId)
        {
            Institution result = repository.SingleInstitution(Convert.ToInt32(DataEncryption.Decrypt(institutionId)));

            InstitutionDTO response = mapper.Map<InstitutionDTO>(result);

            return response;
        }
        public InstitutionDTO DeleteInstitution(string institutionId)
        {
            Institution result = repository.DeleteInstitution(Convert.ToInt32(DataEncryption.Decrypt(institutionId)));

            InstitutionDTO response = mapper.Map<InstitutionDTO>(result);

            return response;
        }
        public List<InstitutionDTO> ListInstitutions(PaginationFilter filter)
        {
            List<Institution> result = repository.ListInstitutions(filter);

            List<InstitutionDTO> response = mapper.Map<List<InstitutionDTO>>(result);

            return response;
        }
        public List<InstitutionDTO> ListByTypeid(string Id)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(Id));

            List<Institution> result = repository.ListByTypeId(request);

            List<InstitutionDTO> response = mapper.Map<List<InstitutionDTO>>(result);

            return response;
        }
        public List<InstitutionDTO> ListByStatusid(string Id)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(Id));

            List<Institution> result = repository.ListByStatusId(request);

            List<InstitutionDTO> response = mapper.Map<List<InstitutionDTO>>(result);

            return response;
        }

        #endregion

        #region PlatformSpecialty

        public PlatformSpecialtyDTO CreatePlatformSpecialty(PlatformSpecialtyUpdateDTO specialty)
        {
            PlatformSpecialtyCreateDTO helper = mapper.Map<PlatformSpecialtyCreateDTO>(specialty);

            PlatformSpecialty request = mapper.Map<PlatformSpecialty>(helper);

            PlatformSpecialty result = repository.CreatePlatformSpecialty(request);

            PlatformSpecialtyDTO response = mapper.Map<PlatformSpecialtyDTO>(result);

            return response;
        }
        public PlatformSpecialtyDTO UpdatePlatformSpecialty(PlatformSpecialtyUpdateDTO specialty)
        {
            PlatformSpecialty request = mapper.Map<PlatformSpecialty>(specialty);

            PlatformSpecialty result = repository.UpdatePlatformSpecialty(request);

            PlatformSpecialtyDTO response = mapper.Map<PlatformSpecialtyDTO>(result);

            return response;
        }
        public PlatformSpecialtyDTO SinglePlatformSpecialty(string specialtyId)
        {
            PlatformSpecialty result = repository.SinglePlatformSpecialty(Convert.ToInt32(DataEncryption.Decrypt(specialtyId)));

            PlatformSpecialtyDTO response = mapper.Map<PlatformSpecialtyDTO>(result);

            return response;
        }
        public PlatformSpecialtyDTO DeletePlatformSpecialty(string specialtyId)
        {
            PlatformSpecialty result = repository.DeletePlatformSpecialty(Convert.ToInt32(DataEncryption.Decrypt(specialtyId)));

            PlatformSpecialtyDTO response = mapper.Map<PlatformSpecialtyDTO>(result);

            return response;
        }
        public List<PlatformSpecialtyDTO> ListSpecialties(PaginationFilter filter)
        {
            List<PlatformSpecialty> result = repository.ListSpecialties(filter);

            List<PlatformSpecialtyDTO> response = mapper.Map<List<PlatformSpecialtyDTO>>(result);

            return response;
        }
        #endregion

        #region PlatformSubSpecialty

        public PlatformSubSpecialtyDTO CreatePlatformSubSpecialty(PlatformSubSpecialtyUpdateDTO subSpecialty)
        {
            PlatformSubSpecialtyCreateDTO helper = mapper.Map<PlatformSubSpecialtyCreateDTO>(subSpecialty);

            PlatformSubSpecialty request = mapper.Map<PlatformSubSpecialty>(helper);

            PlatformSubSpecialty result = repository.CreatePlatformSubSpecialty(request);

            PlatformSubSpecialtyDTO response = mapper.Map<PlatformSubSpecialtyDTO>(result);

            return response;
        }
        public PlatformSubSpecialtyDTO UpdatePlatformSubSpecialty(PlatformSubSpecialtyUpdateDTO subSpecialty)
        {
            PlatformSubSpecialty request = mapper.Map<PlatformSubSpecialty>(subSpecialty);

            PlatformSubSpecialty result = repository.UpdatePlatformSubSpecialty(request);

            PlatformSubSpecialtyDTO response = mapper.Map<PlatformSubSpecialtyDTO>(result);

            return response;
        }
        public PlatformSubSpecialtyDTO SinglePlatformSubSpecialty(string subSpecialtyId)
        {
            PlatformSubSpecialty result = repository.SinglePlatformSubSpecialty(Convert.ToInt32(DataEncryption.Decrypt(subSpecialtyId)));

            PlatformSubSpecialtyDTO response = mapper.Map<PlatformSubSpecialtyDTO>(result);

            return response;
        }
        public PlatformSubSpecialtyDTO DeletePlatformSubSpecialty(string subSpecialtyId)
        {
            PlatformSubSpecialty result = repository.DeletePlatformSubSpecialty(Convert.ToInt32(DataEncryption.Decrypt(subSpecialtyId)));

            PlatformSubSpecialtyDTO response = mapper.Map<PlatformSubSpecialtyDTO>(result);

            return response;
        }
        public List<PlatformSubSpecialtyDTO> ListSubSpecialties(PaginationFilter filter)
        {
            List<PlatformSubSpecialty> result = repository.ListSubSpecialties(filter);

            List<PlatformSubSpecialtyDTO> response = mapper.Map<List<PlatformSubSpecialtyDTO>>(result);

            return response;
        }
        public List<PlatformSubSpecialtyDTO> ListSubSpecialtiesUnderSpecialty(UnderSpecialtyPaginationFilter filter)
        {
            filter.SpecialtyId = DataEncryption.Decrypt(filter.SpecialtyId);

            List<PlatformSubSpecialty> result = repository.ListSubSpecialtiesUnderSpecialty(filter);

            List<PlatformSubSpecialtyDTO> response = mapper.Map<List<PlatformSubSpecialtyDTO>>(result);

            return response;
        }

        #endregion

        #region PlatformService

        public PlatformServiceDTO CreatePlatformService(PlatformServiceUpdateDTO service)
        {
            PlatformServiceCreateDTO helper = mapper.Map<PlatformServiceCreateDTO>(service);

            PlatformService request = mapper.Map<PlatformService>(helper);

            PlatformService result = repository.CreatePlatformService(request);

            PlatformServiceDTO response = mapper.Map<PlatformServiceDTO>(result);

            return response;
        }
        public PlatformServiceDTO UpdatePlatformService(PlatformServiceUpdateDTO service)
        {
            PlatformService request = mapper.Map<PlatformService>(service);

            PlatformService result = repository.UpdatePlatformService(request);

            PlatformServiceDTO response = mapper.Map<PlatformServiceDTO>(result);

            return response;
        }
        public PlatformServiceDTO SinglePlatformService(string serviceId)
        {
            PlatformService result = repository.SinglePlatformService(Convert.ToInt32(DataEncryption.Decrypt(serviceId)));

            PlatformServiceDTO response = mapper.Map<PlatformServiceDTO>(result);

            return response;
        }
        public PlatformServiceDTO DeletePlatformService(string serviceId)
        {
            PlatformService result = repository.DeletePlatformService(Convert.ToInt32(DataEncryption.Decrypt(serviceId)));

            PlatformServiceDTO response = mapper.Map<PlatformServiceDTO>(result);

            return response;
        }
        public List<PlatformServiceDTO> ListServices(PaginationFilter filter)
        {
            List<PlatformService> result = repository.ListServices(filter);

            List<PlatformServiceDTO> response = mapper.Map<List<PlatformServiceDTO>>(result);

            return response;
        }
        public List<PlatformServiceDTO> ListServicesUnderSpecialtySubSpecialty(UnderSpecialtySubSpecialtyPaginationFilter filter)
        {
            if (filter.SpecialtyId != "string")
                filter.SpecialtyId = DataEncryption.Decrypt(filter.SpecialtyId);
            if (filter.SubSpecialtyId != "string")
                filter.SubSpecialtyId = DataEncryption.Decrypt(filter.SubSpecialtyId);


            List<PlatformService> result = repository.ListServicesUnderSpecialtySubSpecialty(filter);

            List<PlatformServiceDTO> response = mapper.Map<List<PlatformServiceDTO>>(result);

            return response;
        }

        #endregion

        #region InstitutionBranch

        public InstitutionBranchDTO Create(InstitutionBranchDTO institution)
        {
            InstitutionBranchCreateDTO helper = mapper.Map<InstitutionBranchCreateDTO>(institution);

            InstitutionBranch request = mapper.Map<InstitutionBranch>(helper);

            InstitutionBranch result = repository.Create(request);

            InstitutionBranchDTO response = mapper.Map<InstitutionBranchDTO>(result);

            return response;
        }
        public InstitutionBranchDTO UpdateBranch(InstitutionBranchDTO institution)
        {
            InstitutionBranch request = mapper.Map<InstitutionBranch>(institution);

            InstitutionBranch result = repository.UpdateBranch(request);

            InstitutionBranchDTO response = mapper.Map<InstitutionBranchDTO>(result);

            return response;
        }
        public InstitutionBranchDTO SingleBranch(string institutionBranchId)
        {
            InstitutionBranch result = repository.SingleBranch(Convert.ToInt32(DataEncryption.Decrypt(institutionBranchId)));

            InstitutionBranchDTO response = mapper.Map<InstitutionBranchDTO>(result);

            return response;
        }
        public InstitutionBranchDTO DeleteBranch(string branchId)
        {
            InstitutionBranch result = repository.DeleteBranch(Convert.ToInt32(DataEncryption.Decrypt(branchId)));

            InstitutionBranchDTO response = mapper.Map<InstitutionBranchDTO>(result);

            return response;
        }
        public List<InstitutionBranchDTO> ListBranch(PaginationFilter filter)
        {
            List<InstitutionBranch> result = repository.ListBranch(filter);

            List<InstitutionBranchDTO> response = mapper.Map<List<InstitutionBranchDTO>>(result);

            return response;
        }
        public List<InstitutionBranchDTO> ListbranchByInstid(string Id)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(Id));

            List<InstitutionBranch> result = repository.ListbranchByInstId(request);

            List<InstitutionBranchDTO> response = mapper.Map<List<InstitutionBranchDTO>>(result);

            return response;
        }
        public InstitutionBranchDTO SingleBranchByAddrid(string addressId)
        {
            InstitutionBranch result = repository.SingleBranchByAddrId(Convert.ToInt32(DataEncryption.Decrypt(addressId)));

            InstitutionBranchDTO response = mapper.Map<InstitutionBranchDTO>(result);

            return response;
        }
        #endregion

    }
}
