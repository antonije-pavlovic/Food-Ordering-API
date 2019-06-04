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
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var id = GetTokenId.getId(User);
                var wallet = _walletService.GetById(id);
                return Ok("Wallet balance: " + wallet.Balance);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] WalletDTO dto)
        {
            var id = GetTokenId.getId(User);
            var currentAmount = _walletService.InsertTransaction(dto, id);
            return Ok(currentAmount);
        }        
    }
}