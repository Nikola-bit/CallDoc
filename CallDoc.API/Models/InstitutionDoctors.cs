using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class InstitutionDoctors
    {
        public InstitutionDoctors()
        {
            InstitutionServices = new HashSet<InstitutionServices>();
        }

        public int InstitutionDoctorId { get; set; }
        public int InstitutionBranchId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Member Doctor { get; set; }
        public virtual InstitutionBranch InstitutionBranch { get; set; }
        public virtual ICollection<InstitutionServices> InstitutionServices { get; set; }
    }
}
