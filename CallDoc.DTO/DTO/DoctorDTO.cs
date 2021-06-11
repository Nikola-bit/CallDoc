using System;
using System.Collections.Generic;
using System.Text;

namespace CallDoc.DTO
{

    #region Service

    public class ServiceCreateDTO
    {
        public string DoctorId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
    }
    public class ServiceUpdateDTO : ServiceCreateDTO
    {
        public string ServiceId { get; set; }
        public bool IsActive { get; set; }
    }
    public class ServiceDTO : ServiceUpdateDTO
    {
        public DateTime DateCreated { get; set; }
        public string DoctorName { get; set; }
    }
    #endregion

}
