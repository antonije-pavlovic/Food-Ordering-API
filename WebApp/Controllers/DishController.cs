using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace WebApp.Controllers
{
    public class DishController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public DishController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Dish
        public ActionResult Index()
        {
            var dishes = _unitOfWork.Dish.GetAll().Select(d => new DishDTO
            {
                Id = d.Id,
                Titile = d.Title,
                Price = d.Price,
                Ingridients = d.Ingredients,
                Serving = d.Serving,
                Category = d.Category.Name
            });
            return View(dishes);
        }

        // GET: Dish/Details/5
        public ActionResult Details(int id)
        {
            var dish = _unitOfWork.Dish.FindByExpression(d => d.Id == id).Select(d => new DishDTO
            {
                Id = d.Id,
                Titile = d.Title,
                Ingridients = d.Ingredients,
                Serving = d.Serving,
                Price = d.Price,
                Category = d.Category.Name
            }).FirstOrDefault();
            return View(dish);
        }

        // GET: Dish/Create
        public ActionResult Create()
        {
            var categories = _unitOfWork.Category.GetAll();
            var data = new CatDishDTO()
            {
                Categories = categories
            };
            return View(data);
        }

        // POST: Dish/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                _unitOfWork.Dish.AddDish(new DishDTO
                {
                    Titile = collection["Dish.Titile"],
                    Serving = collection["Dish.Serving"],
                    Ingridients = collection["Dish.Ingridients"],
                    Price = Double.Parse(collection["Dish.Price"]),
                    CategoryId = Int32.Parse(collection["Dish.CategoryId"])
                });
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dish/Edit/5
        public ActionResult Edit(int id)
        {
            var categories = _unitOfWork.Category.GetAll();
            var dish = _unitOfWork.Dish.FindByExpression(d => d.Id == id).Select(d => new DishDTO
            {
                Titile = d.Title,
                Serving = d. Serving,
                Price =d.Price,
                Ingridients = d.Ingredients,
                CategoryId = d.CategoryId
            }).FirstOrDefault();
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
                    Titile = collection["Dish.Title"],
                    Serving = collection["Dish.Serving"],
                    Price = Double.Parse(collection["Dish.Price"]),
                    Ingridients = collection["Dish.Ingridients"],
                    CategoryId = Int32.Parse(collection["Dish.CategoryId"])
                };
                _unitOfWork.Dish.UpdateDidh(newDish, id);
                _unitOfWork.Save();
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
            
           _unitOfWork.Dish.RemoveDish(id);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

       
    }
}