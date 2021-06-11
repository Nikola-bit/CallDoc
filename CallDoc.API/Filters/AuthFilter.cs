using CallDoc.API.Models;
using CallDoc.API.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CallDoc.API.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var headers = context.HttpContext.Request.Headers;
            string token = headers["Authorization"];

            if (String.IsNullOrEmpty(token))
            {
                context.Result = new BadRequestObjectResult(new { message = "Bad request: Missing Token.", statusCode = HttpStatusCode.BadRequest });
                return;
            }

            #region Validate Token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var jwtoken = token.Replace("Bearer ", string.Empty);
            JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(jwtoken);
            if (jwtToken == null)
            {
                context.Result = new BadRequestObjectResult(new { message = "Wrong request", statusCode = HttpStatusCode.BadRequest });
                return;
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Startup.TokenKey));
            TokenValidationParameters parameters = new TokenValidationParameters()
            {
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = key
            };
            SecurityToken securityToken;

            #endregion

            #region Claim

            ClaimsIdentity identity = null;
            try
            {
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);
                if (principal == null)
                {
                    context.Result = new BadRequestObjectResult(new { message = "Bad request: Expired Token.", statusCode = HttpStatusCode.BadRequest });
                    return;
                }
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                context.Result = new BadRequestObjectResult(new { message = "Wrong request", statusCode = HttpStatusCode.BadRequest });
                return;
            }
            catch (SecurityTokenExpiredException)
            {
                context.Result = new BadRequestObjectResult(new { message = "Bad request: Expired Token.", statusCode = HttpStatusCode.BadRequest });
                return;
            }
            var db = new CallDocContext();

            Claim memberid = identity.FindFirst("MemberId");


            if (memberid == null)
            {

                int memberId = int.Parse(memberid.Value);
                Member memberInfo = db.Member.Where(o => o.MemberId == memberId).FirstOrDefault();

                Startup.MemberId = DataEncryption.Encrypt(Convert.ToString(memberInfo.MemberId));
                Startup.MemberTypeId = DataEncryption.Encrypt(Convert.ToString(memberInfo.MemberTypeId));
                Startup.MemberStatusId = DataEncryption.Encrypt(Convert.ToString(memberInfo.MemberStatusId));
            }
            else
            {
                Startup.MemberId = memberid.Value;
            }

            #endregion

            return;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }
    }
}
