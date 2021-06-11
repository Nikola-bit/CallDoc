using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallDoc.API.Services;
using CallDoc.DTO;
using CallDoc.DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallDoc.API.Controllers
{
    [Route("doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorService service { get; set; }
        public DoctorController(IDoctorService _service)
        {
            service = _service;
        }

        #region Service

        /// <summary>
        /// Create/Update a doctor service.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST doctor/service/create/update
        ///         {
        ///             "serviceId": "FnV9//ikc71XLppgH6p0nw==" (If making update),
        ///             "isActive" : true (If making update),
        ///             "doctorId": "FnV9//ikc71XLppgH6p0nw==",
        ///             "description": "I am free to talk to everyone who have a mental health problems.",
        ///             "title": "Mental health talking",
        ///             "price": "15"
        ///         }
        /// </remarks>
        /// <returns>Service</returns>
        /// <response code = "200">Returns the created/updated doctor service.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("service/create/update")]
        public IActionResult CreateUpdateService([FromBody] ServiceUpdateDTO doctorService)
        {
            ServiceDTO response = null;

            if (doctorService.ServiceId != null && doctorService.ServiceId != "string")
            {
                response = service.UpdateService(doctorService);
            }
            else
            {
                response = service.CreateService(doctorService);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }

        /// <summary>
        /// Find single doctor service.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET doctor/service/single
        ///         {
        ///               "serviceId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Service</returns>
        /// <response code = "200">Returns the searched doctor service.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("service/single")]
        public IActionResult SingleService([FromQuery] string serviceId)
        {
            ServiceDTO response = service.SingleService(serviceId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any doctor service with the inserted ID.");
        }

        /// <summary>
        /// Remove a doctor service.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST doctor/service/remove
        ///         {
        ///               "serviceId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Service</returns>
        /// <response code = "200">Returns the removed doctor service.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("service/remove")]
        public IActionResult RemoveService([FromQuery] string serviceId)
        {
            ServiceDTO response = service.DeleteService(serviceId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any doctor service with the inserted ID.");
        }

        /// <summary>
        /// List doctor services.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST doctor/service/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>Services</returns>
        /// <response code = "200">Returns a list of doctor services.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("service/list")]
        public IActionResult ListServices([FromBody] PaginationFilter filter)
        {
            List<ServiceDTO> response = service.ListServices(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any doctor services on searched rows or there aren't any.");
        }
        /// <summary>
        /// List Service by doctorId.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET service/list/by/doctor
        ///         {
        ///               "doctorId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Service</returns>
        /// <response code = "200">Returns a list of Services.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("service/list/by/doctor")]
        public IActionResult ByDoctorId([FromQuery] string Id)
        {
            List<ServiceDTO> services = service.ListByDoctorId(Id);

            if (services != null)
            {
                return new ObjectResult(services);
            }

            else return new NotFoundObjectResult("A services with that doctor Id is not existing.");
        }

        #endregion

    }
}
