using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services;
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

            data.Password = Compute256Hash.ComputeSha256Hash(data.Password);
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
            data.Password = Compute256Hash.ComputeSha256Hash(data.Password);
            var valid = _unitOfWork.User.Find(u => u.Password == data.Password && u.Email == data.Email);
            if (valid.Count() == 1)
            {                
                var user = new AuthDTO
                {
                    FirstName = valid.First().FirstName,
                    LastName = valid.First().LastName,
                    Email = valid.First().Email
                };
                var token = GenerateToken.GenerateJSONWebToken(user, _config);
                return Ok(token);
            }
            else
            {
                return BadRequest("there is on user with this password and email");
            }              

        }

        
    }
}