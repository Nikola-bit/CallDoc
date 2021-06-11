using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class DoctorSubSpecialties
    {
        public int DoctorSubSpecialties1 { get; set; }
        public int SubSpecialtyId { get; set; }
        public int DoctorId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Member Doctor { get; set; }
        public virtual PlatformSubSpecialty SubSpecialty { get; set; }
    }
}
