using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class InstitutionServices
    {
        public int InstitutionServiceId { get; set; }
        public int PlatformServiceId { get; set; }
        public int InstitutionBranchId { get; set; }
        public int InstitutionDoctorId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual InstitutionBranch InstitutionBranch { get; set; }
        public virtual InstitutionDoctors InstitutionDoctor { get; set; }
        public virtual PlatformService PlatformService { get; set; }
    }
}
