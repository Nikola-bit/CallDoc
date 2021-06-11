using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class Member
    {
        public Member()
        {
            AppointmentCancellationBy = new HashSet<Appointment>();
            AppointmentDoctor = new HashSet<Appointment>();
            AppointmentPatient = new HashSet<Appointment>();
            CreditCard = new HashSet<CreditCard>();
            DoctorSubSpecialties = new HashSet<DoctorSubSpecialties>();
            InstitutionDoctors = new HashSet<InstitutionDoctors>();
            MemberInvitation = new HashSet<MemberInvitation>();
            Service = new HashSet<Service>();
        }

        public int MemberId { get; set; }
        public string MemberEmail { get; set; }
        public string MemberPassword { get; set; }
        public int MemberTypeId { get; set; }
        public int MemberStatusId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual PlatformConfiguration MemberStatus { get; set; }
        public virtual PlatformConfiguration MemberType { get; set; }
        public virtual MemberDetails MemberDetails { get; set; }
        public virtual ICollection<Appointment> AppointmentCancellationBy { get; set; }
        public virtual ICollection<Appointment> AppointmentDoctor { get; set; }
        public virtual ICollection<Appointment> AppointmentPatient { get; set; }
        public virtual ICollection<CreditCard> CreditCard { get; set; }
        public virtual ICollection<DoctorSubSpecialties> DoctorSubSpecialties { get; set; }
        public virtual ICollection<InstitutionDoctors> InstitutionDoctors { get; set; }
        public virtual ICollection<MemberInvitation> MemberInvitation { get; set; }
        public virtual ICollection<Service> Service { get; set; }
    }
}
