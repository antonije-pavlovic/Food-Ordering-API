using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTO;
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
    public class CartController : ControllerBase, IToken<ClaimsIdentity>
    {
        private ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var id = GetTokenId.getId(this.getClaim());
                var items = _cartService.ListCart(id);
                return Ok(items);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }
       
        // POST: api/Cart
        [HttpPost]
        public IActionResult Post([FromBody] CartDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var id = GetTokenId.getId(this.getClaim());
                dto.UserId = id;
                _cartService.Insert(dto);
                return Ok("succesfuly added to cart");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }     

        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit()
        {
            try
            {
                var id = GetTokenId.getId(this.getClaim());
                _cartService.Purchase(id);
                return Ok("dostava za 45-60min");
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
            _cartService.DeleteById(id);
            return Ok("succesfully deleted");
        }

        public ClaimsIdentity getClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}
