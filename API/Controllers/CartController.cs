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
    public class CartController : ControllerBase, IToken<ClaimsIdentity>
    {
        private IUnitOfWork _unitOfWork;
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET: api/Cart/5
        [HttpGet("{id}",Name ="GetCart")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cart
        [HttpPost]
        public IActionResult Post([FromBody] CartDTO dto)
        {
            var id = GetTokenId.getId(this.getClaim());
            var dish = _unitOfWork.Dish.Find(d => d.Id == dto.Id).FirstOrDefault();
            _unitOfWork.Cart.addToCart(dto.Id, id, dto.Quantity, dto.Quantity * dish.Price);
            _unitOfWork.Save();
            return Ok(dto);
        }     

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var uid = GetTokenId.getId(this.getClaim());
            var flag = _unitOfWork.Cart.RemoveFromCart(uid, id);
            _unitOfWork.Save();
            if (flag == 1)
                return Ok("successfuly deleted");
            else
                return BadRequest("ne moze");
        }

        public ClaimsIdentity getClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}
