using AutoMapper;
using CallDoc.API.Repositories;
using CallDoc.API.Models;
using CallDoc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallDoc.API.Utilities;
using CallDoc.DTO.DTO;

namespace CallDoc.API.Services
{
    public class DoctorService : IDoctorService
    {

        #region DepencyInjection

        public IDoctorRepository repository { get; set; }
        public IMapper mapper { get; set; }
        public DoctorService(IDoctorRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        #endregion

        #region Service

        public ServiceDTO CreateService(ServiceUpdateDTO service)
        {
            ServiceCreateDTO helper = mapper.Map<ServiceCreateDTO>(service);

            Service request = mapper.Map<Service>(helper);

            Service result = repository.CreateService(request);

            ServiceDTO response = mapper.Map<ServiceDTO>(result);

            return response;
        }
        public ServiceDTO UpdateService(ServiceUpdateDTO service)
        {
            Service request = mapper.Map<Service>(service);

            Service result = repository.UpdateService(request);

            ServiceDTO response = mapper.Map<ServiceDTO>(result);

            return response;
        }
        public ServiceDTO SingleService(string serviceId)
        {
            Service result = repository.SingleService(Convert.ToInt32(DataEncryption.Decrypt(serviceId)));

            ServiceDTO response = mapper.Map<ServiceDTO>(result);

            return response;
        }
        public ServiceDTO DeleteService(string serviceId)
        {
            Service result = repository.DeleteService(Convert.ToInt32(DataEncryption.Decrypt(serviceId)));

            ServiceDTO response = mapper.Map<ServiceDTO>(result);

            return response;
        }
        public List<ServiceDTO> ListServices(PaginationFilter filter)
        {
            List<Service> result = repository.ListServices(filter);

            List<ServiceDTO> response = mapper.Map<List<ServiceDTO>>(result);

            return response;
        }
        public List<ServiceDTO> ListByDoctorId(string Id)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(Id));

            List<Service> result = repository.byDoctorId(request);

            List<ServiceDTO> response = mapper.Map<List<ServiceDTO>>(result);

            return response;
        }

        #endregion

    }
}
