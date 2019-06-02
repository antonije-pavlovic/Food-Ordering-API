using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace WebApp.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishService _dishService;
        private readonly ICategoryService _categoryService;
        
        public DishController(IDishService dishService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _dishService = dishService;
        }

        // GET: Dish
        public ActionResult Index()
        {
            var dishes = _dishService.GetAll();             
            return View(dishes);
        }

        // GET: Dish/Details/5
        public ActionResult Details(int id)
        {
            var dish = _dishService.GetById(id);
            return View(dish);
        }

        // GET: Dish/Create
        public ActionResult Create()
        {
            var categories = _categoryService.GetAll();
            var data = new CatDishDTO()
            {
                Categories = categories
            };
            return View(data);
        }

        // POST: Dish/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, IFormFile file)
        {
            try
            {
                var path = this.UploadFile(file);
                var dish = new DishDTO
                {
                    Titile = collection["Dish.Titile"],
                    Serving = collection["Dish.Serving"],
                    Ingridients = collection["Dish.Ingridients"],
                    Price = Double.Parse(collection["Dish.Price"]),
                    CategoryId = Int32.Parse(collection["Dish.CategoryId"]),
                    Image = path
                };
                _dishService.Insert(dish);              
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }

        // GET: Dish/Edit/5
        public ActionResult Edit(int id)
        {
            var categories = _categoryService.GetAll();
            var dish = _dishService.GetById(id);
            var data = new CatDishDTO
            {
                Categories = categories,
                Dish = dish
            };
            return View(data);
        }

        // POST: Dish/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var newDish = new DishDTO
                {
                    Titile = collection["Dish.Titile"],
                    Serving = collection["Dish.Serving"],
                    Price = Double.Parse(collection["Dish.Price"]),
                    Ingridients = collection["Dish.Ingridients"],
                    CategoryId = Int32.Parse(collection["Dish.CategoryId"])
                };
                _dishService.Update(newDish,id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dish/Delete/5
        public ActionResult Delete(int id)
        {
            _dishService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
        public string UploadFile(IFormFile file)
        {
            var fileName = file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;
        }

    }
}