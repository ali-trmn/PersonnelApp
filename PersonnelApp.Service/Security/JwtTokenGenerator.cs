using Microsoft.IdentityModel.Tokens;
using PersonnelApp.Model.UserDto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Service.Security
{
    public class JwtTokenGenerator
    {
        public static string GenerateToken(CheckUserResponseDto checkUserResponseDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSetting.Key));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new();
            claims.Add(new Claim(ClaimTypes.Role, checkUserResponseDto.Role));
            claims.Add(new Claim(ClaimTypes.Name, checkUserResponseDto.Username));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, checkUserResponseDto.Id.ToString()));

            var expireDate = DateTime.UtcNow.AddHours(JwtTokenSetting.Expire);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokenSetting.Issuer,
                audience: JwtTokenSetting.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expireDate,
                signingCredentials: credentials
                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
