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
    public class ServicesMapper : Profile
    {
        public ServicesMapper()
        {

            #region Address

            CreateMap<AddressUpdateDTO, AddressCreateDTO>();
            CreateMap<AddressCreateDTO, Address>()
                .ForMember(a => a.DateCreated, opt => opt.MapFrom(aa => DateTime.Now))
                .ForMember(a => a.IsActive, opt => opt.MapFrom(aa => false));
            CreateMap<AddressUpdateDTO, Address>()
                .ForMember(a => a.AddressId, opt => opt.MapFrom(aa => Convert.ToInt32(DataEncryption.Decrypt(aa.AddressId))));
            CreateMap<Address, AddressDTO>()
                .ForMember(a => a.AddressId, opt => opt.MapFrom(aa => DataEncryption.Encrypt(Convert.ToString(aa.AddressId))));

            #endregion

            #region Credit Card

            CreateMap<CreditCardCreateDTO, CreditCard>()
                .ForMember(c => c.Number, opt => opt.MapFrom(d => DataEncryption.Encrypt(d.Number)))
                .ForMember(c => c.MemberId, opt => opt.MapFrom(d => Convert.ToInt32(DataEncryption.Decrypt(d.MemberId))))
                .ForMember(c => c.TypeId, opt => opt.MapFrom(d => Convert.ToInt32(DataEncryption.Decrypt(d.TypeId))));
            CreateMap<CreditCard, CreditCardDTO>()
                .ForMember(c => c.CreditCardId, opt => opt.MapFrom(d => DataEncryption.Encrypt(Convert.ToString(d.CreditCardId))))
                .ForMember(c => c.MemberId, opt => opt.MapFrom(d => DataEncryption.Encrypt(Convert.ToString(d.MemberId))))
                .ForMember(c => c.TypeId, opt => opt.MapFrom(d => DataEncryption.Encrypt(Convert.ToString(d.TypeId))))
                .ForMember(c => c.CreditCardType, opt => opt.MapFrom(d => d.Type.Name))
                .ForMember(c => c.Number, opt => opt.MapFrom(d => DataEncryption.Decrypt(d.Number)));

            #endregion

            #region Payment

            CreateMap<PaymentUpdateDTO, PaymentCreateDTO>();
            CreateMap<PaymentCreateDTO, Payment>()
                .ForMember(p => p.CreditCardId, opt => opt.MapFrom(s => Convert.ToInt32(DataEncryption.Decrypt(s.CreditCardId))))
                .ForMember(p => p.DateCreated, opt => opt.MapFrom(s => DateTime.Now))
                .ForMember(p => p.PaymentStatusId, opt => opt.MapFrom(s => Convert.ToInt32(PAYMENT_STATUS.Waiting)));
            CreateMap<PaymentUpdateDTO, Payment>()
                .ForMember(p => p.CreditCardId, opt => opt.MapFrom(s => Convert.ToInt32(DataEncryption.Decrypt(s.CreditCardId))))
                .ForMember(p => p.PaymentStatusId, opt => opt.MapFrom(s => Convert.ToInt32(DataEncryption.Decrypt(s.PaymentStatusId))))
                .ForMember(p => p.PaymentId, opt => opt.MapFrom(s => Convert.ToInt32(DataEncryption.Decrypt(s.PaymentId))));
            CreateMap<Payment, PaymentDTO>()
                .ForMember(p => p.PaymentId, opt => opt.MapFrom(s => DataEncryption.Encrypt(Convert.ToString(s.PaymentId))))
                .ForMember(p => p.PaymentStatusId, opt => opt.MapFrom(s => DataEncryption.Encrypt(Convert.ToString(s.PaymentStatusId))))
                .ForMember(p => p.CreditCardId, opt => opt.MapFrom(s => DataEncryption.Encrypt(Convert.ToString(s.CreditCardId))))
                .ForMember(p => p.PaymentStatus, opt => opt.MapFrom(s => s.PaymentStatus.Name))
                .ForMember(p => p.PayerName, opt => opt.MapFrom(s => $"{s.CreditCard.Member.MemberDetails.FirstName} {s.CreditCard.Member.MemberDetails.LastName}"));

            #endregion

            #region Appointment

            CreateMap<AppointmentUpdateDTO, AppointmentCreateDTO>();
            CreateMap<AppointmentCreateDTO, Appointment>()
                .ForMember(a => a.PatientId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.PatientId))))
                .ForMember(a => a.DoctorId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.DoctorId))))
                .ForMember(a => a.PaymentId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.PaymentId))))
                .ForMember(a => a.ServiceId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.ServiceId))))
                .ForMember(a => a.AppointemtsDate, opt => opt.MapFrom(p => p.AppointmentsDate))
                .ForMember(a => a.StatusId, opt => opt.MapFrom(p => APPOINTMENT_STATUS.Scheduled))
                .ForMember(a => a.IsCancelled, opt => opt.MapFrom(p => false))
                .ForMember(a => a.DateCreated, opt => opt.MapFrom(p => DateTime.Now));
            CreateMap<AppointmentUpdateDTO, Appointment>()
                .ForMember(a => a.PatientId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.PatientId))))
                .ForMember(a => a.DoctorId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.DoctorId))))
                .ForMember(a => a.PaymentId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.PaymentId))))
                .ForMember(a => a.ServiceId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.ServiceId))))
                .ForMember(a => a.StatusId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.StatusId))))
                .ForMember(a => a.AppointmentId, opt => opt.MapFrom(p => Convert.ToInt32(DataEncryption.Decrypt(p.AppointmentId))))
                .ForMember(a => a.CancellationById, opt => opt.MapFrom(p => p.CancellationById != "string" ?
                Convert.ToInt32(DataEncryption.Decrypt(p.CancellationById)) : Convert.ToInt32(null)))
                .ForMember(a => a.AppointemtsDate, opt => opt.MapFrom(p => p.AppointmentsDate))
                .ForMember(a => a.StatusId, opt => opt.MapFrom(p => APPOINTMENT_STATUS.Scheduled));
            CreateMap<Appointment, AppointmentDTO>()
                .ForMember(a => a.AppointmentId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.AppointmentId))))
                .ForMember(a => a.PatientId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.PatientId))))
                .ForMember(a => a.DoctorId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.DoctorId))))
                .ForMember(a => a.PaymentId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.PaymentId))))
                .ForMember(a => a.ServiceId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.ServiceId))))
                .ForMember(a => a.StatusId, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.StatusId))))
                .ForMember(a => a.CancellationById, opt => opt.MapFrom(p => DataEncryption.Encrypt(Convert.ToString(p.CancellationById))))
                .ForMember(a => a.Patient, opt => opt.MapFrom(p => $"{p.Patient.MemberDetails.FirstName} {p.Patient.MemberDetails.LastName}"))
                .ForMember(a => a.Doctor, opt => opt.MapFrom(p => $"{p.Doctor.MemberDetails.FirstName} {p.Doctor.MemberDetails.LastName}"))
                .ForMember(a => a.Service, opt => opt.MapFrom(p => $"{p.Service.Title}"))
                .ForMember(a => a.Status, opt => opt.MapFrom(p => $"{p.Status.Name}"))
                .ForMember(a => a.CancelledBy, opt => opt.MapFrom(p => $"{p.CancellationBy.MemberDetails.FirstName} {p.CancellationBy.MemberDetails.LastName}"))
                .ForMember(a => a.AppointmentsDate, opt => opt.MapFrom(p => p.AppointemtsDate));

            #endregion

        }
    }
}
