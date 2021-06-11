using AutoMapper;
using CallDoc.API.Models;
using CallDoc.API.Repositories;
using CallDoc.API.Utilities;
using CallDoc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Services
{
    public class LookupService : ILookupService
    {

        #region Dependency Injection
       
        private readonly ILookupRepository _lookupRepository;
        private readonly IMapper _mapper;
        public LookupService(ILookupRepository lookupRepository, IMapper mapper)
        {
            _lookupRepository = lookupRepository;
            _mapper = mapper;
        }

        #endregion

        #region PlatformConfiguration

        public List<PlatformConfigurationDTO> AppointmentStatuses()
        {
            List<PlatformConfiguration> platformConfigurations = _lookupRepository.AppointmentStatuses();

            List<PlatformConfigurationDTO> response = _mapper.Map<List<PlatformConfigurationDTO>>(platformConfigurations);

            return response;
        }

        public List<PlatformConfigurationDTO> InstitutionStatuses()
        {
            List<PlatformConfiguration> platformConfigurations = _lookupRepository.InstitutionStatuses();

            List<PlatformConfigurationDTO> response = _mapper.Map<List<PlatformConfigurationDTO>>(platformConfigurations);

            return response;
        }

        public List<PlatformConfigurationDTO> MemberTypes()
        {
            List<PlatformConfiguration> platformConfigurations = _lookupRepository.MemberTypes();

            List<PlatformConfigurationDTO> response = _mapper.Map<List<PlatformConfigurationDTO>>(platformConfigurations);

            return response;
        }
        public List<PlatformConfigurationDTO> MemberStatuses()
        {
            List<PlatformConfiguration> platformConfigurations = _lookupRepository.MemberStatuses();

            List<PlatformConfigurationDTO> response = _mapper.Map<List<PlatformConfigurationDTO>>(platformConfigurations);

            return response;
        }
        public List<PlatformConfigurationDTO> InvitationStatuses()
        {
            List<PlatformConfiguration> platformConfigurations = _lookupRepository.InvitationStatuses();

            List<PlatformConfigurationDTO> response = _mapper.Map<List<PlatformConfigurationDTO>>(platformConfigurations);

            return response;
        }
        public List<PlatformConfigurationDTO> CreditCardTypes()
        {
            List<PlatformConfiguration> platformConfigurations = _lookupRepository.CreditCardTypes();

            List<PlatformConfigurationDTO> response = _mapper.Map<List<PlatformConfigurationDTO>>(platformConfigurations);

            return response;
        }
        public List<PlatformConfigurationDTO> PaymentStatuses()
        {
            List<PlatformConfiguration> platformConfigurations = _lookupRepository.PaymentStatuses();

            List<PlatformConfigurationDTO> response = _mapper.Map<List<PlatformConfigurationDTO>>(platformConfigurations);

            return response;
        }
        public List<PlatformConfigurationDTO> InstitutionTypes()
        {
            List<PlatformConfiguration> platformConfigurations = _lookupRepository.InstitutionTypes();

            List<PlatformConfigurationDTO> response = _mapper.Map<List<PlatformConfigurationDTO>>(platformConfigurations);

            return response;
        }

        #endregion

        #region DoctorSpecialties

        public DoctorSpecialtiesDTO CreateDoctorS(DoctorSpecialtiesCreateDTO specialties)
        {
            DoctorSpecialtiesCreateDTO helper = _mapper.Map<DoctorSpecialtiesCreateDTO>(specialties);

            DoctorSubSpecialties request = _mapper.Map<DoctorSubSpecialties>(helper);

            DoctorSubSpecialties result = _lookupRepository.CreateDoctorSpecialties(request);

            DoctorSpecialtiesDTO response = _mapper.Map<DoctorSpecialtiesDTO>(result);

            return response;
        }
        public DoctorSpecialtiesDTO UpdateDoctorS(DoctorSpecialtiesDTO specialties)
        {
            DoctorSubSpecialties request = _mapper.Map<DoctorSubSpecialties>(specialties);

            DoctorSubSpecialties result = _lookupRepository.UpdateDoctorSpecialties(request);

            DoctorSpecialtiesDTO response = _mapper.Map<DoctorSpecialtiesDTO>(result);

            return response;
        }
        public DoctorSpecialtiesDTO SingleDoctorS(string Id)
        {
            DoctorSubSpecialties result = _lookupRepository.SingleDoctorSpecialties(Convert.ToInt32(DataEncryption.Decrypt(Id)));

            DoctorSpecialtiesDTO response = _mapper.Map<DoctorSpecialtiesDTO>(result);

            return response;
        }
        public DoctorSpecialtiesDTO DeleteDoctorS(string Id)
        {
            DoctorSubSpecialties result = _lookupRepository.DeleteDoctorSpecialties(Convert.ToInt32(DataEncryption.Decrypt(Id)));

            DoctorSpecialtiesDTO response = _mapper.Map<DoctorSpecialtiesDTO>(result);

            return response;
        }
        public List<DoctorSpecialtiesDTO> ListDoctorS(PaginationFilter filter)
        {
            List<DoctorSubSpecialties> result = _lookupRepository.ListDoctorSpecialties(filter);

            List<DoctorSpecialtiesDTO> response = _mapper.Map<List<DoctorSpecialtiesDTO>>(result);

            return response;
        }

        #endregion

        #region InstitutionSpecialties

        public InstitutionSpecialtiesDTO CreateS(InstitutionSpecialtiesCreateDTO institution)
        {
            InstitutionSpecialtiesCreateDTO helper = _mapper.Map<InstitutionSpecialtiesCreateDTO>(institution);

            InstitutionSpecialties request = _mapper.Map<InstitutionSpecialties>(helper);

            InstitutionSpecialties result = _lookupRepository.CreateSp(request);

            InstitutionSpecialtiesDTO response = _mapper.Map<InstitutionSpecialtiesDTO>(result);

            return response;
        }
        public InstitutionSpecialtiesDTO UpdateS(InstitutionSpecialtiesDTO institution)
        {
            InstitutionSpecialties request = _mapper.Map<InstitutionSpecialties>(institution);

            InstitutionSpecialties result = _lookupRepository.UpdateSp(request);

            InstitutionSpecialtiesDTO response = _mapper.Map<InstitutionSpecialtiesDTO>(result);

            return response;
        }
        public InstitutionSpecialtiesDTO SingleS(string Id)
        {
            InstitutionSpecialties result = _lookupRepository.SingleSp(Convert.ToInt32(DataEncryption.Decrypt(Id)));

            InstitutionSpecialtiesDTO response = _mapper.Map<InstitutionSpecialtiesDTO>(result);

            return response;
        }
        public InstitutionSpecialtiesDTO DeleteS(string Id)
        {
            InstitutionSpecialties result = _lookupRepository.DeleteSp(Convert.ToInt32(DataEncryption.Decrypt(Id)));

            InstitutionSpecialtiesDTO response = _mapper.Map<InstitutionSpecialtiesDTO>(result);

            return response;
        }
        public List<InstitutionSpecialtiesDTO> ListS(PaginationFilter filter)
        {
            List<InstitutionSpecialties> result = _lookupRepository.ListSp(filter);

            List<InstitutionSpecialtiesDTO> response = _mapper.Map<List<InstitutionSpecialtiesDTO>>(result);

            return response;
        }
        public List<InstitutionSpecialtiesDTO> AddMultipleSpecialties(string institutionBranchId,List<string> specialtiesId)
        {
            List<int> requestSpecialties = new List<int>();

            foreach(string specialty in specialtiesId)
            {
                requestSpecialties.Add(Convert.ToInt32(DataEncryption.Decrypt(specialty)));
            }

            List<InstitutionSpecialties> result = _lookupRepository.AddMultipleSpecialties(Convert.ToInt32(DataEncryption.Decrypt(institutionBranchId)), requestSpecialties);

            List<InstitutionSpecialtiesDTO> response = _mapper.Map < List<InstitutionSpecialtiesDTO>>(result);

            return response;
        }
        public List<InstitutionSpecialtiesDTO> RemoveMultipleSpecialties(string institutionBranchId, List<string> specialtiesId)
        {
            List<int> requestSpecialties = new List<int>();

            foreach (string specialty in specialtiesId)
            {
                requestSpecialties.Add(Convert.ToInt32(DataEncryption.Decrypt(specialty)));
            }

            List<InstitutionSpecialties> result = _lookupRepository.RemoveMultipleSpecialties(Convert.ToInt32(DataEncryption.Decrypt(institutionBranchId)), requestSpecialties);

            List<InstitutionSpecialtiesDTO> response = _mapper.Map<List<InstitutionSpecialtiesDTO>>(result);

            return response;
        }

        #endregion

        #region InstitutionSubSpecialties

        public InstitutionSubSpecialtiesDTO CreateSubSpecialty(InstitutionSubSpecialtiesCreateDTO institution)
        {
            InstitutionSubSpecialtiesCreateDTO helper = _mapper.Map<InstitutionSubSpecialtiesCreateDTO>(institution);

            InstitutionSubSpecialties request = _mapper.Map<InstitutionSubSpecialties>(helper);

            InstitutionSubSpecialties result = _lookupRepository.CreateSubSp(request);

            InstitutionSubSpecialtiesDTO response = _mapper.Map<InstitutionSubSpecialtiesDTO>(result);

            return response;
        }
        public InstitutionSubSpecialtiesDTO UpdateSubSpecialty(InstitutionSubSpecialtiesDTO institution)
        {
            InstitutionSubSpecialties request = _mapper.Map<InstitutionSubSpecialties>(institution);

            InstitutionSubSpecialties result = _lookupRepository.UpdateSubSp(request);

            InstitutionSubSpecialtiesDTO response = _mapper.Map<InstitutionSubSpecialtiesDTO>(result);

            return response;
        }
        public InstitutionSubSpecialtiesDTO SingleSubSpecialty(string Id)
        {
            InstitutionSubSpecialties result = _lookupRepository.SingleSubSp(Convert.ToInt32(DataEncryption.Decrypt(Id)));

            InstitutionSubSpecialtiesDTO response = _mapper.Map<InstitutionSubSpecialtiesDTO>(result);

            return response;
        }
        public InstitutionSubSpecialtiesDTO DeleteSubSpecialty(string Id)
        {
            InstitutionSubSpecialties result = _lookupRepository.DeleteSubSp(Convert.ToInt32(DataEncryption.Decrypt(Id)));

            InstitutionSubSpecialtiesDTO response = _mapper.Map<InstitutionSubSpecialtiesDTO>(result);

            return response;
        }
        public List<InstitutionSubSpecialtiesDTO> ListSubSpecialties(PaginationFilter filter)
        {
            List<InstitutionSubSpecialties> result = _lookupRepository.ListSubSp(filter);

            List<InstitutionSubSpecialtiesDTO> response = _mapper.Map<List<InstitutionSubSpecialtiesDTO>>(result);

            return response;
        }
        public List<InstitutionSubSpecialtiesDTO> AddMultipleSubSpecialties(string institutionBranchId, List<string> specialtiesId)
        {
            List<int> requestSubSpecialties = new List<int>();

            foreach (string subSpecialty in specialtiesId)
            {
                requestSubSpecialties.Add(Convert.ToInt32(DataEncryption.Decrypt(subSpecialty)));
            }

            List<InstitutionSubSpecialties> result = _lookupRepository.AddMultipleSubSpecialties(Convert.ToInt32(DataEncryption.Decrypt(institutionBranchId)), requestSubSpecialties);

            List<InstitutionSubSpecialtiesDTO> response = _mapper.Map<List<InstitutionSubSpecialtiesDTO>>(result);

            return response;
        }
        public List<InstitutionSubSpecialtiesDTO> RemoveMultipleSubSpecialties(string institutionBranchId, List<string> specialtiesId)
        {
            List<int> requestSubSpecialties = new List<int>();

            foreach (string subSpecialty in specialtiesId)
            {
                requestSubSpecialties.Add(Convert.ToInt32(DataEncryption.Decrypt(subSpecialty)));
            }

            List<InstitutionSubSpecialties> result = _lookupRepository.RemoveMultipleSubSpecialties(Convert.ToInt32(DataEncryption.Decrypt(institutionBranchId)), requestSubSpecialties);

            List<InstitutionSubSpecialtiesDTO> response = _mapper.Map<List<InstitutionSubSpecialtiesDTO>>(result);

            return response;
        }

        #endregion

        #region InstitutionServices

        public InstitutionServicesDTO CreateService(InstitutionServicesCreateDTO institution)
        {
            InstitutionServicesCreateDTO helper = _mapper.Map<InstitutionServicesCreateDTO>(institution);

            InstitutionServices request = _mapper.Map<InstitutionServices>(helper);

            InstitutionServices result = _lookupRepository.CreateService(request);

            InstitutionServicesDTO response = _mapper.Map<InstitutionServicesDTO>(result);

            return response;
        }
        public InstitutionServicesDTO UpdateService(InstitutionServicesDTO institution)
        {
            InstitutionServices request = _mapper.Map<InstitutionServices>(institution);

            InstitutionServices result = _lookupRepository.UpdateService(request);

            InstitutionServicesDTO response = _mapper.Map<InstitutionServicesDTO>(result);

            return response;
        }
        public InstitutionServicesDTO SingleService(string Id)
        {
            InstitutionServices result = _lookupRepository.SingleService(Convert.ToInt32(DataEncryption.Decrypt(Id)));

            InstitutionServicesDTO response = _mapper.Map<InstitutionServicesDTO>(result);

            return response;
        }
        public InstitutionServicesDTO DeleteService(string Id)
        {
            InstitutionServices result = _lookupRepository.DeleteService(Convert.ToInt32(DataEncryption.Decrypt(Id)));

            InstitutionServicesDTO response = _mapper.Map<InstitutionServicesDTO>(result);

            return response;
        }
        public List<InstitutionServicesDTO> ListServices(PaginationFilter filter)
        {
            List<InstitutionServices> result = _lookupRepository.ListService(filter);

            List<InstitutionServicesDTO> response = _mapper.Map<List<InstitutionServicesDTO>>(result);

            return response;
        }
        public List<InstitutionServicesDTO> AddMultipleServices(string institutionBranchId, List<InstitutionServicesMultipleCreateDTO> services)
        {
            List<InstitutionServices> requestServices = new List<InstitutionServices>();

            foreach (InstitutionServicesMultipleCreateDTO service in services)
            {
                requestServices.Add(new InstitutionServices()
                {
                    InstitutionDoctorId = Convert.ToInt32(DataEncryption.Decrypt(service.InstitutionDoctorId)),
                    PlatformServiceId = Convert.ToInt32(DataEncryption.Decrypt(service.PlatformServiceId))
                });
            }

            List<InstitutionServices> result = _lookupRepository.AddMultipleServices(Convert.ToInt32(DataEncryption.Decrypt(institutionBranchId)), requestServices);

            List<InstitutionServicesDTO> response = _mapper.Map<List<InstitutionServicesDTO>>(result);

            return response;
        }
        public List<InstitutionServicesDTO> RemoveMultipleServices(string institutionBranchId, List<InstitutionServicesMultipleCreateDTO> services)
        {
            List<InstitutionServices> requestServices = new List<InstitutionServices>();

            foreach (InstitutionServicesMultipleCreateDTO service in services)
            {
                requestServices.Add(new InstitutionServices()
                {
                    InstitutionDoctorId = Convert.ToInt32(DataEncryption.Decrypt(service.InstitutionDoctorId)),
                    PlatformServiceId = Convert.ToInt32(DataEncryption.Decrypt(service.PlatformServiceId))
                });
            }

            List<InstitutionServices> result = _lookupRepository.RemoveMultipleServices(Convert.ToInt32(DataEncryption.Decrypt(institutionBranchId)), requestServices);

            List<InstitutionServicesDTO> response = _mapper.Map<List<InstitutionServicesDTO>>(result);

            return response;
        }

        #endregion

    }
}
