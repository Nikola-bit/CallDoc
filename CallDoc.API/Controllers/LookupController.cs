using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallDoc.API.Filters;
using CallDoc.API.Services;
using CallDoc.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallDoc.API.Controllers
{
    [Route("lookup")]
    [ApiController]
    public class LookupController : ControllerBase
    {

        #region Dependency Injection 

        private ILookupService service { get; set; }
        public LookupController(ILookupService _service)
        {
            service = _service;
        }

        #endregion

        #region PlatformConfiguration

        /// <summary>
        /// Get all appointment statuses.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET lookup/appointment/status
        ///     
        /// </remarks>
        /// <returns>Appoinment Statuses</returns>
        /// <response code = "200">Returns all appointment statuses.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("appointment/status")]
        public IActionResult AppointmentStatus()
        {
            List<PlatformConfigurationDTO> response = service.AppointmentStatuses();

            return new ObjectResult(response);
        }

        /// <summary>
        /// Get all institution statuses.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET lookup/institution/status
        ///     
        /// </remarks>
        /// <returns>Institution Statuses</returns>
        /// <response code = "200">Returns all institution statuses.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("institution/status")]
        public IActionResult InstitutionStatus()
        {
            List<PlatformConfigurationDTO> response = service.InstitutionStatuses();

            return new ObjectResult(response);
        }

        /// <summary>
        /// Get all member types.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET lookup/member/type
        ///     
        /// </remarks>
        /// <returns>Member Type</returns>
        /// <response code = "200">Returns all member types.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("member/type")]
        public IActionResult MemberType()
        {
            List<PlatformConfigurationDTO> response = service.MemberTypes();

            return new ObjectResult(response);
        }

        /// <summary>
        /// Get all member statuses.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET lookup/member/status
        ///     
        /// </remarks>
        /// <returns>Member Statuses</returns>
        /// <response code = "200">Returns all member statuses.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("member/status")]
        public IActionResult MemberStatus()
        {
            List<PlatformConfigurationDTO> response = service.MemberStatuses();

            return new ObjectResult(response);
        }

        /// <summary>
        /// Get all invitation statuses.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET lookup/invitation/status
        ///     
        /// </remarks>
        /// <returns>Invitation Statuses</returns>
        /// <response code = "200">Returns all invitation statuses.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("invitation/status")]
        public IActionResult InvitationStatus()
        {
            List<PlatformConfigurationDTO> response = service.InvitationStatuses();

            return new ObjectResult(response);
        }
        /// <summary>
        /// Get all credit card types.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET lookup/credit/card/type
        ///     
        /// </remarks>
        /// <returns>Credit card types</returns>
        /// <response code = "200">Returns all credit card types.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("credit/card/type")]
        public IActionResult CreditCardType()
        {
            List<PlatformConfigurationDTO> response = service.CreditCardTypes();

            return new ObjectResult(response);
        }
        /// <summary>
        /// Get all payment statuses.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET lookup/payment/status
        ///     
        /// </remarks>
        /// <returns>Payment Statuses</returns>
        /// <response code = "200">Returns all payment statuses.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("payment/status")]
        public IActionResult PaymentStatus()
        {
            List<PlatformConfigurationDTO> response = service.PaymentStatuses();

            return new ObjectResult(response);
        }
        /// <summary>
        /// Get all institution types.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET lookup/institution/type
        ///     
        /// </remarks>
        /// <returns>Institution types</returns>
        /// <response code = "200">Returns all institution types.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("institution/type")]
        public IActionResult InstitutionType()
        {
            List<PlatformConfigurationDTO> response = service.InstitutionTypes();

            return new ObjectResult(response);
        }

        #endregion

        #region DoctorSpecialties

        /// <summary>
        /// Create/Update a DoctorSpecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/doctor/subspecialties/create/update
        ///         {
        ///               "DoctorSubSpecialties": "I14kpXunkSuJIU+8++5v3Q==" (If making update),
        ///               "SubSpecialtyId": "I14kpXunkSuJIU+8++5v3Q=="
        ///               "isActive": true (If making update),
        ///               "DoctorId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>DoctorSpecialty</returns>
        /// <response code = "200">Returns the created/updated Doctorspecialty.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("doctor/subspecialties/create/update")]
        public IActionResult CreateUpdateDoctor([FromBody] DoctorSpecialtiesDTO specialties)
        {
            DoctorSpecialtiesDTO response = null;

            if (specialties.DoctorSubSpecialties1 != null && specialties.DoctorSubSpecialties1 != "string")
            {
                response = service.UpdateDoctorS(specialties);
            }
            else
            {
                response = service.CreateDoctorS(specialties);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }
        /// <summary>
        /// Find single DoctorSpecialty.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET lookup/doctor/subspecialties/single
        ///         {
        ///               "DoctorSubSpecialties": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>DoctorSubSpecialty</returns>
        /// <response code = "200">Returns the searched Doctorsubspecialty.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("doctor/subspecialties/single")]
        public IActionResult SingleDoctorSpecialty([FromQuery] string Id)
        {
            DoctorSpecialtiesDTO response = service.SingleDoctorS(Id);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any doctor sSpecialty with the inserted ID.");
        }
        /// <summary>
        /// Remove a DoctorSpecialty.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/doctor/subspecialties/remove
        ///         {
        ///               "DoctorSubSpecialties1": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>DoctorSpecialty</returns>
        /// <response code = "200">Returns the removed Doctorspecialty.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("doctor/subspecialties/remove")]
        public IActionResult RemoveDoctorSpecialty([FromQuery] string Id)
        {
            DoctorSpecialtiesDTO response = service.DeleteDoctorS(Id);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any doctor specialty with the inserted ID.");
        }
        /// <summary>
        /// List DoctorSpecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/doctor/subspecialties/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>DoctorSpecialty</returns>
        /// <response code = "200">Returns a list of DoctorSpecialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("doctor/subspecialties/list")]
        public IActionResult ListDoctorSpecialties([FromBody] PaginationFilter filter)
        {
            List<DoctorSpecialtiesDTO> response = service.ListDoctorS(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any doctor specialties on searched rows or there aren't any.");
        }

        #endregion

        #region InstitutionSpecialties

        /// <summary>
        /// Create/Update a InstitutionSpecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/specialties/create/update
        ///         {
        ///               "institutionSpecialtiesId": "I14kpXunkSuJIU+8++5v3Q==" (If making update),
        ///               "institutionBranchId": "I14kpXunkSuJIU+8++5v3Q==",
        ///               "specialtyId": "I14kpXunkSuJIU+8++5v3Q==",
        ///               "isActive" : "true"
        ///         }
        /// </remarks>
        /// <returns>InstitutionSpecialties</returns>
        /// <response code = "200">Returns the created/updated institutionSpecialties.</response>
        /// <response code = "400">An error occured.</response>
        [AuthFilter]
        [HttpPost("institution/specialties/create/update")]
        public IActionResult CreateUpdateSpecialties([FromBody] InstitutionSpecialtiesDTO institution)
        {

            InstitutionSpecialtiesDTO response = null;

            if (institution.InstitutionSpecialtiesId != null && institution.InstitutionSpecialtiesId != "string")
            {
                response = service.UpdateS(institution);
            }
            else
            {
                response = service.CreateS(institution);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }
        /// <summary>
        /// Find single institutionSpecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET lookup/institution/specialties/single
        ///         {
        ///               "institutionSpecialtiesId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>InstitutionSpecialties</returns>
        /// <response code = "200">Returns the searched specialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("institution/specialties/single")]
        public IActionResult SingleSpecialties([FromQuery] string Id)
        {
            InstitutionSpecialtiesDTO response = service.SingleS(Id);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any specialties with the inserted ID.");
        }
        /// <summary>
        /// Remove a institutionSpecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/specialties/remove
        ///         {
        ///               "institutionSpecialtiesId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>InstitutionSpecialties</returns>
        /// <response code = "200">Returns the removed specialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("institution/specialties/remove")]
        public IActionResult RemoveSpecialties([FromQuery] string Id)
        {
            InstitutionSpecialtiesDTO response = service.DeleteS(Id);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any specialties with the inserted ID.");
        }
        /// <summary>
        /// List institutionSpecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/specialties/list
        ///         {
        ///               "pageNumber": 20,
        ///               "pageSize": 1,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>InstitutionSpecialties</returns>
        /// <response code = "200">Returns a list of InstitutionSpecialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("institution/specialties/list")]
        public IActionResult ListSpecialties([FromBody] PaginationFilter filter)
        {
            List<InstitutionSpecialtiesDTO> response = service.ListS(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any specialties on searched rows or there aren't any.");
        }

        /// <summary>
        /// Add multiple institution Specialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/specialties/create/multiple
        ///         {
        ///             "institutionBranchId" : "I14kpXunkSuJIU+8++5v3Q==",
        ///             "specialtiesIds": [ {"I14kpXunkSuJIU+8++5v3Q==", "I14kpXunkSuJIU+8++5v3Q=="} ]
        ///         }
        /// </remarks>
        /// <returns>Institution Specialties</returns>
        /// <response code = "200">Returns a list of the added InstitutionSpecialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("institution/specialties/create/multiple")]
        public IActionResult CreateMultipleSpecialties([FromBody] InstitutionSpecialtiesBodyDTO infos)
        {
            List<InstitutionSpecialtiesDTO> response = service.AddMultipleSpecialties(infos.InstitutitonBranchId, infos.SpecialtiesIds);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There was error with the ids or all of the specialties are alreday added to that institution branch");
        }
        /// <summary>
        /// Remove multiple institution Specialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/specialties/remove/multiple
        ///         {
        ///             "institutionBranchId" : "I14kpXunkSuJIU+8++5v3Q==",
        ///             "specialtiesIds": [ {"I14kpXunkSuJIU+8++5v3Q==", "I14kpXunkSuJIU+8++5v3Q=="} ]
        ///         }
        /// </remarks>
        /// <returns>Institution Specialties</returns>
        /// <response code = "200">Returns a list of the removed InstitutionSpecialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("institution/specialties/remove/multiple")]
        public IActionResult RemoveMultipleSpecialties([FromBody] InstitutionSpecialtiesBodyDTO infos)
        {
            List<InstitutionSpecialtiesDTO> response = service.RemoveMultipleSpecialties(infos.InstitutitonBranchId, infos.SpecialtiesIds);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There was error with the ids or those branch doesn't have any of those specialties");
        }

        #endregion

        #region InstitutionSubSpecialties

        /// <summary>
        /// Create/Update a Institution SubSpecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/subspecialties/create/update
        ///         {
        ///               "institutionSubSpecialtiesId": "I14kpXunkSuJIU+8++5v3Q==" (If making update),
        ///               "institutionBranchId": "I14kpXunkSuJIU+8++5v3Q==",
        ///               "subSubSpecialtyId": "I14kpXunkSuJIU+8++5v3Q==",
        ///               "isActive" : "true"
        ///         }
        /// </remarks>
        /// <returns>InstitutionSubSpecialties</returns>
        /// <response code = "200">Returns the created/updated institutionSubSpecialties.</response>
        /// <response code = "400">An error occured.</response>
        [AuthFilter]
        [HttpPost("institution/subspecialties/create/update")]
        public IActionResult CreateUpdateSubSpecialties([FromBody] InstitutionSubSpecialtiesDTO institution)
        {

            InstitutionSubSpecialtiesDTO response = null;

            if (institution.InstitutionSubSpecialtiesId != null && institution.InstitutionSubSpecialtiesId != "string")
            {
                response = service.UpdateSubSpecialty(institution);
            }
            else
            {
                response = service.CreateSubSpecialty(institution);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }
        /// <summary>
        /// Find single institutionSubSpecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET lookup/institution/subspecialties/single
        ///         {
        ///               "institutionSubSpecialtiesId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>InstitutionSubSpecialties</returns>
        /// <response code = "200">Returns the searched subspecialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("institution/subspecialties/single")]
        public IActionResult SingleSubSpecialties([FromQuery] string Id)
        {
            InstitutionSubSpecialtiesDTO response = service.SingleSubSpecialty(Id);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any subSpecialties with the inserted ID.");
        }
        /// <summary>
        /// Remove a institutionSubSpecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/subspecialties/remove
        ///         {
        ///               "institutionSubSpecialtiesId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>InstitutionSubSpecialties</returns>
        /// <response code = "200">Returns the removed subspecialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("institution/subspecialties/remove")]
        public IActionResult RemoveSubSpecialties([FromQuery] string Id)
        {
            InstitutionSubSpecialtiesDTO response = service.DeleteSubSpecialty(Id);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any subspecialties with the inserted ID.");
        }
        /// <summary>
        /// List institutionSubSpecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/subspecialties/list
        ///         {
        ///               "pageNumber": 20,
        ///               "pageSize": 1,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>InstitutionSubSpecialties</returns>
        /// <response code = "200">Returns a list of InstitutionSubSpecialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("institution/subspecialties/list")]
        public IActionResult ListSubSpecialties([FromBody] PaginationFilter filter)
        {
            List<InstitutionSubSpecialtiesDTO> response = service.ListSubSpecialties(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any subspecialties on searched rows or there aren't any.");
        }

        /// <summary>
        /// Add multiple institution SubSpecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/subspecialties/create/multiple
        ///         {
        ///             "institutionBranchId" : "I14kpXunkSuJIU+8++5v3Q==",
        ///             "subspecialtiesIds": [ {"I14kpXunkSuJIU+8++5v3Q==", "I14kpXunkSuJIU+8++5v3Q=="} ]
        ///         }
        /// </remarks>
        /// <returns>Institution SubSpecialties</returns>
        /// <response code = "200">Returns a list of the added InstitutionSubSpecialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("institution/subspecialties/create/multiple")]
        public IActionResult CreateMultipleSubSpecialties([FromBody] InstitutionSubSpecialtiesBodyDTO infos)
        {
            List<InstitutionSubSpecialtiesDTO> response = service.AddMultipleSubSpecialties(infos.InstitutitonBranchId, infos.SubSpecialtiesIds);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There was error with the ids or all of the subspecialties are alreday added to that institution branch");
        }
        /// <summary>
        /// Remove multiple institution SubSpecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/subspecialties/remove/multiple
        ///         {
        ///             "institutionBranchId" : "I14kpXunkSuJIU+8++5v3Q==",
        ///             "subspecialtiesIds": [ {"I14kpXunkSuJIU+8++5v3Q==", "I14kpXunkSuJIU+8++5v3Q=="} ]
        ///         }
        /// </remarks>
        /// <returns>Institution SubSpecialties</returns>
        /// <response code = "200">Returns a list of the removed InstitutionSubSpecialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("institution/subspecialties/remove/multiple")]
        public IActionResult RemoveMultipleSubSpecialties([FromBody] InstitutionSubSpecialtiesBodyDTO infos)
        {
            List<InstitutionSubSpecialtiesDTO> response = service.RemoveMultipleSubSpecialties(infos.InstitutitonBranchId, infos.SubSpecialtiesIds);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There was error with the ids or those branch doesn't have any of those subspecialties");
        }

        #endregion

        #region InstitutionServices

        /// <summary>
        /// Create/Update a InstitutionServices.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/services/create/update
        ///         {
        ///               "institutionServicesId": "I14kpXunkSuJIU+8++5v3Q==" (If making update),
        ///               "institutionBranchId": "I14kpXunkSuJIU+8++5v3Q==",
        ///               "serviceId": "I14kpXunkSuJIU+8++5v3Q==",
        ///               "isActive" : "true"
        ///         }
        /// </remarks>
        /// <returns>InstitutionServices</returns>
        /// <response code = "200">Returns the created/updated institutionServices.</response>
        /// <response code = "400">An error occured.</response>
        [AuthFilter]
        [HttpPost("institution/services/create/update")]
        public IActionResult CreateUpdateServices([FromBody] InstitutionServicesDTO institution)
        {

            InstitutionServicesDTO response = null;

            if (institution.InstitutionServicesId != null && institution.InstitutionServicesId != "string")
            {
                response = service.UpdateService(institution);
            }
            else
            {
                response = service.CreateService(institution);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }
        /// <summary>
        /// Find single institutionServices.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET lookup/institution/services/single
        ///         {
        ///               "institutionServicesId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>InstitutionServices</returns>
        /// <response code = "200">Returns the searched services.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("institution/services/single")]
        public IActionResult SingleServices([FromQuery] string Id)
        {
            InstitutionServicesDTO response = service.SingleService(Id);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any services with the inserted ID.");
        }
        /// <summary>
        /// Remove a institutionServices.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/services/remove
        ///         {
        ///               "institutionServicesId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>InstitutionServices</returns>
        /// <response code = "200">Returns the removed services.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("institution/services/remove")]
        public IActionResult RemoveServices([FromQuery] string Id)
        {
            InstitutionServicesDTO response = service.DeleteService(Id);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any services with the inserted ID.");
        }
        /// <summary>
        /// List institutionServices.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/services/list
        ///         {
        ///               "pageNumber": 20,
        ///               "pageSize": 1,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>InstitutionServices</returns>
        /// <response code = "200">Returns a list of InstitutionServices.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("institution/services/list")]
        public IActionResult ListServices([FromBody] PaginationFilter filter)
        {
            List<InstitutionServicesDTO> response = service.ListServices(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any services on searched rows or there aren't any.");
        }

        /// <summary>
        /// Add multiple institution Services.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/services/create/multiple
        ///         {
        ///             "institutionBranchId" : "I14kpXunkSuJIU+8++5v3Q==",
        ///             "services": [ {
        ///                 "institutionDoctorId" : "I14kpXunkSuJIU+8++5v3Q==",
        ///                 "platformServiceId" : "I14kpXunkSuJIU+8++5v3Q=="
        ///             },
        ///             {
        ///                 "institutionDoctorId" : "I14kpXunkSuJIU+8++5v3Q==",
        ///                 "platformServiceId" : "I14kpXunkSuJIU+8++5v3Q=="
        ///             } ]
        ///         }
        /// </remarks>
        /// <returns>Institution Services</returns>
        /// <response code = "200">Returns a list of the added InstitutionServices.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("institution/services/create/multiple")]
        public IActionResult CreateMultipleServices([FromBody] InstitutionServicesBodyDTO infos)
        {
            List<InstitutionServicesDTO> response = service.AddMultipleServices(infos.InstitutitonBranchId, infos.Services);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There was error with the ids or all of the services are alreday added to that institution branch");
        }
        /// <summary>
        /// Remove multiple institution Services.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST lookup/institution/services/remove/multiple
        ///         {
        ///             "institutionBranchId" : "I14kpXunkSuJIU+8++5v3Q==",
        ///             "services": [ {
        ///                 "institutionDoctorId" : "I14kpXunkSuJIU+8++5v3Q==",
        ///                 "platformServiceId" : "I14kpXunkSuJIU+8++5v3Q=="
        ///             },
        ///             {
        ///                 "institutionDoctorId" : "I14kpXunkSuJIU+8++5v3Q==",
        ///                 "platformServiceId" : "I14kpXunkSuJIU+8++5v3Q=="
        ///             } ]
        ///         }
        /// </remarks>
        /// <returns>Institution Services</returns>
        /// <response code = "200">Returns a list of the removed InstitutionServices.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("institution/services/remove/multiple")]
        public IActionResult RemoveMultipleServices([FromBody] InstitutionServicesBodyDTO infos)
        {
            List<InstitutionServicesDTO> response = service.RemoveMultipleServices(infos.InstitutitonBranchId, infos.Services);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There was error with the ids or those branch doesn't have any of those services");
        }

        #endregion

        [HttpPost("test")]
        public IActionResult Test([FromBody] TestDTO test)
        {

            return new ObjectResult(true);
        }
    }
}
