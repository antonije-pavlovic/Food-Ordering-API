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
            var uid = GetTokenId.getId(this.getClaim());
            var cartItems = _unitOfWork.Cart.GetAll().Where(c => c.UserId == uid).Select(c => new
            {
                c.Dish.Title,
                c.Quantity,
                c.Sum,
                c.Dish.Price
            }).ToList();
            if(cartItems.Any())
                return Ok(cartItems);
            return Ok("There is no items in cart");
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

        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit()
        {
            var uid = GetTokenId.getId(this.getClaim());
            var cartItems = _unitOfWork.Cart.GetAll().Where(c => c.UserId == uid).Select(c => new
            {
                c.Dish.Id,
                c.Dish.Title,
                c.Quantity,
                c.Sum,
                c.Dish.Price                
            }).ToList();
            if (!cartItems.Any())                
                return Ok("There is no items in cart");
            var overall = 0.0;
            var desc = "";
            foreach(var item in cartItems)
            {
                desc += item.Title + " " + item.Price + ", " +item.Quantity+ ", sum= " +item.Sum;
                overall = overall + item.Sum;
            }
            var availableMoney = _unitOfWork.Wallet.Find(w => w.UserId == uid).First();
            if( availableMoney.Balance < overall)
            {
                return Ok("You dont have enough money in your wallet,please charge it");
            }
            _unitOfWork.Order.InsertOrder(uid, desc, overall);
            foreach(var item in cartItems)
            {
                _unitOfWork.Cart.RemoveFromCart(uid,item.Id);
            }
            availableMoney.Balance = availableMoney.Balance - overall;
            _unitOfWork.Transaction.InsertTransaction(availableMoney.Id, overall, "outcome");
            _unitOfWork.Save();
            return Ok("dostava za 45-60min");
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
