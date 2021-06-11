using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class PlatformConfiguration
    {
        public PlatformConfiguration()
        {
            Appointment = new HashSet<Appointment>();
            CreditCard = new HashSet<CreditCard>();
            InstitutionStatus = new HashSet<Institution>();
            InstitutionType = new HashSet<Institution>();
            MemberInvitation = new HashSet<MemberInvitation>();
            MemberMemberStatus = new HashSet<Member>();
            MemberMemberType = new HashSet<Member>();
            Payment = new HashSet<Payment>();
        }

        public int Value { get; set; }
        public string ProgramCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<CreditCard> CreditCard { get; set; }
        public virtual ICollection<Institution> InstitutionStatus { get; set; }
        public virtual ICollection<Institution> InstitutionType { get; set; }
        public virtual ICollection<MemberInvitation> MemberInvitation { get; set; }
        public virtual ICollection<Member> MemberMemberStatus { get; set; }
        public virtual ICollection<Member> MemberMemberType { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
