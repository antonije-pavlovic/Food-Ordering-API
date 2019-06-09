using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles="1")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/AdminCategory
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var categories = _categoryService.GetAll();
                return Ok(categories);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/AdminCategory/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var category = _categoryService.GetById(id);
                return Ok(category);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/AdminCategory
        [HttpPost]
        public IActionResult Post([FromBody] InsertCategoryDTO dto)
        {
            try
            {
                _categoryService.Insert(dto);
                return Ok("Secceffuly creteed");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/AdminCategory/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InsertCategoryDTO dto)
        {
            try
            {
                _categoryService.Update(dto, id);
                return Ok("Succeffuly upated");
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
            try
            {
                _categoryService.DeleteById(id);
                return Ok("Succeffuly delted");
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
