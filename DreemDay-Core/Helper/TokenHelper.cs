using DreemDay_Core.Models.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Helper
{
    public static class TokenHelper
    {
        public static string GenerateJwtToken(User input)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes("x3Fv8tB7p9r4q3N7Q1Z2W3M5P6L8K0J3H2G5F6D7S9A8V7C6X5Z1Y2E4R1T3Y4U7");
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim (ClaimTypes.Email,input.Email),
                    new Claim ("Id", input.Id.ToString()),
                    new Claim (ClaimTypes.Role,input.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),

            };
            var token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);
        }
        public static bool IsValidToken(string tokenString)
        {
            var tok = "Bearer" + tokenString;
            var JwtEncodedString = tok.Substring(7);
            var token = new JwtSecurityToken(jwtEncodedString: JwtEncodedString);
            if (token.ValidTo > DateTime.UtcNow)
            {
                return true;
            }
            return false;



        }
    }
}
