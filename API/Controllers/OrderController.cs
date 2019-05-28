using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTO;
using Application.Searches;
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
    public class OrderController : ControllerBase, IToken<ClaimsIdentity>
    {
        private IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search)
        {
            var id = GetTokenId.getId(this.getClaim());
            search.UserId = id;
            var orders = _unitOfWork.Order.Execute(search);
            return Ok(orders);
        }

        public ClaimsIdentity getClaim()
        {
            return User.Identity as ClaimsIdentity;
        }
    }
}