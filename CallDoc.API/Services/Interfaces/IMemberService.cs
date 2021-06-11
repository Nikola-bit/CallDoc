using CallDoc.DTO;
using CallDoc.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Services
{
    public interface IMemberService
    {

        #region Member

        public MemberTokenDTO LoginMember(MemberLoginDTO member);
        public MemberDTO CreateMember(MemberUpdateDTO member);
        public MemberDTO UpdateMember(MemberUpdateDTO member);
        public MemberDTO SingleMember(string memberId);
        public MemberDTO DeleteMember(string memberId);
        public List<MemberDTO> ListMembers(PaginationFilter filter);
        public List<MemberDTO> MembersByStatus(string statusId);
        public List<MemberDTO> MembersByType(string typeId);

        #endregion

        #region Member Details

        public MemberDetailsDTO CreateUpdateMemberDetails(MemberDetailsCreateDTO memberDetails);
        public MemberDetailsDTO SingleMemberDetails(string memberDetailsId);
        public MemberDetailsDTO DeleteMemberDetails(string memberDetailsId);
        public List<MemberDetailsDTO> ListMembersDetails(PaginationFilter filter);

        #endregion

        #region MemberInvitation

        public MemberInvitationDTO CreateMemberInvitation(MemberInvitationUpdateDTO memberInvitation);
        public MemberInvitationDTO UpdateMemberInvitation(MemberInvitationUpdateDTO memberInvitation);
        public MemberInvitationDTO SingleMemberInvitation(string memberInvitationId);
        public MemberInvitationDTO DeleteMemberInvitation(string memberInvitationId);
        public List<MemberInvitationDTO> ListMemberInvitations(PaginationFilter filter);
        public List<MemberInvitationDTO> MemberInvitationsByStatus(string statusId);
        public List<MemberInvitationDTO> MemberInvitationsByMember(string memberId);

        #endregion

        #region PatientHistory

        public PatientHistoryDTO CreateHistory(PatientHistoryCreateDTO history);
        public PatientHistoryDTO UpdateHistory(PatientHistoryDTO history);
        public PatientHistoryDTO SingleHistory(string Id);
        public PatientHistoryDTO DeleteHistory(string Id);
        public List<PatientHistoryDTO> ListHistory(PaginationFilter filter);
        public List<PatientHistoryDTO> HistoryByPatient(string patientId);

        #endregion


    }
}
