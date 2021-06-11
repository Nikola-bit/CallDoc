using System;
using System.Collections.Generic;
using System.Text;

namespace CallDoc.DTO
{

    #region Address

    public class AddressCreateDTO
    {
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public bool IsPrimary { get; set; }
    }
    public class AddressUpdateDTO : AddressCreateDTO
    {
        public string AddressId { get; set; }
        public bool IsActive { get; set; }
    }
    public class AddressDTO : AddressUpdateDTO
    {
        public DateTime DateCreated { get; set; }
    }

    #endregion

    #region CreditCard

    public class CreditCardCreateDTO
    {
        public string Number { get; set; }
        public string TypeId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string MemberId { get; set; }

    }
    public class CreditCardUpdateDTO : CreditCardCreateDTO
    {
        public string CreditCardId { get; set; }
    }
    public class CreditCardDTO : CreditCardUpdateDTO
    {
        public string CreditCardType { get; set; }
    }

    #endregion

    #region Payment

    public class PaymentCreateDTO
    {
        public string CreditCardId { get; set; }
        public string TotalAmount { get; set; }

    }
    public class PaymentUpdateDTO : PaymentCreateDTO
    {
        public string PaymentId { get; set; }
        public string PaymentStatusId { get; set; }
    }
    public class PaymentDTO : PaymentUpdateDTO
    {
        public string PayerName { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime DateCreated { get; set; }
    }

    #endregion

    #region Appointment
    public class AppointmentCreateDTO
    {

        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public DateTime AppointmentsDate { get; set; }
        public int Duration { get; set; }
        public string TransactionCode { get; set; }
        public string PaymentId { get; set; }
        public string ServiceId { get; set; }
    }

    public class AppointmentUpdateDTO : AppointmentCreateDTO
    {
        public string AppointmentId { get; set; }
        public string StatusId { get; set; }
        public bool? IsCancelled { get; set; }
        public string CancellationReasonNote { get; set; }
        public string? CancellationById { get; set; }
    }

    public class AppointmentDTO : AppointmentUpdateDTO
    {
        public string Price { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public string Service { get; set; }
        public string Status { get; set; }
        public string CancelledBy { get; set; }
    }

    #endregion


}
