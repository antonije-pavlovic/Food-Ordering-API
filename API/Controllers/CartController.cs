﻿using System;
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
    public class CartController : ControllerBase
    {
        private ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public ActionResult<CartDTO> Get()
        {
            try
            {
                var id = GetTokenId.getId(User);
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
        public IActionResult Post([FromBody] InsertCartDTO dto)
        {            
            try
            {
                var id = GetTokenId.getId(User);            
                _cartService.Insert(dto,id);
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
                var id = GetTokenId.getId(User);
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
        public IActionResult Delete([FromBody] CartDTO dto)
        {
            var id = GetTokenId.getId(User);
            if (_cartService.CheckItemExist(id, dto.Id))
            {
                _cartService.DeleteById(dto.Id);
                return Ok("succesfully deleted");
            }            
            return Ok("Order does not exist in cart");
        }
        
        [HttpPut("{ItemId}")]
        public IActionResult Put(int ItemId, [FromBody] UpdateCartDTO dto)
        {
            var gid = GetTokenId.getId(User);
            try
            {
                if (_cartService.CheckItemExist(gid, ItemId))
                {
                    _cartService.Update(dto, ItemId);
                    return Ok("Quantity successfully updated!");
                }
                return BadRequest("Order with that id does not exist in your cart!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
