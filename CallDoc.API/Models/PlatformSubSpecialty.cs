using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class PlatformSubSpecialty
    {
        public PlatformSubSpecialty()
        {
            DoctorSubSpecialties = new HashSet<DoctorSubSpecialties>();
            InstitutionSubSpecialties = new HashSet<InstitutionSubSpecialties>();
            PlatformService = new HashSet<PlatformService>();
        }

        public int SubSpecialtyId { get; set; }
        public int SpecialtyId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual PlatformSpecialty Specialty { get; set; }
        public virtual ICollection<DoctorSubSpecialties> DoctorSubSpecialties { get; set; }
        public virtual ICollection<InstitutionSubSpecialties> InstitutionSubSpecialties { get; set; }
        public virtual ICollection<PlatformService> PlatformService { get; set; }
    }
}
