using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTO;
using Application.Responsens;
using Application.Searches;
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
    public class DishController : ControllerBase
    {
        private IDishService _dishService;
        private IImageService _imageService;
        public DishController(IDishService dishService, IImageService imageService)
        {
            _dishService = dishService;
            _imageService = imageService;
        }
       
        // GET: api/Dish
        [HttpGet]        
        public ActionResult<PageResponse<DishDTO>> Get([FromQuery] DishSearch search)
        {
            var dishes = _dishService.Execute(search);
            return Ok(dishes);
        }

        // GET: api/Dish/5
        [HttpGet("{id}")]
        public ActionResult<DishDTO> Get(int id)
        {
            try
            {
                var dish = _dishService.GetById(id);
                return Ok(dish);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "1")]
        // POST: api/Dish
        [HttpPost]
        public IActionResult Post([FromForm] InsertDishDTO dto, IFormFile file)
        {
            try
            {
                var image = _imageService.UploadImage(file);
                dto.Image = image;
                var id = _dishService.Insert(dto);
                return Created("api/dish"+ id , dto);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "1")]
        // PUT: api/Dish/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] InsertDishDTO dto, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    var dish = _dishService.GetById(id);
                    _imageService.DeleteImage(dish.Image);
                    var path = _imageService.UploadImage(file);
                    dto.Image = path;
                }
                _dishService.Update(dto, id);
                return Ok("Succefully updated");
            }
            catch(Exception e)
            {
                return Ok("Something went wrong");
            }
            
        }

        [Authorize(Roles = "1")]
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var image = _dishService.GetById(id);
                _imageService.DeleteImage(image.Image);
                _dishService.DeleteById(id);
                return Ok("Succefully deleted");
            }
            catch(Exception e)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
