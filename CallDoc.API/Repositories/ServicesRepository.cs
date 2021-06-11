using CallDoc.API.Models;
using CallDoc.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace CallDoc.API.Repositories
{
    public class ServicesRepository : IServicesRepository
    {

        #region Address

        public Address CreateAddress(Address address)
        {
            using (var db = new CallDocContext())
            {
                db.Address.Add(address);
                db.SaveChanges();

                return address;
            }
        }

        public Address UpdateAddress(Address address)
        {
            using (var db = new CallDocContext())
            {
                Address editedAddress = db.Address.Where(a => a.AddressId == address.AddressId).FirstOrDefault();

                if (editedAddress != null)
                {
                    editedAddress.City = address.City;
                    editedAddress.Country = address.Country;
                    editedAddress.IsActive = address.IsActive;
                    editedAddress.IsPrimary = address.IsPrimary;
                    editedAddress.PostCode = address.PostCode;
                    editedAddress.StreetName = address.StreetName;

                    db.SaveChanges();
                }

                return editedAddress;
            }
        }
        public Address SingleAddress(int addressId)
        {
            using (var db = new CallDocContext())
            {
                Address address = db.Address.Where(a => a.AddressId == addressId).FirstOrDefault();

                return address;
            }
        }
        public Address DeleteAddress(int addressId)
        {
            using (var db = new CallDocContext())
            {
                Address address = db.Address.Where(a => a.AddressId == addressId).FirstOrDefault();

                Address deletedAddress = address;

                if (deletedAddress != null)
                {
                    db.Address.Remove(deletedAddress);
                    db.SaveChanges();

                    return address;
                }

                else return null;
            }
        }
        public List<Address> ListAddresses(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<Address> addresses = db.Address.ToList();

                addresses = addresses.Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            addresses = addresses.OrderBy(p => p.AddressId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            addresses = addresses.OrderByDescending(p => p.AddressId).ToList();
                            break;
                    }

                }

                return addresses;
            }
        }

        #endregion

        #region CreditCard

        public CreditCard CreateCreditCard(CreditCard creditCard)
        {
            using (var db = new CallDocContext())
            {
                db.CreditCard.Add(creditCard);
                db.SaveChanges();

                creditCard = db.CreditCard.Where(m => m.CreditCardId == creditCard.CreditCardId)
                    .Include(u => u.Type).Include(u => u.Member).ThenInclude(u => u.MemberDetails).FirstOrDefault();

                return creditCard;
            }
        }

        public CreditCard SingleCreditCard(int creditCardId)
        {
            using (var db = new CallDocContext())
            {
                CreditCard creditCard = db.CreditCard.Where(a => a.CreditCardId == creditCardId)
                    .Include(u => u.Type).Include(u => u.Member).ThenInclude(u => u.MemberDetails).FirstOrDefault();

                return creditCard;
            }
        }
        public CreditCard DeleteCreditCard(int creditCardId)
        {
            using (var db = new CallDocContext())
            {
                CreditCard creditCard = db.CreditCard.Where(a => a.CreditCardId == creditCardId)
                    .Include(u => u.Type).Include(u => u.Member).ThenInclude(u => u.MemberDetails).FirstOrDefault();

                CreditCard deletedCreditCard = creditCard;

                if (deletedCreditCard != null)
                {
                    db.CreditCard.Remove(deletedCreditCard);
                    db.SaveChanges();

                    return creditCard;
                }

                else return null;
            }
        }
        public List<CreditCard> ListCreditCards(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<CreditCard> creditCardes = db.CreditCard.Include(u => u.Type).Include(u => u.Member).ThenInclude(u => u.MemberDetails)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            creditCardes = creditCardes.OrderBy(p => p.CreditCardId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            creditCardes = creditCardes.OrderByDescending(p => p.CreditCardId).ToList();
                            break;
                    }

                }

                return creditCardes;
            }
        }

        public List<CreditCard> CreditCardsByOwner(int ownerId)
        {
            using (var db = new CallDocContext())
            {
                List<CreditCard> creditCards = db.CreditCard.Where(c => c.MemberId == ownerId)
                    .Include(u => u.Type).Include(u => u.Member).ThenInclude(u => u.MemberDetails).ToList();

                return creditCards;
            }
        }
        public List<CreditCard> CreditCardsByType(int typeId)
        {
            using (var db = new CallDocContext())
            {
                List<CreditCard> creditCards = db.CreditCard.Where(c => c.TypeId == typeId)
                    .Include(u => u.Type).Include(u => u.Member).ThenInclude(u => u.MemberDetails).ToList();

                return creditCards;
            }
        }

        #endregion

        #region Payment

        public Payment CreatePayment(Payment payment)
        {
            using (var db = new CallDocContext())
            {
                db.Payment.Add(payment);
                db.SaveChanges();

                payment = db.Payment.Where(m => m.PaymentId == payment.PaymentId)
                    .Include(c => c.PaymentStatus).Include(u => u.CreditCard).ThenInclude(s => s.Member).ThenInclude(d => d.MemberDetails).FirstOrDefault();

                return payment;
            }
        }

        public Payment UpdatePayment(Payment payment)
        {
            using (var db = new CallDocContext())
            {
                Payment editedPayment = db.Payment.Where(a => a.PaymentId == payment.PaymentId)
                    .Include(c => c.PaymentStatus).Include(u => u.CreditCard).ThenInclude(s => s.Member).ThenInclude(d => d.MemberDetails).FirstOrDefault();

                if (editedPayment != null)
                {
                    editedPayment.CreditCardId = payment.CreditCardId;
                    editedPayment.PaymentStatusId = payment.PaymentStatusId;
                    editedPayment.TotalAmount = payment.TotalAmount;

                    editedPayment = db.Payment.Where(a => a.PaymentId == payment.PaymentId)
                        .Include(c => c.PaymentStatus).Include(u => u.CreditCard).ThenInclude(s => s.Member).ThenInclude(d => d.MemberDetails).FirstOrDefault();

                    db.SaveChanges();
                }

                return editedPayment;
            }
        }
        public Payment SinglePayment(int paymentId)
        {
            using (var db = new CallDocContext())
            {
                Payment payment = db.Payment.Where(a => a.PaymentId == paymentId)
                    .Include(c => c.PaymentStatus).Include(u => u.CreditCard).ThenInclude(s => s.Member).ThenInclude(d => d.MemberDetails).FirstOrDefault();

                return payment;
            }
        }
        public Payment DeletePayment(int paymentId)
        {
            using (var db = new CallDocContext())
            {
                Payment payment = db.Payment.Where(a => a.PaymentId == paymentId)
                    .Include(c => c.PaymentStatus).Include(u => u.CreditCard).ThenInclude(s => s.Member).ThenInclude(d => d.MemberDetails).FirstOrDefault();

                Payment deletedPayment = payment;

                if (deletedPayment != null)
                {
                    db.Payment.Remove(deletedPayment);
                    db.SaveChanges();

                    return payment;
                }

                else return null;
            }
        }
        public List<Payment> ListPayments(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<Payment> payments = db.Payment.Include(c => c.PaymentStatus).Include(u => u.CreditCard).ThenInclude(s => s.Member).ThenInclude(d => d.MemberDetails)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            payments = payments.OrderBy(p => p.PaymentId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            payments = payments.OrderByDescending(p => p.PaymentId).ToList();
                            break;
                    }

                }
                return payments;
            }
        }

        public List<Payment> PaymentsByCreditCard(int creditCardId)
        {
            using(var db = new CallDocContext())
            {
                List<Payment> payments = db.Payment.Where(p => p.CreditCardId == creditCardId)
                    .Include(c => c.PaymentStatus).Include(u => u.CreditCard).ThenInclude(s => s.Member).ThenInclude(d => d.MemberDetails).ToList();

                return payments;
            }
        }

        public List<Payment> PaymentsByOwner(int ownerId)
        {
            using (var db = new CallDocContext())
            {
                List<Payment> payments = db.Payment.Where(p => p.CreditCard.MemberId == ownerId)
                    .Include(c => c.PaymentStatus).Include(u => u.CreditCard).ThenInclude(s => s.Member).ThenInclude(d => d.MemberDetails).ToList();

                return payments;
            }
        }
        public List<Payment> PaymentsByStatus(int statusId)
        {
            using (var db = new CallDocContext())
            {
                List<Payment> payments = db.Payment.Where(p => p.PaymentStatusId == statusId)
                    .Include(c => c.PaymentStatus).Include(u => u.CreditCard).ThenInclude(s => s.Member).ThenInclude(d => d.MemberDetails).ToList();

                return payments;
            }
        }

        #endregion

        #region Appointment

        public Appointment CreateAppointment(Appointment appointment)
        {
            using (var db = new CallDocContext())
            {
                Service helper = db.Service.Where(s => s.ServiceId == appointment.ServiceId).FirstOrDefault();

                appointment.Price = Convert.ToString(Convert.ToInt32(helper.Price) * Convert.ToInt32(appointment.Duration));

                bool available = CheckAvailability(appointment.AppointmentId, appointment.DoctorId, appointment.PatientId,
                                                    appointment.Duration, appointment.AppointemtsDate);

                if (available == true)
                {
                    db.Appointment.Add(appointment);
                    db.SaveChanges();

                    appointment = db.Appointment.Where(m => m.AppointmentId == appointment.AppointmentId)
                        .Include(s => s.Status).Include(se => se.Service).Include(ca => ca.CancellationBy).ThenInclude(cad => cad.MemberDetails)
                        .Include(p => p.Patient).ThenInclude(pd => pd.MemberDetails).Include(d => d.Doctor).ThenInclude(dd => dd.MemberDetails)
                        .FirstOrDefault();
                }

                else return null;

                return appointment;
            }
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            using (var db = new CallDocContext())
            {
                Appointment editedAppointment = db.Appointment.Where(a => a.AppointmentId == appointment.AppointmentId)
                    .Include(s => s.Status).Include(se => se.Service).Include(ca => ca.CancellationBy).ThenInclude(cad => cad.MemberDetails)
                    .Include(p => p.Patient).ThenInclude(pd => pd.MemberDetails).Include(d => d.Doctor).ThenInclude(dd => dd.MemberDetails)
                    .FirstOrDefault();

                bool available = CheckAvailability(appointment.AppointmentId, appointment.DoctorId, appointment.PatientId,
                                    appointment.Duration, appointment.AppointemtsDate);

                if (editedAppointment != null && available == true)
                {
                    Service helper = db.Service.Where(s => s.ServiceId == appointment.ServiceId).FirstOrDefault();
                    appointment.Price = Convert.ToString(Convert.ToInt32(helper.Price) * Convert.ToInt32(appointment.Duration));

                    editedAppointment.PatientId = appointment.PatientId;
                    editedAppointment.DoctorId = appointment.DoctorId;
                    editedAppointment.StatusId = appointment.StatusId;
                    editedAppointment.PaymentId = appointment.PaymentId;
                    editedAppointment.AppointemtsDate = appointment.AppointemtsDate;
                    editedAppointment.Duration = appointment.Duration;
                    editedAppointment.TransactionCode = appointment.TransactionCode;
                    editedAppointment.ServiceId = appointment.ServiceId;
                    editedAppointment.Price = appointment.Price;

                    if (appointment.IsCancelled == true)
                    {
                        editedAppointment.IsCancelled = appointment.IsCancelled;
                        editedAppointment.CancellationById = appointment.CancellationById;
                        editedAppointment.CancellationReasonNote = appointment.CancellationReasonNote;
                        editedAppointment.StatusId = Convert.ToInt32(APPOINTMENT_STATUS.Cancelled);
                    }


                    db.SaveChanges();

                    editedAppointment = db.Appointment.Where(a => a.AppointmentId == appointment.AppointmentId)
                        .Include(s => s.Status).Include(se => se.Service).Include(ca => ca.CancellationBy).ThenInclude(cad => cad.MemberDetails)
                        .Include(p => p.Patient).ThenInclude(pd => pd.MemberDetails).Include(d => d.Doctor).ThenInclude(dd => dd.MemberDetails)
                        .FirstOrDefault();
                }
                else return null;

                return editedAppointment;
            }
        }
        public Appointment SingleAppointment(int appointmentId)
        {
            using (var db = new CallDocContext())
            {
                Appointment appointment = db.Appointment.Where(a => a.AppointmentId == appointmentId)
                    .Include(s => s.Status).Include(se => se.Service).Include(ca => ca.CancellationBy).ThenInclude(cad => cad.MemberDetails)
                    .Include(p => p.Patient).ThenInclude(pd => pd.MemberDetails).Include(d => d.Doctor).ThenInclude(dd => dd.MemberDetails)
                    .FirstOrDefault();
                return appointment;
            }
        }
        public Appointment AppointmentByPayment(int paymentId)
        {
            using (var db = new CallDocContext())
            {
                Appointment appointment = db.Appointment.Where(p => p.PaymentId == paymentId).Include(s => s.Status).Include(se => se.Service).Include(ca => ca.CancellationBy).ThenInclude(cad => cad.MemberDetails)
                    .Include(p => p.Patient).ThenInclude(pd => pd.MemberDetails).Include(d => d.Doctor).ThenInclude(dd => dd.MemberDetails).FirstOrDefault();

                return appointment;
            }
        }
        public Appointment DeleteAppointment(int appointmentId)
        {
            using (var db = new CallDocContext())
            {
                Appointment appointment = db.Appointment.Where(a => a.AppointmentId == appointmentId)
                    .Include(s => s.Status).Include(se => se.Service).Include(ca => ca.CancellationBy).ThenInclude(cad => cad.MemberDetails)
                    .Include(p => p.Patient).ThenInclude(pd => pd.MemberDetails).Include(d => d.Doctor).ThenInclude(dd => dd.MemberDetails)
                    .FirstOrDefault();

                Appointment deletedAppointment = appointment;

                if (deletedAppointment != null)
                {
                    db.Appointment.Remove(deletedAppointment);
                    db.SaveChanges();

                    return appointment;
                }

                else return null;
            }
        }
        public List<Appointment> ListAppointments(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<Appointment> appointmentes = db.Appointment.Include(s => s.Status).Include(se => se.Service).Include(ca => ca.CancellationBy).ThenInclude(cad => cad.MemberDetails)
                    .Include(p => p.Patient).ThenInclude(pd => pd.MemberDetails).Include(d => d.Doctor).ThenInclude(dd => dd.MemberDetails)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        case "patientid":
                            appointmentes = appointmentes.OrderBy(p => p.PatientId).ToList();
                            break;
                        case "doctorid":
                            appointmentes = appointmentes.OrderBy(p => p.DoctorId).ToList();
                            break;
                        case "appointmentsdate":
                            appointmentes = appointmentes.OrderBy(p => p.AppointemtsDate).ToList();
                            break;
                        case "serviceid":
                            appointmentes = appointmentes.OrderBy(p => p.ServiceId).ToList();
                            break;
                        case "datecreated":
                            appointmentes = appointmentes.OrderBy(p => p.DateCreated).ToList();
                            break;
                        default:
                            appointmentes = appointmentes.OrderBy(p => p.AppointmentId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        case "patientid":
                            appointmentes = appointmentes.OrderByDescending(p => p.PatientId).ToList();
                            break;
                        case "doctorid":
                            appointmentes = appointmentes.OrderByDescending(p => p.DoctorId).ToList();
                            break;
                        case "appointmentsdate":
                            appointmentes = appointmentes.OrderByDescending(p => p.AppointemtsDate).ToList();
                            break;
                        case "serviceid":
                            appointmentes = appointmentes.OrderByDescending(p => p.ServiceId).ToList();
                            break;
                        case "datecreated":
                            appointmentes = appointmentes.OrderByDescending(p => p.DateCreated).ToList();
                            break;
                        default:
                            appointmentes = appointmentes.OrderByDescending(p => p.AppointmentId).ToList();
                            break;
                    }
                }

                return appointmentes;
            }
        }

        public List<Appointment> AppointmentsByPatient(int patientId)
        {
            using (var db = new CallDocContext())
            {
                List<Appointment> appointments = db.Appointment.Where(p => p.PatientId == patientId).Include(s => s.Status).Include(se => se.Service).Include(ca => ca.CancellationBy).ThenInclude(cad => cad.MemberDetails)
                    .Include(p => p.Patient).ThenInclude(pd => pd.MemberDetails).Include(d => d.Doctor).ThenInclude(dd => dd.MemberDetails).ToList();

                return appointments;
            }
        }

        public List<Appointment> AppointmentsByDoctor(int doctorId)
        {
            using (var db = new CallDocContext())
            {
                List<Appointment> appointments = db.Appointment.Where(p => p.DoctorId == doctorId).Include(s => s.Status).Include(se => se.Service).Include(ca => ca.CancellationBy).ThenInclude(cad => cad.MemberDetails)
                    .Include(p => p.Patient).ThenInclude(pd => pd.MemberDetails).Include(d => d.Doctor).ThenInclude(dd => dd.MemberDetails).ToList();

                return appointments;
            }
        }

        public List<Appointment> AppointmentsByService(int serviceId)
        {
            using (var db = new CallDocContext())
            {
                List<Appointment> appointments = db.Appointment.Where(p => p.ServiceId == serviceId).Include(s => s.Status).Include(se => se.Service).Include(ca => ca.CancellationBy).ThenInclude(cad => cad.MemberDetails)
                    .Include(p => p.Patient).ThenInclude(pd => pd.MemberDetails).Include(d => d.Doctor).ThenInclude(dd => dd.MemberDetails).ToList();

                return appointments;
            }
        }

        #endregion

        #region Helping Commands

        public bool CheckAvailability(int appointmentId, int doctorId, int patientId, int duration, DateTime appointmentDate)
        {
            using (var db = new CallDocContext())
            {
                DateTime appointmentEnd = appointmentDate.AddHours(duration);

                Appointment existing = null;

                //1
                existing = db.Appointment.Where(ex => ex.AppointemtsDate >= appointmentDate && ex.AppointemtsDate <= appointmentEnd &&
                                                ex.DoctorId == doctorId && ex.AppointmentId == appointmentId
                                                || ex.AppointemtsDate >= appointmentDate && ex.AppointemtsDate <= appointmentEnd &&
                                                ex.PatientId == patientId).FirstOrDefault();
                //2    
                if (existing == null)
                    existing = db.Appointment.Where(ex => ex.AppointemtsDate >= appointmentDate && ex.AppointemtsDate.AddHours(ex.Duration) <= appointmentEnd &&
                                               ex.DoctorId == doctorId && ex.AppointmentId != appointmentId
                                               || ex.AppointemtsDate >= appointmentDate && ex.AppointemtsDate.AddHours(ex.Duration) <= appointmentEnd &&
                                               ex.PatientId == patientId).FirstOrDefault();

                //3
                if (existing == null)
                    existing = db.Appointment.Where(ex => ex.AppointemtsDate <= appointmentDate && ex.AppointemtsDate.AddHours(ex.Duration) >= appointmentEnd &&
                                               ex.DoctorId == doctorId && ex.AppointmentId != appointmentId
                                               || ex.AppointemtsDate <= appointmentDate && ex.AppointemtsDate.AddHours(ex.Duration) >= appointmentEnd &&
                                               ex.PatientId == patientId).FirstOrDefault();

                //4
                if (existing == null)
                    existing = db.Appointment.Where(ex => ex.AppointemtsDate.AddHours(ex.Duration) >= appointmentDate && ex.AppointemtsDate.AddHours(ex.Duration) <= appointmentEnd &&
                                               ex.DoctorId == doctorId && ex.AppointmentId != appointmentId
                                               || ex.AppointemtsDate.AddHours(ex.Duration) >= appointmentDate && ex.AppointemtsDate.AddHours(ex.Duration) <= appointmentEnd &&
                                               ex.PatientId == patientId).FirstOrDefault();

                if (existing != null && existing.AppointmentId != appointmentId) return false;

                else return true;
            }
        }

        #endregion

    }
}
