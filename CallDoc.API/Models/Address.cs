using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class Address
    {
        public Address()
        {
            InstitutionBranch = new HashSet<InstitutionBranch>();
            MemberDetails = new HashSet<MemberDetails>();
        }

        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<InstitutionBranch> InstitutionBranch { get; set; }
        public virtual ICollection<MemberDetails> MemberDetails { get; set; }
    }
}
