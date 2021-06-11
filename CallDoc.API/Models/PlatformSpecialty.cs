using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class PlatformSpecialty
    {
        public PlatformSpecialty()
        {
            InstitutionSpecialties = new HashSet<InstitutionSpecialties>();
            PlatformService = new HashSet<PlatformService>();
            PlatformSubSpecialty = new HashSet<PlatformSubSpecialty>();
        }

        public int SpecialtyId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<InstitutionSpecialties> InstitutionSpecialties { get; set; }
        public virtual ICollection<PlatformService> PlatformService { get; set; }
        public virtual ICollection<PlatformSubSpecialty> PlatformSubSpecialty { get; set; }
    }
}
