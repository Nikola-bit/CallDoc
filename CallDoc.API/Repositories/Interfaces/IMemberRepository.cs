using AutoMapper.QueryableExtensions.Impl;
using CallDoc.API.Models;
using CallDoc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Repositories
{
    public interface IMemberRepository
    {

        #region Member

        public Member LoginMember(Member member);
        public Member CreateMember(Member member);
        public Member UpdateMember(Member member);
        public Member SingleMember(int memberId);
        public Member DeleteMember(int memberId);
        public List<Member> ListMembers(PaginationFilter filter);
        public List<Member> MembersByStatus(int statusId);
        public List<Member> MembersByType(int typeId);

        #endregion

        #region MemberDetails

        public MemberDetails CreateUpdateMemberDetails(MemberDetails memberDetails);
        public MemberDetails SingleMemberDetails(int memberDetailsId);
        public MemberDetails DeleteMemberDetails(int memberDetailsId);
        public List<MemberDetails> ListMembersDetails(PaginationFilter filter);

        #endregion

        #region MemberInvitation

        public MemberInvitation CreateMemberInvitation(MemberInvitation memberInvitation);
        public MemberInvitation UpdateMemberInvitation(MemberInvitation memberInvitation);
        public MemberInvitation SingleMemberInvitation(int memberInvitationId);
        public MemberInvitation DeleteMemberInvitation(int memberInvitationId);
        public List<MemberInvitation> ListMemberInvitations(PaginationFilter filter);
        public List<MemberInvitation> MemberInvitationsByStatus(int statusId);
        public List<MemberInvitation> MemberInvitationsByMember(int memberId);

        #endregion

        #region PatientHistory
        public PatientHistory CreateH(PatientHistory history);
        public PatientHistory UpdateH(PatientHistory history);
        public PatientHistory SingleH(int Id);
        public PatientHistory DeleteH(int Id);
        public List<PatientHistory> ListH(PaginationFilter filter);

        public List<PatientHistory> HistoryByPatient(int patientId);
        #endregion
    }
}
