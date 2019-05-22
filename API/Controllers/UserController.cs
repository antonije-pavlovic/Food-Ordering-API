using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services;
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
        private IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/User
        //[HttpGet]
        //[Route("Users")]
        //public IActionResult GetAll()
        //{           
        //    return Ok(_unitOfWork.User.GetAll());
        //}

        // GET: api/User/5
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var uid= GetTokenId.getId(this.getClaim());
        //    var user = _unitOfWork.User.Get(uid);
        //    return Ok(user);
        //}

        // POST: api/User

        //[HttpPost]
        //public IActionResult Post([FromBody] string value)
        //{
        //    var id = GetTokenId.getId(this.getClaim());
        //    return Ok(id);
        //}

        // PUT: api/User/5
        [HttpPut]
        public IActionResult Put([FromBody] AuthDTO dto)
        {
            var id = GetTokenId.getId(this.getClaim());
            _unitOfWork.User.UpdateUser(dto, id);
            _unitOfWork.Save();
            return Ok("succesufully updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete()
        {
           var id = GetTokenId.getId(this.getClaim());
           _unitOfWork.User.SoftDelete(id);
           _unitOfWork.Save();
            return Ok("Account deleted");
        }

        public ClaimsIdentity getClaim()
        {
           return User.Identity as ClaimsIdentity;
        }
    }
}
