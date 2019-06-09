using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTO;
using Application.Searches;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private IConfiguration _config;       

        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;            
        }

        [HttpGet]
        [Route("Transaction")]
        public IActionResult Transaction([FromQuery] TransactionSearch search)
        {
            var id = GetTokenId.getId(User);
            var transaction = _userService.GetTRansactions(search,id);           
            return Ok(transaction);
        }

        // PUT: api/User/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateUserDTO dto)
        {
            var id = GetTokenId.getId(User);
            _userService.Update(dto,id);                       
            return Ok("succesufully updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete()
        {
            var id = GetTokenId.getId(User);
            _userService.DeleteById(id);           
            return Ok("Account deleted");
        }
        [HttpPost]
        [Route("contact")]
        public IActionResult Contact([FromBody]MailDTO dto )
        {
            try
            {
                var id = GetTokenId.getId(User);
                _userService.SendMail(dto, id);
                return Ok();
            }
            catch(Exception e)
            {
                return Ok("Servis is temporary out of function");
            }
        }       
    }
}
