using CallDoc.API.Models;
using CallDoc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Repositories
{
    public interface IDoctorRepository
    {

        #region Service

        public Service CreateService(Service service);
        public Service UpdateService(Service service);
        public Service SingleService(int serviceId);
        public Service DeleteService(int serviceId);
        public List<Service> ListServices(PaginationFilter filter);
        //List doctor services by doctorId --  
        public List<Service> byDoctorId(int Id);

        #endregion

    }
}
