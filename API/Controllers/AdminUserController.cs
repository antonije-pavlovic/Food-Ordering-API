using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles="1")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminUserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/AdminUser
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _userService.GetAll();
                return Ok(users);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/AdminUser/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _userService.GetById(id);
                return Ok(user);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/AdminUser
        [HttpPost]
        public IActionResult Post([FromBody] AuthDTO dto)
        {
            try
            {
                _userService.Insert(dto);
                return Ok("Succeffully created");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/AdminUser/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AuthDTO dto)
        {
            try
            {
                _userService.Update(dto, id);
                return Ok("Successfully updated");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.DeleteById(id);
                return Ok("Successfully deleted");
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
