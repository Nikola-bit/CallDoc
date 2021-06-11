using System;
using System.Collections.Generic;
using System.Text;

namespace CallDoc.DTO.DTO
{

    #region Member

    public class MemberCreateDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string MemberTypeId { get; set; }
    }
    public class MemberUpdateDTO : MemberCreateDTO
    {
        public string MemberId { get; set; }
        public string MemberStatusId { get; set; }
    }
    public class MemberDTO : MemberUpdateDTO
    {
        public DateTime DateCreated { get; set; }
        public string MemberType { get; set; }
        public string MemberStatus { get; set; }
    }
    public class MemberLoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class MemberTokenDTO
    {
        public MemberDTO Member { get; set; }
        public string Token { get; set; }
    }

    #endregion

    #region Member Details

    public class MemberDetailsCreateDTO
    {
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string About { get; set; }
        public long Embg { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
    }
    public class MemberDetailsDTO : MemberDetailsCreateDTO
    {
        public string MemberType { get; set; }
        public DateTime DateCreated { get; set; }
        public string Address { get; set; }
    }

    #endregion

    #region Member Invitation

    public class MemberInvitationCreateDTO
    {
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string InvitationCode { get; set; }
    }
    public class MemberInvitationUpdateDTO : MemberInvitationCreateDTO
    {
        public string MemberInvitationId { get; set; }
        public string StatusId { get; set; }
    }
    public class MemberInvitationDTO : MemberInvitationUpdateDTO
    {
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
    }

    #endregion

}
