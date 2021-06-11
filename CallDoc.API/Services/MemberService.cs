using AutoMapper;
using CallDoc.API.Repositories;
using CallDoc.DTO.DTO;
using CallDoc.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallDoc.API.Utilities;
using CallDoc.DTO;
using Microsoft.OpenApi.Expressions;

namespace CallDoc.API.Services
{
    public class MemberService : IMemberService
    {

        #region Depencency Injection 

        private IMemberRepository repository { get; set; }
        private IAuthRepository authRepository { get; set; }
        private IMapper mapper { get; set; }
        public MemberService(IMemberRepository _repository, IMapper _mapper, IAuthRepository _authRepository)
        {
            mapper = _mapper;
            repository = _repository;
            authRepository = _authRepository;
        }

        #endregion

        #region Member

        public MemberTokenDTO LoginMember(MemberLoginDTO member)
        {
            Member request = mapper.Map<Member>(member);

            Member result = repository.LoginMember(request);

            if (result != null)
            {
                if (result.MemberStatusId == Convert.ToInt32(MEMBER_STATUS.Active))
                {
                    MemberTokenDTO response = new MemberTokenDTO()
                    {
                        Member = mapper.Map<MemberDTO>(result),
                        Token = authRepository.CreateToken(result)
                    };

                    return response;
                }
                else
                {
                    MemberTokenDTO emptyTokenResponse = new MemberTokenDTO()
                    {
                        Member = mapper.Map<MemberDTO>(result),
                        Token = null
                    };

                    return emptyTokenResponse;
                }
            }
            else return null;
        }
        public MemberDTO CreateMember(MemberUpdateDTO member)
        {
            MemberCreateDTO helper = mapper.Map<MemberCreateDTO>(member);

            Member request = mapper.Map<Member>(helper);

            Member result = repository.CreateMember(request);

            MemberDTO response = mapper.Map<MemberDTO>(result);

            return response;
        }
        public MemberDTO UpdateMember(MemberUpdateDTO member)
        {
            Member request = mapper.Map<Member>(member);

            Member result = repository.UpdateMember(request);

            MemberDTO response = mapper.Map<MemberDTO>(result);

            return response;
        }
        public MemberDTO SingleMember(string memberId)
        {
            Member result = repository.SingleMember(Convert.ToInt32(DataEncryption.Decrypt(memberId)));

            MemberDTO response = mapper.Map<MemberDTO>(result);

            return response;
        }
        public MemberDTO DeleteMember(string memberId)
        {
            Member result = repository.DeleteMember(Convert.ToInt32(DataEncryption.Decrypt(memberId)));

            MemberDTO response = mapper.Map<MemberDTO>(result);

            return response;
        }
        public List<MemberDTO> ListMembers(PaginationFilter filter)
        {
            List<Member> result = repository.ListMembers(filter);

            List<MemberDTO> response = mapper.Map<List<MemberDTO>>(result);

            return response;
        }
        public List<MemberDTO> MembersByStatus(string statusId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(statusId));

            List<Member> result = repository.MembersByStatus(request);

            List<MemberDTO> response = mapper.Map<List<MemberDTO>>(result);

            return response;
        }
        public List<MemberDTO> MembersByType(string typeId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(typeId));

            List<Member> result = repository.MembersByType(request);

            List<MemberDTO> response = mapper.Map<List<MemberDTO>>(result);

