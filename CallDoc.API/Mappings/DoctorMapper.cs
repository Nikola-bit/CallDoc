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
    public class DoctorMapper : Profile
    {
        public DoctorMapper()
        {

            #region Service

            CreateMap<ServiceUpdateDTO, ServiceCreateDTO>();
            CreateMap<ServiceCreateDTO, Service>()
                .ForMember(s => s.DoctorId, opt => opt.MapFrom(d => Convert.ToInt32(DataEncryption.Decrypt(d.DoctorId))))
                .ForMember(s => s.DateCreated, opt => opt.MapFrom(d => DateTime.Now))
                .ForMember(s => s.IsActive, opt => opt.MapFrom(d => false));
            CreateMap<ServiceUpdateDTO, Service>()
                .ForMember(s => s.DoctorId, opt => opt.MapFrom(d => Convert.ToInt32(DataEncryption.Decrypt(d.DoctorId))))
                .ForMember(s => s.ServiceId, opt => opt.MapFrom(d => Convert.ToInt32(DataEncryption.Decrypt(d.ServiceId))));
            CreateMap<Service, ServiceDTO>()
                .ForMember(s => s.DoctorId, opt => opt.MapFrom(d => DataEncryption.Encrypt(Convert.ToString(d.DoctorId))))
                .ForMember(s => s.ServiceId, opt => opt.MapFrom(d => DataEncryption.Encrypt(Convert.ToString(d.ServiceId))))
                .ForMember(s => s.DoctorName, opt => opt.MapFrom(d => $"{d.Doctor.MemberDetails.FirstName} {d.Doctor.MemberDetails.LastName}"));
            
            #endregion

        }
    }
}
