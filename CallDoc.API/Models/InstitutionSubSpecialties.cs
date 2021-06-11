using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class InstitutionSubSpecialties
    {
        public int InstintutionSubSpecialtyId { get; set; }
        public int InstitutionBranchId { get; set; }
        public int PlatformSubSpecialtyId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual InstitutionBranch InstitutionBranch { get; set; }
        public virtual PlatformSubSpecialty PlatformSubSpecialty { get; set; }
    }
}
