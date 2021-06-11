using CallDoc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Services
{
    public interface IServicesService
    {

        #region Address

        public AddressDTO CreateAddress(AddressUpdateDTO address);
        public AddressDTO UpdateAddress(AddressUpdateDTO address);
        public AddressDTO SingleAddress(string addressId);
        public AddressDTO DeleteAddress(string addressId);
        public List<AddressDTO> ListAddresses(PaginationFilter filter);

        #endregion

        #region CreditCard

        public CreditCardDTO CreateCreditCard(CreditCardCreateDTO creditCard);
        public CreditCardDTO SingleCreditCard(string creditCardId);
        public CreditCardDTO DeleteCreditCard(string creditCardId);
        public List<CreditCardDTO> ListCreditCards(PaginationFilter filter);
        public List<CreditCardDTO> CreditCardsByOwner(string ownerId);
        public List<CreditCardDTO> CreditCardsByType(string typeId);

        #endregion

        #region Payment

        public PaymentDTO CreatePayment(PaymentUpdateDTO payment);
        public PaymentDTO UpdatePayment(PaymentUpdateDTO payment);
        public PaymentDTO SinglePayment(string paymentId);
        public PaymentDTO DeletePayment(string paymentId);
        public List<PaymentDTO> ListPayments(PaginationFilter filter);
        public List<PaymentDTO> PaymentsByCreditCard(string creditCardId);
        public List<PaymentDTO> PaymentsByOwner(string ownerId);
        public List<PaymentDTO> PaymentsByStatus(string statusId);

        #endregion

        #region Appointment

        public AppointmentDTO CreateAppointment(AppointmentUpdateDTO appointment);
        public AppointmentDTO UpdateAppointment(AppointmentUpdateDTO appointment);
        public AppointmentDTO SingleAppointment(string appointmentId);
        public AppointmentDTO AppointmentByPayment(string paymentId);
        public AppointmentDTO DeleteAppointment(string appointmentId);
        public List<AppointmentDTO> ListAppointments(PaginationFilter filter);
        public List<AppointmentDTO> AppointmentsByPatient(string patientId);
        public List<AppointmentDTO> AppointmentsByDoctor(string doctorId);
        public List<AppointmentDTO> AppointmentsByService(string serviceId);

        #endregion

    }
}
