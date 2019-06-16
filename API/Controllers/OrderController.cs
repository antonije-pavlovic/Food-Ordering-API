using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTO;
using Application.Responsens;
using Application.Searches;
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
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public ActionResult<PageResponse<OrderDTO>> Get([FromQuery] OrderSearch search)
        {
            try
            {
                var id = GetTokenId.getId(User);
                var orders = _orderService.GetOrders(search, id);
                return Ok(orders);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }
       
    }
}