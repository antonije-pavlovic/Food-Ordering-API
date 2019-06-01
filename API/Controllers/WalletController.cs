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
    public class WalletController : ControllerBase, IToken<ClaimsIdentity>
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var id = GetTokenId.getId(this.getClaim());
            var wallet = _walletService.GetById(id);         
            return Ok("Wallet balance: " + wallet.Balance);
        }
        [HttpPost]
        public IActionResult Post([FromBody] WalletDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var id = GetTokenId.getId(this.getClaim());
            var currentAmount = _walletService.InsertTransaction(dto, id);
            return Ok(currentAmount);
        }

        public ClaimsIdentity getClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}