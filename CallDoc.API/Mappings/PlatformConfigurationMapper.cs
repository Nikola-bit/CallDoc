using AutoMapper;
using CallDoc.API.Models;
using CallDoc.API.Utilities;
using CallDoc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Mappings
{
    public class PlatformConfigurationMapper : Profile
    {
        public PlatformConfigurationMapper()
        {

            #region Platform Configuration

            CreateMap<PlatformConfiguration, PlatformConfigurationDTO>()
                .ForMember(p => p.Value, opt => opt.MapFrom(s => DataEncryption.Encrypt(Convert.ToString(s.Value))));

            #endregion

            #region DoctorSubSpecialties

            CreateMap<DoctorSubSpecialties, DoctorSpecialtiesDTO>()
               .ForMember(o => o.DoctorSubSpecialties1, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.DoctorSubSpecialties1))))
               .ForMember(o => o.SubSpecialtyId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.SubSpecialtyId))))
               .ForMember(o => o.DoctorId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.DoctorId))));
            CreateMap<DoctorSpecialtiesCreateDTO, DoctorSubSpecialties>()
                .ForMember(s => s.SubSpecialtyId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.SubSpecialtyId))))
                .ForMember(s => s.DoctorId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.DoctorId))))
                .ForMember(s => s.DateCreated, opt => opt.MapFrom(d => DateTime.Now));

            #endregion

            #region InstitutionSpecialties

            CreateMap<InstitutionSpecialties, InstitutionSpecialtiesDTO>()
               .ForMember(o => o.InstitutionSpecialtiesId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.InstitutionSpecialtiesId))))
               .ForMember(o => o.InstitutionBranchId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.InstitutionBranchId))))
               .ForMember(o => o.SpecialtyId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.SpecialtyId))));
            CreateMap<InstitutionSpecialtiesCreateDTO, InstitutionSpecialties>()
                .ForMember(s => s.InstitutionBranchId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.InstitutionBranchId))))
                .ForMember(s => s.SpecialtyId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.SpecialtyId))))
                .ForMember(o => o.IsActive, opt => opt.MapFrom(p => true))
                .ForMember(s => s.DateCreated, opt => opt.MapFrom(d => DateTime.Now));

            #endregion

            #region InstitutionSubSpecialties

            CreateMap<InstitutionSubSpecialties, InstitutionSubSpecialtiesDTO>()
               .ForMember(o => o.InstitutionSubSpecialtiesId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.InstintutionSubSpecialtyId))))
               .ForMember(o => o.InstitutionBranchId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.InstitutionBranchId))))
               .ForMember(o => o.SubSpecialtyId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.PlatformSubSpecialtyId))));
            CreateMap<InstitutionSubSpecialtiesCreateDTO, InstitutionSubSpecialties>()
                .ForMember(s => s.InstitutionBranchId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.InstitutionBranchId))))
                .ForMember(s => s.PlatformSubSpecialtyId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.SubSpecialtyId))))
                .ForMember(s => s.DateCreated, opt => opt.MapFrom(d => DateTime.Now));

            #endregion

            #region InstitutionServices

            CreateMap<InstitutionServices, InstitutionServicesDTO>()
               .ForMember(o => o.InstitutionServicesId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.InstitutionServiceId))))
               .ForMember(o => o.InstitutionBranchId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.InstitutionBranchId))))
               .ForMember(o => o.InstitutionDoctorId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.InstitutionDoctorId))))
               .ForMember(o => o.ServicesId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.PlatformServiceId))));
            CreateMap<InstitutionServicesCreateDTO, InstitutionServices>()
                .ForMember(s => s.InstitutionBranchId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.InstitutionBranchId))))
                .ForMember(s => s.PlatformServiceId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.ServicesId))))
                .ForMember(s => s.InstitutionDoctorId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.InstitutionDoctorId))))
                .ForMember(s => s.DateCreated, opt => opt.MapFrom(d => DateTime.Now));

            #endregion
        }
    }
}
