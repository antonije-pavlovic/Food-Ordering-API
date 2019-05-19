using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;

        public AuthController(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] AuthDTO data)
        {
           
            if (String.IsNullOrEmpty(data.FirstName))            
                return BadRequest("First name is required");            
            if (String.IsNullOrEmpty(data.LastName))            
                return BadRequest("Last name is required");            
            if (String.IsNullOrEmpty(data.Email))            
                return BadRequest("email is required");            
            if (String.IsNullOrEmpty(data.Password))            
                return BadRequest("Password is required");
            if (!data.Email.Contains("@"))
                return BadRequest("Emmail is not in good format");
            data.Password = ComputeSha256Hash(data.Password);
            _unitOfWork.User.RegisterUser(data);
            _unitOfWork.Save();
            return Ok("succesfull registration");
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AuthDTO data)
        {
            if (String.IsNullOrEmpty(data.Password))
                return BadRequest("password is requires");
            if (String.IsNullOrEmpty(data.Email))
                return BadRequest("email is requires");
            if (!data.Email.Contains("@"))
                return BadRequest("Emmail is not in good format");
            var token = GenerateJSONWebToken(data);
            return Ok(token);
        }

        private string GenerateJSONWebToken(AuthDTO dto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email, dto.Email),
                new Claim(JwtRegisteredClaimNames.Sid, dto.Password)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}