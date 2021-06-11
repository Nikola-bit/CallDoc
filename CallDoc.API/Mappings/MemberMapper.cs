using AutoMapper;
using CallDoc.API.Models;
using CallDoc.API.Utilities;
using CallDoc.DTO;
using CallDoc.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Mappings
{
    public class MemberMapper : Profile
    {
        public MemberMapper()
        {

            #region Member

            CreateMap<MemberUpdateDTO, MemberCreateDTO>();
            CreateMap<MemberCreateDTO, Member>()
                .ForMember(m => m.DateCreated, opt => opt.MapFrom(d => DateTime.Now))
                .ForMember(m => m.MemberEmail, opt => opt.MapFrom(d => DataEncryption.Encrypt(d.Email)))
                .ForMember(m => m.MemberPassword, opt => opt.MapFrom(d => DataEncryption.Encrypt(d.Password)))
                .ForMember(m => m.MemberTypeId, opt => opt.MapFrom(d => Convert.ToInt32(DataEncryption.Decrypt(d.MemberTypeId))))
                .ForMember(m => m.MemberStatusId, opt => opt.MapFrom(d => Convert.ToInt32(MEMBER_STATUS.Pending)));
            CreateMap<MemberUpdateDTO, Member>()
                .ForMember(m => m.MemberEmail, opt => opt.MapFrom(d => DataEncryption.Encrypt(d.Email)))
                .ForMember(m => m.MemberPassword, opt => opt.MapFrom(d => DataEncryption.Encrypt(d.Password)))
                .ForMember(m => m.MemberTypeId, opt => opt.MapFrom(d => Convert.ToInt32(DataEncryption.Decrypt(d.MemberTypeId))))
                .ForMember(m => m.MemberStatusId, opt => opt.MapFrom(d => Convert.ToInt32(DataEncryption.Decrypt(d.MemberStatusId))))
                .ForMember(m => m.MemberId, opt => opt.MapFrom(d => Convert.ToInt32(DataEncryption.Decrypt(d.MemberId))));
            CreateMap<Member, MemberDTO>()
                .ForMember(m => m.Email, opt => opt.MapFrom(d => d.MemberEmail))
                .ForMember(m => m.Password, opt => opt.MapFrom(d => d.MemberPassword))
                .ForMember(m => m.MemberId, opt => opt.MapFrom(d => DataEncryption.Encrypt(Convert.ToString(d.MemberId))))
                .ForMember(m => m.MemberStatusId, opt => opt.MapFrom(d => DataEncryption.Encrypt(Convert.ToString(d.MemberStatusId))))
                .ForMember(m => m.MemberStatus, opt => opt.MapFrom(d => d.MemberStatus.Name))
                .ForMember(m => m.MemberTypeId, opt => opt.MapFrom(d => DataEncryption.Encrypt(Convert.ToString(d.MemberTypeId))))
                .ForMember(m => m.MemberType, opt => opt.MapFrom(d => d.MemberType.Name));
            CreateMap<MemberLoginDTO, Member>()
                .ForMember(m => m.MemberEmail, opt => opt.MapFrom(d => DataEncryption.Encrypt(d.Email)))
                .ForMember(m => m.MemberPassword, opt => opt.MapFrom(d => DataEncryption.Encrypt(d.Password)));

            #endregion

            #region Member Details

            CreateMap<MemberDetailsCreateDTO, MemberDetails>()
                .ForMember(m => m.MemberId, opt => opt.MapFrom(e => Convert.ToInt32(DataEncryption.Decrypt(e.MemberId))))
                .ForMember(m => m.DateCreated, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(m => m.PhoneNumber, opt => opt.MapFrom(e => DataEncryption.Encrypt(Convert.ToString(e.PhoneNumber))))
                .ForMember(m => m.AddressId, opt => opt.MapFrom(e => Convert.ToInt32(DataEncryption.Decrypt(e.AddressId))));
            CreateMap<MemberDetails, MemberDetailsDTO>()
                .ForMember(m => m.MemberId, opt => opt.MapFrom(e => DataEncryption.Encrypt(Convert.ToString(e.MemberId))))
                .ForMember(m => m.PhoneNumber, opt => opt.MapFrom(e => DataEncryption.Decrypt(e.PhoneNumber)))
                .ForMember(m => m.MemberType, opt => opt.MapFrom(e => e.Member.MemberType.Name))
               .ForMember(m => m.Address, opt => opt.MapFrom(e => e.Address.StreetName))
               .ForMember(m => m.AddressId, opt => opt.MapFrom(e => DataEncryption.Encrypt(Convert.ToString(e.AddressId))));

            #endregion

            #region Member Invitation

            CreateMap<MemberInvitationUpdateDTO, MemberInvitationCreateDTO>();
            CreateMap<MemberInvitationCreateDTO, MemberInvitation>()
                .ForMember(m => m.MemberId, opt => opt.MapFrom(i => Convert.ToInt32(DataEncryption.Decrypt(i.MemberId))))
                .ForMember(m => m.DateCreated, opt => opt.MapFrom(i => DateTime.Now))
                .ForMember(m => m.StatusId, opt => opt.MapFrom(i => Convert.ToInt32(INVITATION_STATUS.Pending)))
                .ForMember(m => m.Phone, opt => opt.MapFrom(i => DataEncryption.Encrypt(i.Phone)));
            CreateMap<MemberInvitationUpdateDTO, MemberInvitation>()
                .ForMember(m => m.MemberId, opt => opt.MapFrom(i => Convert.ToInt32(DataEncryption.Decrypt(i.MemberId))))
                .ForMember(m => m.DateCreated, opt => opt.MapFrom(i => DateTime.Now))
                .ForMember(m => m.Phone, opt => opt.MapFrom(i => DataEncryption.Encrypt(i.Phone)))
                .ForMember(m => m.StatusId, opt => opt.MapFrom(i => Convert.ToInt32(DataEncryption.Decrypt(i.StatusId))))
                .ForMember(m => m.MemberInvitationId, opt => opt.MapFrom(i => Convert.ToInt32(DataEncryption.Decrypt(i.MemberInvitationId))));
            CreateMap<MemberInvitation, MemberInvitationDTO>()
                .ForMember(m => m.MemberInvitationId, opt => opt.MapFrom(i => DataEncryption.Encrypt(Convert.ToString(i.MemberInvitationId))))
                .ForMember(m => m.MemberId, opt => opt.MapFrom(i => DataEncryption.Encrypt(Convert.ToString(i.MemberId))))
                .ForMember(m => m.Phone, opt => opt.MapFrom(i => DataEncryption.Decrypt(i.Phone)))
                .ForMember(m => m.StatusId, opt => opt.MapFrom(i => DataEncryption.Encrypt(Convert.ToString(i.StatusId))))
                .ForMember(m => m.Status, opt => opt.MapFrom(i => i.Status.Name));

            #endregion

            #region PatientHistory
            CreateMap<PatientHistory, PatientHistoryDTO>()
               .ForMember(o => o.PatientHistoryId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.PatientHistoryId))))
               .ForMember(o => o.AppointmentId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.AppointmentId))));
            CreateMap<PatientHistoryCreateDTO, PatientHistory>()
                .ForMember(s => s.AppointmentId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.AppointmentId))));
            #endregion

        }
    }
}
