using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class SubSpecialty
    {
        public SubSpecialty()
        {
            DoctorSubSpecialties = new HashSet<DoctorSubSpecialties>();
        }

        public int SubSpecialtyId { get; set; }
        public int SpecialtyId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Specialty Specialty { get; set; }
        public virtual ICollection<DoctorSubSpecialties> DoctorSubSpecialties { get; set; }
    }
}
