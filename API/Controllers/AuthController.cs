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
using Application.Services.Interfaces;
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
        private readonly IUserService _userService;
        private IConfiguration _config;
        public AuthController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] AuthDTO data)
        {
            _userService.Insert(data);          
            return Ok("succesfull registration");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AuthDTO data)
        {
            _userService.Login(data, _config);
            return Ok();
        }        
    }
}