using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            _unitOfWork.User.RegisterUser(data);
            _unitOfWork.Save();
            return Ok("succesfull registration");

        }
    }
}