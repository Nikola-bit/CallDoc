using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallDoc.API.Filters;
using CallDoc.API.Services;
using CallDoc.DTO;
using CallDoc.DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallDoc.API.Controllers
{
    [Route("institution")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private IInstitutionService service { get; set; }
        public InstitutionController(IInstitutionService _service)
        {
            service = _service;
        }

        #region Institution

        /// <summary>
        /// Create/Update an institution.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/create/update
        ///         {
        ///             "name": "Paramedic Hospital",
        ///             "logo": "https://i.imgur.com/FApqk3D.jpg",
        ///             "typeId": "AWITwbEO4CpyPIjTCuwo7w==",
        ///             "institutionId": "J+XGDuQUCVmqW6xWEd4pRw==",
        ///             "statusId": "FnV9//ikc71XLppgH6p0nw=="
        ///         }
        /// </remarks>
        /// <returns>Institution</returns>
        /// <response code = "200">Returns the created/updated institution.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("create/update")]
        public IActionResult CreateUpdateInstitution([FromBody] InstitutionUpdateDTO institution)
        {
            InstitutionDTO response = null;

            if (institution.InstitutionId != null && institution.InstitutionId != "string")
            {
                response = service.UpdateInstitution(institution);
            }
            else
            {
                response = service.CreateInstitution(institution);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }

        /// <summary>
        /// Find single institution.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET institution/single
        ///         {
        ///               "institutionId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Institution</returns>
        /// <response code = "200">Returns the searched institution.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("single")]
        public IActionResult SingleInstitution([FromQuery] string institutionId)
        {
            InstitutionDTO response = service.SingleInstitution(institutionId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any institution with the inserted ID.");
        }

        /// <summary>
        /// Remove an institution.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/remove
        ///         {
        ///               "institutionId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Institution</returns>
        /// <response code = "200">Returns the removed institution.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("remove")]
        public IActionResult RemoveInstitution([FromQuery] string institutionId)
        {
            InstitutionDTO response = service.DeleteInstitution(institutionId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any institution with the inserted ID.");
        }
        /// <summary>
        /// List institutions.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>Institutions</returns>
        /// <response code = "200">Returns a list of institutions.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("list")]
        public IActionResult ListInstitutiones([FromBody] PaginationFilter filter)
        {
            List<InstitutionDTO> response = service.ListInstitutions(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any institutions on searched rows or there aren't any.");
        }
        /// <summary>
        /// List institution by typeId.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET institution/list/by/ype
        ///         {
        ///               "typeId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Institution</returns>
        /// <response code = "200">Returns a list of institutions.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("list/by/type")]
        public IActionResult InstitutionByType([FromQuery] string typeId)
        {
            List<InstitutionDTO> institutionDTOs = service.ListByTypeid(typeId);

            if (institutionDTOs != null)
            {
                return new ObjectResult(institutionDTOs);
            }

            else return new NotFoundObjectResult("A institution with that typeId is not existing.");
        }
        /// <summary>
        /// List institution by statusId.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET institution/list/by/status
        ///         {
        ///               "statusId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Institution</returns>
        /// <response code = "200">Returns a list of institutions.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("list/by/status")]
        public IActionResult InstitutionByStatus([FromQuery] string statusId)
        {
            List<InstitutionDTO> institutionDTOs = service.ListByStatusid(statusId);

            if (institutionDTOs != null)
            {
                return new ObjectResult(institutionDTOs);
            }

            else return new NotFoundObjectResult("A institution with that statusId is not existing.");
        }

        #endregion

        #region Platform PlatformSpecialty

        /// <summary>
        /// Create/Update a specialty.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/platform/specialty/create/update
        ///         {
        ///               "specialtyId": "I14kpXunkSuJIU+8++5v3Q==" (If making update),
        ///               "IsActive": true (If making update),
        ///               "Name": "Cardiography"
        ///         }
        /// </remarks>
        /// <returns>PlatformSpecialty</returns>
        /// <response code = "200">Returns the created/updated specialty.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("platform/specialty/create/update")]
        public IActionResult CreateUpdatePlatformSpecialty([FromBody] PlatformSpecialtyUpdateDTO specialty)
        {
            PlatformSpecialtyDTO response = null;

            if (specialty.SpecialtyId != null && specialty.SpecialtyId != "string")
            {
                response = service.UpdatePlatformSpecialty(specialty);
            }
            else
            {
                response = service.CreatePlatformSpecialty(specialty);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }

        /// <summary>
        /// Find single specialty.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET institution/platform/specialty/single
        ///         {
        ///               "specialtyId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>PlatformSpecialty</returns>
        /// <response code = "200">Returns the searched specialty.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("platform/specialty/single")]
        public IActionResult SingleAddress([FromQuery] string specialtyId)
        {
            PlatformSpecialtyDTO response = service.SinglePlatformSpecialty(specialtyId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any specialty with the inserted ID.");
        }

        /// <summary>
        /// Remove a specialty.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/platform/specialty/remove
        ///         {
        ///               "specialtyId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>PlatformSpecialty</returns>
        /// <response code = "200">Returns the removed specialty.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("platform/specialty/remove")]
        public IActionResult RemovePlatformSpecialty([FromQuery] string specialtyId)
        {
            PlatformSpecialtyDTO response = service.DeletePlatformSpecialty(specialtyId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any specialty with the inserted ID.");
        }
        /// <summary>
        /// List specialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/platform/specialty/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>PlatformSpecialty</returns>
        /// <response code = "200">Returns a list of specialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("platform/specialty/list")]
        public IActionResult ListPlatformSpecialty([FromBody] PaginationFilter filter)
        {
            List<PlatformSpecialtyDTO> response = service.ListSpecialties(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any specalties on searched rows or there aren't any.");
        }
        #endregion

        #region PlatformSubSpecialty

        /// <summary>
        /// Create/Update a subspecialty/.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/platform/subspecialty/create/update
        ///         {
        ///               "subSpecialtyId": "I14kpXunkSuJIU+8++5v3Q==" (If making update),
        ///               "isActive": true (If making update),
        ///               "name": "Cardiography",
        ///               "specialtyId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>PlatformSubSpecialty</returns>
        /// <response code = "200">Returns the created/updated subspecialty/.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("platform/subspecialty/create/update")]
        public IActionResult CreateUpdatePlatformSubSpecialty([FromBody] PlatformSubSpecialtyUpdateDTO subSpecialty)
        {
            PlatformSubSpecialtyDTO response = null;

            if (subSpecialty.SubSpecialtyId != null && subSpecialty.SubSpecialtyId != "string")
            {
                response = service.UpdatePlatformSubSpecialty(subSpecialty);
            }
            else
            {
                response = service.CreatePlatformSubSpecialty(subSpecialty);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }

        /// <summary>
        /// Find single subspecialty/.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET institution/platform/subspecialty/single
        ///         {
        ///               "subSpecialtyId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>PlatformSubSpecialty</returns>
        /// <response code = "200">Returns the searched subspecialty/.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("platform/subspecialty/single")]
        public IActionResult SinglePlatformSubSpecialty([FromQuery] string subSpecialtyId)
        {
            PlatformSubSpecialtyDTO response = service.SinglePlatformSubSpecialty(subSpecialtyId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any subspecialty/ with the inserted ID.");
        }

        /// <summary>
        /// Remove a subspecialty/.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/platform/subspecialty/remove
        ///         {
        ///               "subSpecialtyId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>PlatformSubSpecialty</returns>
        /// <response code = "200">Returns the removed subspecialty/.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("platform/subspecialty/remove")]
        public IActionResult RemovePlatformSubSpecialty([FromQuery] string subSpecialtyId)
        {
            PlatformSubSpecialtyDTO response = service.DeletePlatformSubSpecialty(subSpecialtyId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any subspecialty/ with the inserted ID.");
        }
        /// <summary>
        /// List subspecialties.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/platform/subspecialty/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>PlatformSubSpecialty</returns>
        /// <response code = "200">Returns a list of subspecialties.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("platform/subspecialty/list")]
        public IActionResult ListSubSpecialties([FromBody] PaginationFilter filter)
        {
            List<PlatformSubSpecialtyDTO> response = service.ListSubSpecialties(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any subspecialties on searched rows or there aren't any.");
        }
        /// <summary>
        /// List subSpecialty by specialtyId.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST platform/subspecialty/list/specialty
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES),
        ///               "specialtyId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>SubSpecialty</returns>
        /// <response code = "200">Returns a list of subSpecialties under one Specialty.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("platform/subspecialty/list/specialty")]
        public IActionResult ListSubSpecialtiesUnderSpecialty([FromBody] UnderSpecialtyPaginationFilter filter)
        {
            List<PlatformSubSpecialtyDTO> subs = service.ListSubSpecialtiesUnderSpecialty(filter);

            if (subs != null)
            {
                return new ObjectResult(subs);
            }

            else return new NotFoundObjectResult("A subSpecialties under that specialtyId is not existing.");
        }

        #endregion

        #region PlatformService

        /// <summary>
        /// Create/Update a service.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/platform/service/create/update
        ///         {
        ///               "PlatformServiceId": "I14kpXunkSuJIU+8++5v3Q==" (if making update),
        ///               "subSpecialtyId": "I14kpXunkSuJIU+8++5v3Q==" ,
        ///               "SpecialtyId": "I14kpXunkSuJIU+8++5v3Q==",
        ///               "isActive": true (If making update),
        ///               "name": "Cardiography"
        ///         }
        /// </remarks>
        /// <returns>PlatformService</returns>
        /// <response code = "200">Returns the created/updated service/.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("platform/service/create/update")]
        public IActionResult CreateUpdatePlatformService([FromBody] PlatformServiceUpdateDTO servicee)
        {
            PlatformServiceUpdateDTO response = null;

            if (servicee.PlatformServiceId != null && servicee.PlatformServiceId != "string")
            {
                response = service.UpdatePlatformService(servicee);
            }
            else
            {
                response = service.CreatePlatformService(servicee);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }

        /// <summary>
        /// Find single service/.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET institution/platform/service/single
        ///         {
        ///               "PlatformServiceId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>PlatformService</returns>
        /// <response code = "200">Returns the searched service/.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("platform/service/single")]
        public IActionResult SinglePlatformService([FromQuery] string pServiceId)
        {
            PlatformServiceDTO response = service.SinglePlatformService(pServiceId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any service with the inserted ID.");
        }

        /// <summary>
        /// Remove a service/.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/platform/service/remove
        ///         {
        ///               "PlatformServiceId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>PlatformService</returns>
        /// <response code = "200">Returns the removed service/.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("platform/service/remove")]
        public IActionResult RemovePlatformService([FromQuery] string pServiceId)
        {
            PlatformServiceDTO response = service.DeletePlatformService(pServiceId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any service with the inserted ID.");
        }
        /// <summary>
        /// List services.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/platform/service/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>PlatformService</returns>
        /// <response code = "200">Returns a list of services.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("platform/service/list")]
        public IActionResult ListServices([FromBody] PaginationFilter filter)
        {
            List<PlatformServiceDTO> response = service.ListServices(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any services on searched rows or there aren't any.");
        }
        /// <summary>
        /// List service by subSpecialtyId or/and specialty.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/platform/service/list/specialty/subspecialty
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES),
        ///               "specialtyId": "I14kpXunkSuJIU+8++5v3Q==",
        ///               "subSpecialtyId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Service</returns>
        /// <response code = "200">Returns a list of services under that Specialty and/or subspecialty.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("platform/service/list/specialty/subspecialty")]
        public IActionResult ListServicesUnderSpecialtySubSpecialty([FromBody] UnderSpecialtySubSpecialtyPaginationFilter filter)
        {
            List<PlatformServiceDTO> ser = service.ListServicesUnderSpecialtySubSpecialty(filter);

            if (ser != null)
            {
                return new ObjectResult(ser);
            }

            else return new NotFoundObjectResult("A service under that specialtyId is not existing.");
        }

        #endregion

        #region InstitutionBranch

        /// <summary>
        /// Create/Update institution branch.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/branch/create/update
        ///         {
        ///               "name": "Sistina Veles",
        ///               "addressId": "I14kpXunkSuJIU+8++5v3Q==",
        ///               "biography": "It is a private hospital with the most professional doctors in the city.",
        ///               "PhoneNumber": "043/224-426",
        ///               "contactEmail" : "sistina@mail.com",
        ///               "website": "sistina.com/veles",
        ///               "logo": "www.imgur.com/rgDsafS.png",
        ///               "institutionBranchId": "I14kpXunkSuJIU+8++5v3Q==" (If making update)
        ///         }
        /// </remarks>
        /// <returns>InstitutionBranch</returns>
        /// <response code = "200">Returns the created/updated institutionBranch.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("branch/create/update")]
        public IActionResult CreateUpdateBranch([FromBody] InstitutionBranchDTO institution)
        {
            InstitutionBranchDTO response = null;

            if (institution.InstitutionBranchId != null && institution.InstitutionBranchId != "string")
            {
                response = service.UpdateBranch(institution);
            }
            else
            {
                response = service.Create(institution);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }
        /// <summary>
        /// Find single institutionBranch.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET institution/branch/single
        ///         {
        ///               "institutionBranchId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>InstitutionBranch</returns>
        /// <response code = "200">Returns the searched branch.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("branch/single")]
        public IActionResult SingleBranch([FromQuery] string branchId)
        {
            InstitutionBranchDTO response = service.SingleBranch(branchId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any branch with the inserted ID.");
        }
        /// <summary>
        /// Remove a institutionBranch.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/branch/remove
        ///         {
        ///               "institutionBranchId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Institutionbranch</returns>
        /// <response code = "200">Returns the removed branch.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("branch/remove")]
        public IActionResult RemoveBranch([FromQuery] string branchId)
        {
            InstitutionBranchDTO response = service.DeleteBranch(branchId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any branch with the inserted ID.");
        }
        /// <summary>
        /// List institutionBranch.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST institution/branch/list
        ///         {
        ///               "pageNumber": 20,
        ///               "pageSize": 1,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>InstitutionBranch</returns>
        /// <response code = "200">Returns a list of InstitutionBranch.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("branch/list")]
        public IActionResult ListBranch([FromBody] PaginationFilter filter)
        {
            List<InstitutionBranchDTO> response = service.ListBranch(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any branch on searched rows or there aren't any.");
        }

        #endregion

    }
}
