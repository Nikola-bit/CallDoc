using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class InstitutionBranch
    {
        public InstitutionBranch()
        {
            InstitutionDoctors = new HashSet<InstitutionDoctors>();
            InstitutionServices = new HashSet<InstitutionServices>();
            InstitutionSpecialties = new HashSet<InstitutionSpecialties>();
            InstitutionSubSpecialties = new HashSet<InstitutionSubSpecialties>();
        }

        public int InstitutionBranchId { get; set; }
        public int InstitutionId { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public string Biography { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Website { get; set; }
        public string Logo { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Address Address { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual ICollection<InstitutionDoctors> InstitutionDoctors { get; set; }
        public virtual ICollection<InstitutionServices> InstitutionServices { get; set; }
        public virtual ICollection<InstitutionSpecialties> InstitutionSpecialties { get; set; }
        public virtual ICollection<InstitutionSubSpecialties> InstitutionSubSpecialties { get; set; }
    }
}
