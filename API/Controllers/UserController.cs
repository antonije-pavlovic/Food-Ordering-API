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
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IToken<ClaimsIdentity>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("Transaction")]
        public IActionResult Transaction([FromQuery] TransactionSearch search)
        {
            var id = GetTokenId.getId(this.getClaim());
            var transaction = _userService.GetTRansactions(search,id);           
            return Ok(transaction);
        }

        // PUT: api/User/5
        [HttpPut]
        public IActionResult Put([FromBody] AuthDTO dto)
        {
            var id = GetTokenId.getId(this.getClaim());
            _userService.Update(dto,id);                       
            return Ok("succesufully updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete()
        {
           var id = GetTokenId.getId(this.getClaim());
            _userService.DeleteById(id);           
            return Ok("Account deleted");
        }
        [HttpPost]
        [Route("contact")]
        public IActionResult Contact([FromBody]MailDTO dto )
        {
            var id = GetTokenId.getId(this.getClaim());
            _userService.SendMail(dto,id);
            return Ok();
        }
        public ClaimsIdentity getClaim()
        {
           return User.Identity as ClaimsIdentity;
        }
    }
}
