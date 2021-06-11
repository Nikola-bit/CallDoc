using CallDoc.API.Models;
using CallDoc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace CallDoc.API.Repositories
{

    public interface IServicesRepository
    {

        #region Address

        public Address CreateAddress(Address address);
        public Address UpdateAddress(Address address);
        public Address SingleAddress(int addressId);
        public Address DeleteAddress(int addressId);
        public List<Address> ListAddresses(PaginationFilter filter);

        #endregion

        #region CreditCard

        public CreditCard CreateCreditCard(CreditCard creditCard);
        public CreditCard SingleCreditCard(int creditCardId);
        public CreditCard DeleteCreditCard(int creditCardId);
        public List<CreditCard> ListCreditCards(PaginationFilter filter);
        public List<CreditCard> CreditCardsByOwner(int ownerId);
        public List<CreditCard> CreditCardsByType(int typeId);

        #endregion

        #region Payment

        public Payment CreatePayment(Payment payment);
        public Payment UpdatePayment(Payment payment);
        public Payment SinglePayment(int paymentId);
        public Payment DeletePayment(int paymentId);
        public List<Payment> ListPayments(PaginationFilter filter);
        public List<Payment> PaymentsByCreditCard(int creditCardId);
        public List<Payment> PaymentsByOwner(int ownerId);
        public List<Payment> PaymentsByStatus(int statusId);

        #endregion

        #region Appointment

        public Appointment CreateAppointment(Appointment appointment);
        public Appointment UpdateAppointment(Appointment appointment);
        public Appointment SingleAppointment(int appointmentId);
        public Appointment AppointmentByPayment(int paymentId);
        public Appointment DeleteAppointment(int appointmentId);
        public List<Appointment> ListAppointments(PaginationFilter filter);
        public List<Appointment> AppointmentsByPatient(int patientId);
        public List<Appointment> AppointmentsByDoctor(int doctorId);
        public List<Appointment> AppointmentsByService(int serviceId);
        
        #endregion

    }
}
