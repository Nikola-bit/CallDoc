using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class MemberDetails
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string About { get; set; }
        public long? Embg { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Address Address { get; set; }
        public virtual Member Member { get; set; }
    }
}
