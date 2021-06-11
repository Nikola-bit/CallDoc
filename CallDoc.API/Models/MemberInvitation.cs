using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class MemberInvitation
    {
        public int MemberInvitationId { get; set; }
        public string InvitationCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int StatusId { get; set; }
        public int MemberId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Member Member { get; set; }
        public virtual PlatformConfiguration Status { get; set; }
    }
}
