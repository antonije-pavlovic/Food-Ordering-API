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

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IToken<ClaimsIdentity>
    {
        public UserController()
        {
           
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "djoka" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
       
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {            
            var claimsIdentity = User.Identity as ClaimsIdentity;
           // return Ok(claimsIdentity.Claims.Where(x => x.Type == "id").FirstOrDefault().Value);
           var id = GetTokenId.getId(this.getClaim());
            //foreach (var claim in claimsIdentity.Claims)
            //{
            //    Console.WriteLine(claim.Type + ":" + claim.Value);
            //}
            return Ok(id);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AuthDTO dto)
        {
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public ClaimsIdentity getClaim()
        {
           return User.Identity as ClaimsIdentity;
        }
    }
}
