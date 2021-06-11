using CallDoc.DTO;
using CallDoc.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Services
{
    public interface IDoctorService
    {

        #region Service

        public ServiceDTO CreateService(ServiceUpdateDTO service);
        public ServiceDTO UpdateService(ServiceUpdateDTO service);
        public ServiceDTO SingleService(string serviceId);
        public ServiceDTO DeleteService(string serviceId);
        public List<ServiceDTO> ListServices(PaginationFilter filter);
        public List<ServiceDTO> ListByDoctorId(string Id);

        #endregion

    }
}
