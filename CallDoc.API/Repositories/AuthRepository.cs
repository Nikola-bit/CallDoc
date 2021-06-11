using CallDoc.API.Models;
using CallDoc.API.Utilities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CallDoc.API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public string CreateToken(Member user)
        {
            var member = user;

            string tokenString = string.Empty;

            if (member != null)
            {
                string mId = DataEncryption.Encrypt(member.MemberId.ToString());
                string mType = DataEncryption.Encrypt(member.MemberTypeId.ToString());
                string mStatus = DataEncryption.Encrypt(member.MemberStatusId.ToString());

                var claims = new[]
                {
                    new Claim("MemberId",mId),
                    new Claim("MemberTypeId",mType),
                    new Claim("MemberStatusId",mStatus)
                };

                //Read the token key used for token creation/validation
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Startup.TokenKey));

                //Create token credentials from the key provided
                var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);


                //Token settings like lifetime, user informations, key etc.
                var token = new JwtSecurityToken(
                issuer: Startup.Issuer,
                audience: Startup.Audience,
                expires: DateTime.Now.AddMinutes(2880),
                claims: claims,
                signingCredentials: signInCred
                );


                tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return tokenString;
            }

            else return null;
        }

    }
}
