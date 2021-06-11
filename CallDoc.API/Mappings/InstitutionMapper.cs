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
    public class InstitutionMapper : Profile
    {
        public InstitutionMapper()
        {

            #region Institution

            CreateMap<InstitutionUpdateDTO, InstitutionCreateDTO>();
            CreateMap<InstitutionCreateDTO, Institution>()
                .ForMember(i => i.TypeId, opt => opt.MapFrom(n => Convert.ToInt32(DataEncryption.Decrypt(n.TypeId))))
                .ForMember(i => i.StatusId, opt => opt.MapFrom(n => Convert.ToInt32(INSTITUTION_STATUS.Pending)))
                .ForMember(i => i.DateCreated, opt => opt.MapFrom(n => DateTime.Now));
            CreateMap<InstitutionUpdateDTO, Institution>()
                .ForMember(i => i.InstitutionId, opt => opt.MapFrom(n => Convert.ToInt32(DataEncryption.Decrypt(n.InstitutionId))))
                .ForMember(i => i.TypeId, opt => opt.MapFrom(n => Convert.ToInt32(DataEncryption.Decrypt(n.TypeId))))
                .ForMember(i => i.StatusId, opt => opt.MapFrom(n => Convert.ToInt32(DataEncryption.Decrypt(n.StatusId))));
            CreateMap<Institution, InstitutionDTO>()
                .ForMember(i => i.InstitutionId, opt => opt.MapFrom(n => DataEncryption.Encrypt(Convert.ToString(n.InstitutionId))))
                .ForMember(i => i.TypeId, opt => opt.MapFrom(n => DataEncryption.Encrypt(Convert.ToString(n.TypeId))))
                .ForMember(i => i.StatusId, opt => opt.MapFrom(n => DataEncryption.Encrypt(Convert.ToString(n.StatusId))))
                .ForMember(i => i.Status, opt => opt.MapFrom(n => n.Status.Name))
                .ForMember(i => i.Type, opt => opt.MapFrom(n => n.Type.Name));

            #endregion

            #region PlatformSpecialty

            CreateMap<PlatformSpecialtyUpdateDTO, PlatformSpecialtyCreateDTO>();
            CreateMap<PlatformSpecialtyCreateDTO, PlatformSpecialty>()
                .ForMember(s => s.IsActive, opt => opt.MapFrom(p => true))
                .ForMember(s => s.DateCreated, opt => opt.MapFrom(p => DateTime.Now));
            CreateMap<PlatformSpecialtyUpdateDTO, PlatformSpecialty>()
                .ForMember(s => s.SpecialtyId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.SpecialtyId))));
            CreateMap<PlatformSpecialty, PlatformSpecialtyDTO>()
                .ForMember(s => s.SpecialtyId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.SpecialtyId))));
            #endregion

            #region PlatformSubSpecialty

            CreateMap<PlatformSubSpecialtyUpdateDTO, PlatformSubSpecialtyCreateDTO>();
            CreateMap<PlatformSubSpecialtyCreateDTO, PlatformSubSpecialty>()
                .ForMember(s => s.SpecialtyId, opt => opt.MapFrom(u => Convert.ToInt32(DataEncryption.Decrypt(u.SpecialtyId))))
                .ForMember(s => s.IsActive, opt => opt.MapFrom(u => true))
                .ForMember(s => s.DateCreated, opt => opt.MapFrom(u => DateTime.Now));
            CreateMap<PlatformSubSpecialtyUpdateDTO, PlatformSubSpecialty>()
                .ForMember(s => s.SubSpecialtyId, opt => opt.MapFrom(u => Convert.ToInt32(DataEncryption.Decrypt(u.SubSpecialtyId))))
                .ForMember(s => s.SpecialtyId, opt => opt.MapFrom(u => Convert.ToInt32(DataEncryption.Decrypt(u.SpecialtyId))));
            CreateMap<PlatformSubSpecialty, PlatformSubSpecialtyDTO>()
                .ForMember(s => s.SpecialtyId, opt => opt.MapFrom(u => DataEncryption.Encrypt(Convert.ToString(u.SpecialtyId))))
                .ForMember(s => s.SubSpecialtyId, opt => opt.MapFrom(u => DataEncryption.Encrypt(Convert.ToString(u.SubSpecialtyId))))
                .ForMember(s => s.Specialty, opt => opt.MapFrom(u => u.Specialty.Name));

            #endregion

            #region InstitutionBranch

            CreateMap<InstitutionBranchDTO, InstitutionBranchCreateDTO>();
            CreateMap<InstitutionBranch, InstitutionBranchDTO>()
               .ForMember(o => o.InstitutionBranchId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.InstitutionBranchId))))
               .ForMember(o => o.InstitutionId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.InstitutionId))))
               .ForMember(o => o.AddressId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.AddressId))));
            CreateMap<InstitutionBranchCreateDTO, InstitutionBranch>()
                .ForMember(s => s.InstitutionId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.InstitutionId))))
                .ForMember(s => s.AddressId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.AddressId))))
                .ForMember(s => s.DateCreated, opt => opt.MapFrom(d => DateTime.Now));
            CreateMap<InstitutionBranchDTO, InstitutionBranch>()
                .ForMember(s => s.InstitutionBranchId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.InstitutionBranchId))))
                .ForMember(s => s.InstitutionId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.InstitutionId))))
                .ForMember(s => s.AddressId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.AddressId))));
            #endregion

            #region PlatformService

            CreateMap<PlatformServiceUpdateDTO, PlatformServiceCreateDTO>();
            CreateMap<PlatformServiceCreateDTO, PlatformService>()
                .ForMember(s => s.SpecialtyId, opt => opt.MapFrom(u => Convert.ToInt32(DataEncryption.Decrypt(u.SpecialtyId))))
                .ForMember(s => s.SubSpecialtyId, opt => opt.MapFrom(u => Convert.ToInt32(DataEncryption.Decrypt(u.SubSpecialtyId))))
                .ForMember(s => s.IsActive, opt => opt.MapFrom(u => true))
                .ForMember(s => s.DateCreated, opt => opt.MapFrom(u => DateTime.Now));
            CreateMap<PlatformServiceUpdateDTO, PlatformService>()
                .ForMember(s => s.PlatformServiceId, opt => opt.MapFrom(u => Convert.ToInt32(DataEncryption.Decrypt(u.PlatformServiceId))))
                .ForMember(s => s.SpecialtyId, opt => opt.MapFrom(u => Convert.ToInt32(DataEncryption.Decrypt(u.SpecialtyId))))
                .ForMember(s => s.SubSpecialtyId, opt => opt.MapFrom(u => Convert.ToInt32(DataEncryption.Decrypt(u.SubSpecialtyId))));
            CreateMap<PlatformService, PlatformServiceDTO>()
                .ForMember(s => s.SpecialtyId, opt => opt.MapFrom(u => DataEncryption.Encrypt(Convert.ToString(u.SpecialtyId))))
                .ForMember(s => s.SubSpecialtyId, opt => opt.MapFrom(u => DataEncryption.Encrypt(Convert.ToString(u.SubSpecialtyId))))
                .ForMember(s => s.PlatformServiceId, opt => opt.MapFrom(u => DataEncryption.Encrypt(Convert.ToString(u.PlatformServiceId))))
                .ForMember(s => s.Specialty, opt => opt.MapFrom(u => u.Specialty.Name))
                .ForMember(s => s.SubSpecialty, opt => opt.MapFrom(u => u.SubSpecialty.Name));

            #endregion

        }
    }
}
