using Application.DTO;
using Application.Responsens;
using Application.Searches;
using Application.Services.Interfaces;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Application.Services.Implementation
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;

        public DishService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public void Delete(DishDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var dish = _unitOfWork.Dish.Get(id);            
           _unitOfWork.Dish.Remove(dish);
           _unitOfWork.Save();            
        }

        public IQueryable<DishDTO> GetAll()
        {
            var dishes = _unitOfWork.Dish.GetAll().Select(d => new DishDTO
            {
                Id = d.Id,
                Titile = d.Title,
                Ingridients = d.Ingredients,
                Serving = d.Serving,
                Price = d.Price,
                Category = d.Category.Name,
                Image = d.Image
            });
            return dishes;
        } 

        public DishDTO GetById(int id)
        {
            var dish = _unitOfWork.Dish.Find(d => d.Id == id).Select(d => new DishDTO
            {
                Id = d.Id,
                Ingridients = d.Ingredients,
                Price = d.Price,
                Serving =d.Serving,
                Titile = d.Title,
                Image = d.Image
            }).FirstOrDefault();
            return dish;
        }

        public PageResponse<DishDTO> Execute(DishSearch search)
        {
            var query = _unitOfWork.Dish.GetAll();

            if (search.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= search.MinPrice);
            }

            if (search.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= search.MaxPrice);
            }

            if (search.Title != null)
            {
                var keyword = search.Title.ToLower();

                query = query.Where(p => p.Title.ToLower().Contains(keyword));
            }

            if (search.CategoryId != null)
            {
                query = query.Where(p => p.CategoryId == search.CategoryId);
            }

            var totalCount = query.Count();
            query = query.Skip((search.PageNumber - 1) * search.PerPage).Take(search.PerPage);
            var pagesCount = (int)Math.Ceiling((double)totalCount / search.PerPage);

            var response = new PageResponse<DishDTO>
            {
                CurrentPage = search.PageNumber,
                TotalCount = totalCount,
                PageCount = pagesCount,
                Data = query.Select(p => new DishDTO
                {
                    Id = p.Id,
                    Titile = p.Title,
                    Price = p.Price,
                    Category = p.Category.Name,
                    Serving = p.Serving,
                    Ingridients = p.Ingredients,
                    CategoryId = p.CategoryId
                })
            };

            return response;
        }

        public int Insert(DishDTO dto)
        {
            var dish = new Dish
            {
                Title = dto.Titile,
                Price = dto.Price,
                Serving = dto.Serving,
                Ingredients = dto.Ingridients,
                CategoryId = dto.CategoryId,
                Image = dto.Image
            };
            _unitOfWork.Dish.Add(dish);
            _unitOfWork.Save();
            return dish.Id;
        }

        public void Update(DishDTO dto, int id)
        {
            var dish = _unitOfWork.Dish.Get(id);
            dish.Title = dto.Titile;
            dish.Price = dto.Price;
            dish.Serving = dto.Serving;
            dish.Ingredients = dto.Ingridients;
            dish.ModifiedAt = DateTime.Now;
            _unitOfWork.Save();
        }

        
    }
}
