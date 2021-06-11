using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class Specialty
    {
        public Specialty()
        {
            InstitutionSpecialties = new HashSet<InstitutionSpecialties>();
            SubSpecialty = new HashSet<SubSpecialty>();
        }

        public int SpecialtyId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<InstitutionSpecialties> InstitutionSpecialties { get; set; }
        public virtual ICollection<SubSpecialty> SubSpecialty { get; set; }
    }
}