            return response;
        }

        #endregion

        #region MemberDetails

        public MemberDetailsDTO CreateUpdateMemberDetails(MemberDetailsCreateDTO memberDetails)
        {
            MemberDetails request = mapper.Map<MemberDetails>(memberDetails);

            MemberDetails result = repository.CreateUpdateMemberDetails(request);

            MemberDetailsDTO response = mapper.Map<MemberDetailsDTO>(result);

            return response;
        }
        public MemberDetailsDTO SingleMemberDetails(string memberId)
        {
            MemberDetails result = repository.SingleMemberDetails(Convert.ToInt32(DataEncryption.Decrypt(memberId)));

            MemberDetailsDTO response = mapper.Map<MemberDetailsDTO>(result);

            return response;
        }
        public MemberDetailsDTO DeleteMemberDetails(string memberId)
        {
            MemberDetails result = repository.DeleteMemberDetails(Convert.ToInt32(DataEncryption.Decrypt(memberId)));

            MemberDetailsDTO response = mapper.Map<MemberDetailsDTO>(result);

            return response;
        }
        public List<MemberDetailsDTO> ListMembersDetails(PaginationFilter filter)
        {
            List<MemberDetails> result = repository.ListMembersDetails(filter);

            List<MemberDetailsDTO> response = mapper.Map<List<MemberDetailsDTO>>(result);

            return response;
        }

        #endregion

        #region MemberInvitation

        public MemberInvitationDTO CreateMemberInvitation(MemberInvitationUpdateDTO memberInvitation)
        {
            MemberInvitationCreateDTO helper = mapper.Map<MemberInvitationCreateDTO>(memberInvitation);

            MemberInvitation request = mapper.Map<MemberInvitation>(helper);

            MemberInvitation result = repository.CreateMemberInvitation(request);

            MemberInvitationDTO response = mapper.Map<MemberInvitationDTO>(result);

            return response;
        }
        public MemberInvitationDTO UpdateMemberInvitation(MemberInvitationUpdateDTO memberInvitation)
        {
            MemberInvitation request = mapper.Map<MemberInvitation>(memberInvitation);

            MemberInvitation result = repository.UpdateMemberInvitation(request);

            MemberInvitationDTO response = mapper.Map<MemberInvitationDTO>(result);

            return response;
        }
        public MemberInvitationDTO SingleMemberInvitation(string memberInvitationId)
        {
            MemberInvitation result = repository.SingleMemberInvitation(Convert.ToInt32(DataEncryption.Decrypt(memberInvitationId)));

            MemberInvitationDTO response = mapper.Map<MemberInvitationDTO>(result);

            return response;
        }
        public MemberInvitationDTO DeleteMemberInvitation(string memberInvitationId)
        {
            MemberInvitation result = repository.DeleteMemberInvitation(Convert.ToInt32(DataEncryption.Decrypt(memberInvitationId)));

            MemberInvitationDTO response = mapper.Map<MemberInvitationDTO>(result);

            return response;
        }
        public List<MemberInvitationDTO> ListMemberInvitations(PaginationFilter filter)
        {
            List<MemberInvitation> result = repository.ListMemberInvitations(filter);

            List<MemberInvitationDTO> response = mapper.Map<List<MemberInvitationDTO>>(result);

            return response;
        }
        public List<MemberInvitationDTO> MemberInvitationsByStatus(string statusId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(statusId));

            List<MemberInvitation> result = repository.MemberInvitationsByStatus(request);

            List<MemberInvitationDTO> response = mapper.Map<List<MemberInvitationDTO>>(result);

            return response;
        }
        public List<MemberInvitationDTO> MemberInvitationsByMember(string memberId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(memberId));

            List<MemberInvitation> result = repository.MemberInvitationsByMember(request);

            List<MemberInvitationDTO> response = mapper.Map<List<MemberInvitationDTO>>(result);

            return response;
        }

        #endregion

        #region PatientHistory
        public PatientHistoryDTO CreateHistory(PatientHistoryCreateDTO institution)
        {
            PatientHistoryCreateDTO helper = mapper.Map<PatientHistoryCreateDTO>(institution);

            PatientHistory request = mapper.Map<PatientHistory>(helper);

            PatientHistory result = repository.CreateH(request);

            PatientHistoryDTO response = mapper.Map<PatientHistoryDTO>(result);

            return response;
        }
        public PatientHistoryDTO UpdateHistory(PatientHistoryDTO institution)
        {
            PatientHistory request = mapper.Map<PatientHistory>(institution);

            PatientHistory result = repository.UpdateH(request);

            PatientHistoryDTO response = mapper.Map<PatientHistoryDTO>(result);

            return response;
        }
        public PatientHistoryDTO SingleHistory(string Id)
        {
            PatientHistory result = repository.SingleH(Convert.ToInt32(DataEncryption.Decrypt(Id)));

            PatientHistoryDTO response = mapper.Map<PatientHistoryDTO>(result);

            return response;
        }
        public PatientHistoryDTO DeleteHistory(string Id)
        {
            PatientHistory result = repository.DeleteH(Convert.ToInt32(DataEncryption.Decrypt(Id)));

            PatientHistoryDTO response = mapper.Map<PatientHistoryDTO>(result);

            return response;
        }
        public List<PatientHistoryDTO> ListHistory(PaginationFilter filter)
        {
            List<PatientHistory> result = repository.ListH(filter);

            List<PatientHistoryDTO> response = mapper.Map<List<PatientHistoryDTO>>(result);

            return response;
        }

        public List<PatientHistoryDTO> HistoryByPatient(string patientId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(patientId));

            List<PatientHistory> result = repository.HistoryByPatient(request);

            List<PatientHistoryDTO> response = mapper.Map<List<PatientHistoryDTO>>(result);

            return response;
        }

        #endregion
    }
}
