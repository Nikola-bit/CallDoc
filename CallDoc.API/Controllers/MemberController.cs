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
    [Route("member")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        #region Dependency Injection

        private IMemberService service { get; set; }
        public MemberController(IMemberService _service)
        {
            service = _service;
        }

        #endregion

        #region Member

        /// <summary>
        /// Login a member.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST member/login
        ///         {
        ///              "email": "john.p@yahoo.com",
        ///              "password": "********"
        ///         }
        /// </remarks>
        /// <returns>Member</returns>
        /// <response code = "200">Returns the logged member with token.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("login")]
        public IActionResult LoginMember([FromBody] MemberLoginDTO member)
        {
            MemberTokenDTO memberToken = service.LoginMember(member);


            if (memberToken != null)
            {
                if (memberToken.Token != null)
                {
                    return new ObjectResult(memberToken);
                }

                else if (memberToken.Member.MemberStatusId == DataEncryption.Encrypt(Convert.ToString(MEMBER_STATUS.Inactive)))
                    return new BadRequestObjectResult("Your account is inactive, activate it first.");
                else if (memberToken.Member.MemberStatusId == DataEncryption.Encrypt(Convert.ToString(MEMBER_STATUS.Pending)))
                    return new BadRequestObjectResult("Your account is not activated, go and activate it.");
                else return new BadRequestObjectResult("Your account is suspended.");
            }

            else return new BadRequestObjectResult("Wrong credentials.");
        }
        /// <summary>
        /// Create/Update a member.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST member/create/update
        ///         {
        ///              "email": "john.p@yahoo.com",
        ///              "password": "********",
        ///              "memberTypeId": "IXw7wb/9hehgfBb8RuqUOw==",
        ///              "memberId": "IXw7wb/9hehgfBb8RuqUOw==", (If making update)
        ///              "memberStatusId": "IXw7wb/9hehgfBb8RuqUOw==" (If making update)
        ///         }
        /// </remarks>
        /// <returns>Member</returns>
        /// <response code = "200">Returns the created/updated member.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("create/update")]
        public IActionResult CreateUpdateMember([FromBody] MemberUpdateDTO member)
        {
            MemberDTO response = null;

            if (member.MemberId != null && member.MemberId != "string")
            {
                response = service.UpdateMember(member);
            }
            else
            {
                response = service.CreateMember(member);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations.");
        }

        /// <summary>
        /// Find single member.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET member/single
        ///         {
        ///               "memberId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Member</returns>
        /// <response code = "200">Returns the searched member.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("single")]
        public IActionResult SingleMember([FromQuery] string memberId)
        {
            MemberDTO response = service.SingleMember(memberId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any member with the inserted ID.");
        }

        /// <summary>
        /// Remove a member.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST member/remove
        ///         {
        ///               "memberId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Member</returns>
        /// <response code = "200">Returns the removed member.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("remove")]
        public IActionResult RemoveMember([FromQuery] string memberId)
        {
            MemberDTO response = service.DeleteMember(memberId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any member with the inserted ID.");
        }
        /// <summary>
        /// List members.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST member/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>Members</returns>
        /// <response code = "200">Returns a list of members.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("list")]
        public IActionResult ListMemberes([FromBody] PaginationFilter filter)
        {
            List<MemberDTO> response = service.ListMembers(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any members on searched rows or there aren't any.");
        }
        /// <summary>
        /// List members by status.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET member/list/by/status
        ///         {
        ///               "statusId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Members</returns>
        /// <response code = "200">Returns a list of members.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("list/by/status")]
        public IActionResult MembersByStatus([FromQuery] string statusId)
        {
            List<MemberDTO> response = service.MembersByStatus(statusId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any members with that status.");
        }
        /// <summary>
        /// List members by type.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET member/list/by/type
        ///         {
        ///               "typeId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Members</returns>
        /// <response code = "200">Returns a list of members.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("list/by/type")]
        public IActionResult MembersByType([FromQuery] string typeId)
        {
            List<MemberDTO> response = service.MembersByType(typeId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any members of that type.");
        }

        #endregion

        #region MemberDetails

        /// <summary>
        /// Create/Update a member details.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST member/details/create/update
        ///         {
        ///             "memberId": "J+XGDuQUCVmqW6xWEd4pRw==",
        ///             "firstName": "John",
        ///             "lastName": "Smith",
        ///             "profilePicture": "www.imgur.com/frfSFdv.jpg",
        ///             "about": "Empty",
        ///             "embg": 1903002480012
        ///             "dateOfBirth": "2002-03-19",
        ///             "addressId": "string",
        ///             "phoneNumber": "+38972562174",
        ///             "gender": "Male",
        ///         }
        /// </remarks>
        /// <returns>Member Details</returns>
        /// <response code = "200">Returns the created/updated member details.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("details/create/update")]
        public IActionResult CreateUpdateMemberDetails([FromBody] MemberDetailsCreateDTO details)
        {
            MemberDetailsDTO response = null;

            response = service.CreateUpdateMemberDetails(details);

            if (response != null) return new ObjectResult(response);

            else return new BadRequestObjectResult("You missed some informations or there is not any created active/inactive member with that Id.");
        }

        /// <summary>
        /// Find single member details.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET member/details/single
        ///         {
        ///               "memberId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Member Details</returns>
        /// <response code = "200">Returns the searched member details.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("details/single")]
        public IActionResult SingleMemberDetails([FromQuery] string memberId)
        {
            MemberDetailsDTO response = service.SingleMemberDetails(memberId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any members or details with the inserted ID.");
        }

        /// <summary>
        /// Remove a member details.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST member/details/remove
        ///         {
        ///               "memberId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Member Details</returns>
        /// <response code = "200">Returns the removed member details.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("details/remove")]
        public IActionResult RemoveMemberDetails([FromQuery] string memberId)
        {
            MemberDetailsDTO response = service.DeleteMemberDetails(memberId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any members or details with the inserted ID.");
        }
        /// <summary>
        /// List member details.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST member/details/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>Members Details</returns>
        /// <response code = "200">Returns a list of member details.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("details/list")]
        public IActionResult ListMemberDetailses([FromBody] PaginationFilter filter)
        {
            List<MemberDetailsDTO> response = service.ListMembersDetails(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any members details on searched rows or there aren't any.");
        }

        #endregion

        #region MemberInvitation

        /// <summary>
        /// Create/Update a member invitation.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST member/invitation/create/update
        ///         {
        ///            "memberId": "J+XGDuQUCVmqW6xWEd4pRw==",
        ///            "firstName": "John",
        ///            "lastName": "Smith",
        ///            "phone": "+38972450234",
        ///            "invitationCode": "AS22KJ", (If making new invitation)
        ///            "memberInvitationId": "J+XGDuQUCVmqW6xWEd4pRw==", (If making update)
        ///            "statusId": "XdXyDuQpIwWrZ8Slxd/JeA==" (If making update)
        ///        }
        /// </remarks>
        /// <returns>Member Invitation</returns>
        /// <response code = "200">Returns the created/updated member invitation.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("invitation/create/update")]
        public IActionResult CreateUpdateMemberInvitation([FromBody] MemberInvitationUpdateDTO memberInvitation)
        {
            MemberInvitationDTO response = null;

            if (memberInvitation.MemberInvitationId != null && memberInvitation.MemberInvitationId != "string")
            {
                response = service.UpdateMemberInvitation(memberInvitation);
            }
            else
            {
                response = service.CreateMemberInvitation(memberInvitation);
            }
            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new BadRequestObjectResult("You missed some of the needed informations or there is not any member with that Id.");
        }

        /// <summary>
        /// Find single member invitation.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET member/invitation/single
        ///         {
        ///               "memberInvitationId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Member Invitation</returns>
        /// <response code = "200">Returns the searched member invitation.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("invitation/single")]
        public IActionResult SingleMemberInvitation([FromQuery] string memberInvitationId)
        {
            MemberInvitationDTO response = service.SingleMemberInvitation(memberInvitationId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any memberInvitation with the inserted ID.");
        }

        /// <summary>
        /// Remove a member invitation.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST member/invitation/remove
        ///         {
        ///               "memberInvitationId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Member Invitation</returns>
        /// <response code = "200">Returns the removed member invitation.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("invitation/remove")]
        public IActionResult RemoveMemberInvitation([FromQuery] string memberInvitationId)
        {
            MemberInvitationDTO response = service.DeleteMemberInvitation(memberInvitationId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There is not any memberInvitation with the inserted ID.");
        }
        /// <summary>
        /// List member invitations.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST member/invitation/list
        ///         {
        ///               "pageNumber": 1,
        ///               "pageSize": 20,
        ///               "sortColumn": "string" (Not available yet),
        ///               "sortDirection": "ASC" (ASC or DES)
        ///         }
        /// </remarks>
        /// <returns>Member Invitations</returns>
        /// <response code = "200">Returns a list of member invitations.</response>
        /// <response code = "400">An error occured.</response>
        [HttpPost("invitation/list")]
        public IActionResult ListMemberInvitations([FromBody] PaginationFilter filter)
        {
            List<MemberInvitationDTO> response = service.ListMemberInvitations(filter);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any memberInvitations on searched rows or there aren't any.");
        }
        /// <summary>
        /// List member invitations by status.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET member/invitation/list/by/status
        ///         {
        ///               "statusId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Member Invitations</returns>
        /// <response code = "200">Returns a list of member invitations.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("invitation/list/by/status")]
        public IActionResult MemberInvitationsByStatus([FromQuery] string statusId)
        {
            List<MemberInvitationDTO> response = service.MemberInvitationsByStatus(statusId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any member invitations with that status.");
        }
        /// <summary>
        /// List member invitations by member.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET member/invitation/list/by/member
        ///         {
        ///               "memberId": "I14kpXunkSuJIU+8++5v3Q=="
        ///         }
        /// </remarks>
        /// <returns>Member Invitations</returns>
        /// <response code = "200">Returns a list of member invitations.</response>
        /// <response code = "400">An error occured.</response>
        [HttpGet("invitation/list/by/member")]
        public IActionResult MemberInvitationsByMember([FromQuery] string memberId)
        {
            List<MemberInvitationDTO> response = service.MemberInvitationsByMember(memberId);

            if (response != null)
            {
                return new ObjectResult(response);
            }

            else return new NotFoundObjectResult("There aren't any member invitations from that member.");
        }

        #endregion

    }
}
