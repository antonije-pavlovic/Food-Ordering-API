using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTO;
using Application.Searches;
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
    public class DishController : ControllerBase, IToken<ClaimsIdentity>
    {
        private IDishService _dishService;
        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }
       
        // GET: api/Dish
        [HttpGet]
        [Authorize(Roles="1")]
        public IActionResult Get([FromQuery] DishSearch search)
        {
            var dishes = _dishService.Execute(search);
            return Ok(dishes);
        }

        // GET: api/Dish/5
        [HttpGet("{id}", Name ="GetDish")] //ovde sam obrisao name i u ostalim kontrolerima
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Dish
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Dish/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
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
