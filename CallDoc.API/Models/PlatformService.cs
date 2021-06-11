using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class PlatformService
    {
        public PlatformService()
        {
            InstitutionServices = new HashSet<InstitutionServices>();
        }

        public int PlatformServiceId { get; set; }
        public int SpecialtyId { get; set; }
        public int? SubSpecialtyId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual PlatformSpecialty Specialty { get; set; }
        public virtual PlatformSubSpecialty SubSpecialty { get; set; }
        public virtual ICollection<InstitutionServices> InstitutionServices { get; set; }
    }
}
