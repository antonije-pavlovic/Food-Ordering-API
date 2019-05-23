using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTO;
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
        private IUnitOfWork _unitOfWork;
        public DishController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        // GET: api/Dish
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var dishes = _unitOfWork.Dish.GetAll().Select(d => new DishDTO
            {
                Titile = d.Title,
                Ingridients = d.Ingredients,
                Price = d.Price,
                CategoryId = d.CategoryId,
                Category = d.Category.Name
            }).OrderBy(d => d.Category).ToList();
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
