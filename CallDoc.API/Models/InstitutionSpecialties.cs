using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class InstitutionSpecialties
    {
        public int InstitutionSpecialtiesId { get; set; }
        public int InstitutionBranchId { get; set; }
        public int SpecialtyId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual InstitutionBranch InstitutionBranch { get; set; }
        public virtual PlatformSpecialty Specialty { get; set; }
    }
}
