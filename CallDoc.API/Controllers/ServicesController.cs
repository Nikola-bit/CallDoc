using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallDoc.API.Filters;
using CallDoc.API.Services;
using CallDoc.API.Utilities;
using CallDoc.DTO;
using CallDoc.DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallDoc.API.Controllers
{
    [Route("services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private IServicesService service { get; set; }
        private IMemberService mService { get; set; }
        public ServicesController(IServicesService _service, IMemberService _memberService)
        {
            service = _service;
            mService = _memberService;
        }

        #region Address

        /// <summary>
        /// Create/Update an address.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/address/create/update
        ///         {
        ///               "addressId": "I14kpXunkSuJIU+8++5v3Q==" (If making update),
        ///               "IsActive": true (If making update),
        ///               "streetName": "ul. Blagoj Gjorev 22/1",
        ///               "city": "Veles",
        ///               "country": "Macedonia",
        ///               "postCode": "1400",
        ///               "isPrimary": true
        ///         }
        /// </remarks>
        /// <returns>Address</returns>
        /// <response code = "200">Returns the created/updated address.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("address/create/update")]
        public IActionResult CreateUpdateAddress([FromBody] AddressUpdateDTO address)
        {
            AddressDTO response = null;

            if (address.AddressId != null && address.AddressId != "string")
            {
                response = service.UpdateAddress(address);
            }
            else
            {
                response = service.CreateAddress(address);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }

        /// <summary>
        /// Find single address.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/address/single
        ///         {
        ///               "addressId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Address</returns>
        /// <response code = "200">Returns the searched address.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("address/single")]
        public IActionResult SingleAddress([FromQuery] string addressId)
        {
            AddressDTO response = service.SingleAddress(addressId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any address with the inserted ID.");
        }

        /// <summary>
        /// Remove an address.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/address/remove
        ///         {
        ///               "addressId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Address</returns>
        /// <response code = "200">Returns the removed address.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("address/remove")]
        public IActionResult RemoveAddress([FromQuery] string addressId)
        {
            AddressDTO response = service.DeleteAddress(addressId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any address with the inserted ID.");
        }
        /// <summary>
        /// List addresses.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/address/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>Addresses</returns>
        /// <response code = "200">Returns a list of addresses.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("address/list")]
        public IActionResult ListAddresses([FromBody] PaginationFilter filter)
        {
            List<AddressDTO> response = service.ListAddresses(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any addresses on searched rows or there aren't any.");
        }

        #endregion

        #region CreditCard

        /// <summary>
        /// Create/Update a credit card.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/credit/card/create
        ///         {
        ///             "number": "5000-3343-2243-3454",
        ///             "typeId": "XPal4vWxjKDhgp1I5DIRKg==",
        ///             "expiryDate": "2020-10-21T10:39:57.145Z",
        ///             "memberId": "J+XGDuQUCVmqW6xWEd4pRw=="
        ///         }
        /// </remarks>
        /// <returns>Credit Card</returns>
        /// <response code = "200">Returns the created/updated credit card.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("credit/card/create")]
        public IActionResult CreateCreditCard([FromBody] CreditCardCreateDTO creditCard)
        {
            CreditCardDTO response = service.CreateCreditCard(creditCard);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }

        /// <summary>
        /// Find single credit card.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/credit/card/single
        ///         {
        ///               "creditCardId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Credit Card</returns>
        /// <response code = "200">Returns the searched credit card.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("credit/card/single")]
        public IActionResult SingleCreditCard([FromQuery] string creditCardId)
        {
            CreditCardDTO response = service.SingleCreditCard(creditCardId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any creditCard with the inserted ID.");
        }

        /// <summary>
        /// Remove a credit card.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/credit/card/remove
        ///         {
        ///               "creditCardId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Credit Card</returns>
        /// <response code = "200">Returns the removed credit card.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("credit/card/remove")]
        public IActionResult RemoveCreditCard([FromQuery] string creditCardId)
        {
            CreditCardDTO response = service.DeleteCreditCard(creditCardId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any creditCard with the inserted ID.");
        }
        /// <summary>
        /// List credit cards.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/credit/card/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>Credit Cards</returns>
        /// <response code = "200">Returns a list of credit cards.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("credit/card/list")]
        public IActionResult ListCreditCards([FromBody] PaginationFilter filter)
        {
            List<CreditCardDTO> response = service.ListCreditCards(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any creditCards on searched rows or there aren't any.");
        }

        /// <summary>
        /// List credit cards owned by custom member.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/credit/card/list/member
        ///
        /// </remarks>
        /// <returns>Credit Cards</returns>
        /// <response code = "200">Returns a list of credit cards.</response>
        /// <response code = "400">An error occured.</response>
        [AuthFilter]
        [HttpGet("credit/card/list/member")]
        public IActionResult CreditCardsByOwner()
        {
            string ownerId = Startup.MemberId;

            List<CreditCardDTO> creditCards = service.CreditCardsByOwner(ownerId);

            if (creditCards != null)
            {
                return new ObjectResult(creditCards);
            }

            else return new NotFoundObjectResult("The logged patient doesn't have any credit card inserted.");
        }
        /// <summary>
        /// List credit cards owned by custom type.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/credit/card/list/by/type
        ///         {
        ///               "typeId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Credit Cards</returns>
        /// <response code = "200">Returns a list of credit cards.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("credit/card/list/by/type")]
        public IActionResult CreditCardsByType([FromQuery] string typeId)
        {
            List<CreditCardDTO> creditCards = service.CreditCardsByType(typeId);

            if (creditCards != null)
            {
                return new ObjectResult(creditCards);
            }

            else return new NotFoundObjectResult("There is not any credit card from that type.");
        }

        #endregion

        #region Payment

        /// <summary>
        /// Create/Update a payment.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/payment/create/update
        ///         {
        ///             "paymentId": "AWITwbEO4CpyPIjTCuwo7w==" (If making update),
        ///             "paymentStatusId": "FnV9//ikc71XLppgH6p0nw==" (If making update),
        ///             "creditCardId": "FnV9//ikc71XLppgH6p0nw==",
        ///             "totalAmount": "230"
        ///         }
        /// </remarks>
        /// <returns>Payment</returns>
        /// <response code = "200">Returns the created/updated payment.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("payment/create/update")]
        public IActionResult CreateUpdatePayment([FromBody] PaymentUpdateDTO payment)
        {
            PaymentDTO response = null;

            if (payment.PaymentId != null && payment.PaymentId != "string")
            {
                response = service.UpdatePayment(payment);
            }
            else
            {
                response = service.CreatePayment(payment);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }

        /// <summary>
        /// Find single payment.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/payment/single
        ///         {
        ///               "paymentId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Payment</returns>
        /// <response code = "200">Returns the searched payment.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("payment/single")]
        public IActionResult SinglePayment([FromQuery] string paymentId)
        {
            PaymentDTO response = service.SinglePayment(paymentId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any payment with the inserted ID.");
        }

        /// <summary>
        /// Remove a payment.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/payment/remove
        ///         {
        ///               "paymentId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Payment</returns>
        /// <response code = "200">Returns the removed payment.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("payment/remove")]
        public IActionResult RemovePayment([FromQuery] string paymentId)
        {
            PaymentDTO response = service.DeletePayment(paymentId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any payment with the inserted ID.");
        }
        /// <summary>
        /// List payments.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/payment/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>Payments</returns>
        /// <response code = "200">Returns a list of payments.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("payment/list")]
        public IActionResult ListPayments([FromBody] PaginationFilter filter)
        {
            List<PaymentDTO> response = service.ListPayments(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any payments on searched rows or there aren't any.");
        }

        /// <summary>
        /// List payments done by custom credit card.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/payment/list/by/credit/card
        ///         {
        ///               "creditCardId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Payments</returns>
        /// <response code = "200">Returns a list of payments.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("payment/list/by/credit/card")]
        public IActionResult PaymentsByCreditCard([FromQuery] string creditCardId)
        {
            List<PaymentDTO> payments = service.PaymentsByCreditCard(creditCardId);

            if (payments != null)
            {
                return new ObjectResult(payments);
            }

            else return new NotFoundObjectResult("There was not any payments done with that credit card or the credit card is not existing.");
        }

        /// <summary>
        /// List payments done by custom member.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/payment/list/by/owner
        ///         {
        ///               "ownerId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Payments</returns>
        /// <response code = "200">Returns a list of payments.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("payment/list/by/owner")]
        public IActionResult PaymentsByOwner([FromQuery] string ownerId)
        {
            List<PaymentDTO> payments = service.PaymentsByOwner(ownerId);

            if (payments != null)
            {
                return new ObjectResult(payments);
            }

            else return new NotFoundObjectResult("A patient with that id hasn't done any payments or is not existing.");
        }
        /// <summary>
        /// List payments done by custom status.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/payment/list/by/status
        ///         {
        ///               "statusId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Payments</returns>
        /// <response code = "200">Returns a list of payments.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("payment/list/by/status")]
        public IActionResult PaymentsByStatus([FromQuery] string statusId)
        {
            List<PaymentDTO> payments = service.PaymentsByStatus(statusId);

            if (payments != null)
            {
                return new ObjectResult(payments);
            }

            else return new NotFoundObjectResult("There is not any payment with that status.");
        }

        #endregion

        #region Appointment

        /// <summary>
        /// Create/Update an appointment.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/appointment/create/update
        ///         {
        ///             "patientId": "J+XGDuQUCVmqW6xWEd4pRw==",
        ///             "doctorId": "J+XGDuQUCVmqW6xWEd4pRw==",
        ///             "appointmentDate": "J+XGDuQUCVmqW6xWEd4pRw==",
        ///             "duration": 3,
        ///             "transactionCode": "3435-3452-3531-2345",
        ///             "paymentId": "J+XGDuQUCVmqW6xWEd4pRw==",
        ///             "serviceId": "J+XGDuQUCVmqW6xWEd4pRw==",
        ///             "appointmentId": "J+XGDuQUCVmqW6xWEd4pRw==" (If making update),
        ///             "statusId": "J+XGDuQUCVmqW6xWEd4pRw==" (If making update),
        ///             "isCancelled": true (If cancelling),
        ///             "cancellationReasonNote": "I must go on blood pressure test." (If cancelling),
        ///             "cancellationById": "J+XGDuQUCVmqW6xWEd4pRw==" (If cancelling),
        ///         }
        /// </remarks>
        /// <returns>Appointment</returns>
        /// <response code = "200">Returns the created/updated appointment.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("appointment/create/update")]
        public IActionResult CreateUpdateAppointment([FromBody] AppointmentUpdateDTO appointment)
        {
            AppointmentDTO response = null;

            if (appointment.AppointmentId != null && appointment.AppointmentId != "string")
            {
                response = service.UpdateAppointment(appointment);
            }
            else
            {
                response = service.CreateAppointment(appointment);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations or some of the participants calendar has scheduled meeting in that time.");
        }

        /// <summary>
        /// Find single appointment.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/appointment/single
        ///         {
        ///               "appointmentId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Appointment</returns>
        /// <response code = "200">Returns the searched appointment.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("appointment/single")]
        public IActionResult SingleAppointment([FromQuery] string appointmentId)
        {
            AppointmentDTO response = service.SingleAppointment(appointmentId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any appointment with the inserted ID.");
        }
        /// <summary>
        /// Find appointment by payment.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/appointment/single/byPayment
        ///         {
        ///               "paymentId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Appointment</returns>
        /// <response code = "200">Returns the appointment by searched payment.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("appointment/single/byPayment")]
        public IActionResult AppointmentByPayment([FromQuery] string paymentId)
        {
            AppointmentDTO response = service.AppointmentByPayment(paymentId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any appointment registered with that payment.");
        }

        /// <summary>
        /// Remove an appointment.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/appointment/remove
        ///         {
        ///               "appointmentId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Appointment</returns>
        /// <response code = "200">Returns the removed appointment.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("appointment/remove")]
        public IActionResult RemoveAppointment([FromQuery] string appointmentId)
        {
            AppointmentDTO response = service.DeleteAppointment(appointmentId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any appointment with the inserted ID.");
        }
        /// <summary>
        /// List appointments.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/appointment/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "AppointemtsDate" (PatientId, DoctorId, AppointemtsDate, ServiceId, DateCreated),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>Appointments</returns>
        /// <response code = "200">Returns a list of appointments.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("appointment/list")]
        public IActionResult ListAppointmentes([FromBody] PaginationFilter filter)
        {
            List<AppointmentDTO> response = service.ListAppointments(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any appointments on searched rows or there aren't any.");
        }

        /// <summary>
        /// List appointments by patient.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/appointment/list/by/patient
        ///         {
        ///               "patientId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Appointments</returns>
        /// <response code = "200">Returns a list of appointments.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("appointment/list/by/patient")]
        public IActionResult AppointmentsByPatient([FromQuery] string patientId)
        {
            List<AppointmentDTO> appointments = service.AppointmentsByPatient(patientId);

            if (appointments != null)
            {
                return new ObjectResult(appointments);
            }

            else return new NotFoundObjectResult("There was not any appointment where the patient was the searched one.");
        }

        /// <summary>
        /// List appointments by doctor.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/appointment/list/by/doctor
        ///         {
        ///               "doctorId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Appointments</returns>
        /// <response code = "200">Returns a list of appointments.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("appointment/list/by/doctor")]
        public IActionResult AppointmentsByDoctor([FromQuery] string doctorId)
        {
            List<AppointmentDTO> appointments = service.AppointmentsByDoctor(doctorId);

            if (appointments != null)
            {
                return new ObjectResult(appointments);
            }

            else return new NotFoundObjectResult("There was not any appointment where the doctor was the searched one.");
        }

        /// <summary>
        /// List appointments by service.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/appointment/list/by/service
        ///         {
        ///               "serviceId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Appointments</returns>
        /// <response code = "200">Returns a list of appointments.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("appointment/list/by/service")]
        public IActionResult AppointmentsByService([FromQuery] string serviceId)
        {
            List<AppointmentDTO> appointments = service.AppointmentsByService(serviceId);

            if (appointments != null)
            {
                return new ObjectResult(appointments);
            }

            else return new NotFoundObjectResult("There was not any appointment with the searched service.");
        }

        #endregion

        #region PatientHistory

        /// <summary>
        /// Create/Update a patient history.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/patient/history/create/update
        ///         {
        ///               "patientHistoryId": "I14kpXunkSuJIU+8++5v3Q==" (If making update),
        ///               "appointmentId": "I14kpXunkSuJIU+8++5v3Q==",
        ///               "diagnose": "something",
        ///               "findingNote" : "some",
        ///               "treatmentNote" : "treatment",
        ///               "doctorInternNote" : "note"
        ///         }
        /// </remarks>
        /// <returns>Patient History</returns>
        /// <response code = "200">Returns the created/updated patient history.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("patient/history/create/update")]
        public IActionResult CreateUpdateHistory([FromBody] PatientHistoryDTO institution)
        {
            PatientHistoryDTO response = null;

            if (institution.PatientHistoryId != null && institution.PatientHistoryId != "string")
            {
                response = mService.UpdateHistory(institution);
            }
            else
            {
                response = mService.CreateHistory(institution);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }
        /// <summary>
        /// Find single patient history.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/patient/history/single
        ///         {
        ///               "patienthistoryId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Patient History</returns>
        /// <response code = "200">Returns the searched history.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("patient/history/single")]
        public IActionResult SinglePHistory([FromQuery] string Id)
        {
            PatientHistoryDTO response = mService.SingleHistory(Id);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any history with the inserted ID.");
        }
        /// <summary>
        /// Remove a patient history.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/patient/history/remove
        ///         {
        ///               "patientHistoryId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Patient History</returns>
        /// <response code = "200">Returns the removed patient history.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("patient/history/remove")]
        public IActionResult RemovePHistory([FromQuery] string Id)
        {
            PatientHistoryDTO response = mService.DeleteHistory(Id);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any history with the inserted ID.");
        }
        /// <summary>
        /// List patients history.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST services/patient/history/list
        ///         {
        ///               "pageNumber": 20,
        ///               "pageSize": 1,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>Patients History</returns>
        /// <response code = "200">Returns a list of patients history.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("patient/history/list")]
        public IActionResult ListPHistory([FromBody] PaginationFilter filter)
        {
            List<PatientHistoryDTO> response = mService.ListHistory(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any patients history on searched rows or there aren't any.");
        }

        /// <summary>
        /// List patient history for custom patient.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET services/patient/history/list/patient
        ///
        /// </remarks>
        /// <returns>Patient History</returns>
        /// <response code = "200">Returns a list of searched patient history.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("patient/history/list/patient")]
        [AuthFilter]
        public IActionResult HistoryByPatient()
        {
            if (Convert.ToInt32(DataEncryption.Decrypt(Startup.MemberTypeId)) == Convert.ToInt32(MEMBER_TYPE.Customer))
            {
                List<PatientHistoryDTO> patientHistory = mService.HistoryByPatient(Startup.MemberId);

                if (patientHistory != null)
                {
                    return new ObjectResult(patientHistory);
                }

                else return new NotFoundObjectResult("A patient with that id doesn't have any appointment history");
            }
            else return new BadRequestObjectResult("You need to be logged in, or logged as a patient to do this action.");
        }

        #endregion

    }
}