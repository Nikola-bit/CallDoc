using AutoMapper;
using CallDoc.API.Models;
using CallDoc.API.Repositories;
using CallDoc.API.Utilities;
using CallDoc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Services
{
    public class ServicesService : IServicesService
    {
        private IServicesRepository repository { get; set; }
        private IMapper mapper { get; set; }
        public ServicesService(IServicesRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        #region Address

        public AddressDTO CreateAddress(AddressUpdateDTO address)
        {
            AddressCreateDTO helper = mapper.Map<AddressCreateDTO>(address);

            Address request = mapper.Map<Address>(helper);

            Address result = repository.CreateAddress(request);

            AddressDTO response = mapper.Map<AddressDTO>(result);

            return response;
        }
        public AddressDTO UpdateAddress(AddressUpdateDTO address)
        {
            Address request = mapper.Map<Address>(address);

            Address result = repository.UpdateAddress(request);

            AddressDTO response = mapper.Map<AddressDTO>(result);

            return response;
        }
        public AddressDTO SingleAddress(string addressId)
        {
            Address result = repository.SingleAddress(Convert.ToInt32(DataEncryption.Decrypt(addressId)));

            AddressDTO response = mapper.Map<AddressDTO>(result);

            return response;
        }
        public AddressDTO DeleteAddress(string addressId)
        {
            Address result = repository.DeleteAddress(Convert.ToInt32(DataEncryption.Decrypt(addressId)));

            AddressDTO response = mapper.Map<AddressDTO>(result);

            return response;
        }
        public List<AddressDTO> ListAddresses(PaginationFilter filter)
        {
            List<Address> result = repository.ListAddresses(filter);

            List<AddressDTO> response = mapper.Map<List<AddressDTO>>(result);

            return response;
        }

        #endregion

        #region CreditCard

        public CreditCardDTO CreateCreditCard(CreditCardCreateDTO creditCard)
        {
            CreditCard request = mapper.Map<CreditCard>(creditCard);

            CreditCard result = repository.CreateCreditCard(request);

            CreditCardDTO response = mapper.Map<CreditCardDTO>(result);

            return response;
        }
        public CreditCardDTO SingleCreditCard(string creditCardId)
        {
            CreditCard result = repository.SingleCreditCard(Convert.ToInt32(DataEncryption.Decrypt(creditCardId)));

            CreditCardDTO response = mapper.Map<CreditCardDTO>(result);

            return response;
        }
        public CreditCardDTO DeleteCreditCard(string creditCardId)
        {
            CreditCard result = repository.DeleteCreditCard(Convert.ToInt32(DataEncryption.Decrypt(creditCardId)));

            CreditCardDTO response = mapper.Map<CreditCardDTO>(result);

            return response;
        }
        public List<CreditCardDTO> ListCreditCards(PaginationFilter filter)
        {
            List<CreditCard> result = repository.ListCreditCards(filter);

            List<CreditCardDTO> response = mapper.Map<List<CreditCardDTO>>(result);

            return response;
        }

        public List<CreditCardDTO> CreditCardsByOwner(string ownerId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(ownerId));

            List<CreditCard> result = repository.CreditCardsByOwner(request);

            List<CreditCardDTO> response = mapper.Map<List<CreditCardDTO>>(result);

            return response;
        }
        public List<CreditCardDTO> CreditCardsByType(string creditCardId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(creditCardId));

            List<CreditCard> result = repository.CreditCardsByType(request);

            List<CreditCardDTO> response = mapper.Map<List<CreditCardDTO>>(result);

            return response;
        }

        #endregion

        #region Payment

        public PaymentDTO CreatePayment(PaymentUpdateDTO payment)
        {
            PaymentCreateDTO helper = mapper.Map<PaymentCreateDTO>(payment);

            Payment request = mapper.Map<Payment>(helper);

            Payment result = repository.CreatePayment(request);

            PaymentDTO response = mapper.Map<PaymentDTO>(result);

            return response;
        }
        public PaymentDTO UpdatePayment(PaymentUpdateDTO payment)
        {
            Payment request = mapper.Map<Payment>(payment);

            Payment result = repository.UpdatePayment(request);

            PaymentDTO response = mapper.Map<PaymentDTO>(result);

            return response;
        }
        public PaymentDTO SinglePayment(string paymentId)
        {
            Payment result = repository.SinglePayment(Convert.ToInt32(DataEncryption.Decrypt(paymentId)));

            PaymentDTO response = mapper.Map<PaymentDTO>(result);

            return response;
        }
        public PaymentDTO DeletePayment(string paymentId)
        {
            Payment result = repository.DeletePayment(Convert.ToInt32(DataEncryption.Decrypt(paymentId)));

            PaymentDTO response = mapper.Map<PaymentDTO>(result);

            return response;
        }
        public List<PaymentDTO> ListPayments(PaginationFilter filter)
        {
            List<Payment> result = repository.ListPayments(filter);

            List<PaymentDTO> response = mapper.Map<List<PaymentDTO>>(result);

            return response;
        }
        public List<PaymentDTO> PaymentsByCreditCard(string creditCardId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(creditCardId));

            List<Payment> result = repository.PaymentsByCreditCard(request);

            List<PaymentDTO> response = mapper.Map<List<PaymentDTO>>(result);

            return response;
        }
        public List<PaymentDTO> PaymentsByOwner(string ownerId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(ownerId));

            List<Payment> result = repository.PaymentsByOwner(request);

            List<PaymentDTO> response = mapper.Map<List<PaymentDTO>>(result);

            return response;
        }
        public List<PaymentDTO> PaymentsByStatus(string statusId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(statusId));

            List<Payment> result = repository.PaymentsByStatus(request);

            List<PaymentDTO> response = mapper.Map<List<PaymentDTO>>(result);

            return response;
        }

        #endregion

        #region Appointment

        public AppointmentDTO CreateAppointment(AppointmentUpdateDTO appointment)
        {
            AppointmentCreateDTO helper = mapper.Map<AppointmentCreateDTO>(appointment);

            Appointment request = mapper.Map<Appointment>(helper);

            Appointment result = repository.CreateAppointment(request);

            AppointmentDTO response = mapper.Map<AppointmentDTO>(result);

            return response;
        }
        public AppointmentDTO UpdateAppointment(AppointmentUpdateDTO appointment)
        {
            Appointment request = mapper.Map<Appointment>(appointment);

            Appointment result = repository.UpdateAppointment(request);

            AppointmentDTO response = mapper.Map<AppointmentDTO>(result);

            return response;
        }
        public AppointmentDTO SingleAppointment(string appointmentId)
        {
            Appointment result = repository.SingleAppointment(Convert.ToInt32(DataEncryption.Decrypt(appointmentId)));

            AppointmentDTO response = mapper.Map<AppointmentDTO>(result);

            return response;
        }
        public AppointmentDTO AppointmentByPayment(string paymentId)
        {
            Appointment result = repository.AppointmentByPayment(Convert.ToInt32(DataEncryption.Decrypt(paymentId)));

            AppointmentDTO response = mapper.Map<AppointmentDTO>(result);

            return response;
        }
        public AppointmentDTO DeleteAppointment(string appointmentId)
        {
            Appointment result = repository.DeleteAppointment(Convert.ToInt32(DataEncryption.Decrypt(appointmentId)));

            AppointmentDTO response = mapper.Map<AppointmentDTO>(result);

            return response;
        }
        public List<AppointmentDTO> ListAppointments(PaginationFilter filter)
        {
            List<Appointment> result = repository.ListAppointments(filter);

            List<AppointmentDTO> response = mapper.Map<List<AppointmentDTO>>(result);

            return response;
        }
        public List<AppointmentDTO> AppointmentsByPatient(string patientId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(patientId));

            List<Appointment> result = repository.AppointmentsByPatient(request);

            List<AppointmentDTO> response = mapper.Map<List<AppointmentDTO>>(result);

            return response;
        }
        public List<AppointmentDTO> AppointmentsByDoctor(string doctorId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(doctorId));

            List<Appointment> result = repository.AppointmentsByDoctor(request);

            List<AppointmentDTO> response = mapper.Map<List<AppointmentDTO>>(result);

            return response;
        }
        public List<AppointmentDTO> AppointmentsByService(string serviceId)
        {
            int request = Convert.ToInt32(DataEncryption.Decrypt(serviceId));

            List<Appointment> result = repository.AppointmentsByService(request);

            List<AppointmentDTO> response = mapper.Map<List<AppointmentDTO>>(result);

            return response;
        }

        #endregion

    }
}
