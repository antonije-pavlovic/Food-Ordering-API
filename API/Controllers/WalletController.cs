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
    public class WalletController : ControllerBase, IToken<ClaimsIdentity>
    {
        private IUnitOfWork _unitOfWork;
        public WalletController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var id = GetTokenId.getId(this.getClaim());
            var balance = _unitOfWork.Wallet.Find(w => w.UserId == id).FirstOrDefault();
            return Ok("Wallet balance: " + balance.Balance);
        }
        [HttpPost]
        public IActionResult Post([FromBody] WalletDTO dto)
        {
            var id = GetTokenId.getId(this.getClaim());
            if (Double.IsNegative(dto.Balance) || dto.Balance < 1 || Double.IsNaN(dto.Balance))
            {
                return BadRequest("please insert correct value");
            }
            var currentAmount = _unitOfWork.Wallet.InsertMoney(dto.Balance, id);
            _unitOfWork.Save();
            return Ok(currentAmount);
        }

        public ClaimsIdentity getClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}