using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class Institution
    {
        public Institution()
        {
            InstitutionBranch = new HashSet<InstitutionBranch>();
        }

        public int InstitutionId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual PlatformConfiguration Status { get; set; }
        public virtual PlatformConfiguration Type { get; set; }
        public virtual ICollection<InstitutionBranch> InstitutionBranch { get; set; }
    }
}
