using Application.DTO;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
namespace Application.Services
{
    public class GenerateToken
    {      
        public static string GenerateJSONWebToken(User dto,IConfiguration config)
        {
            Console.WriteLine(dto.Email);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sid ,dto.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, dto.Email),               
                new Claim(JwtRegisteredClaimNames.GivenName, dto.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, dto.LastName),
                new Claim("Roles", dto.RoleId.ToString())
            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);           
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
