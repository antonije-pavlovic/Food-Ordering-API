using Application.DTO;
using Application.Responsens;
using Application.Searches;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Repository.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public DishRepository(DbContext context) : base(context)
        {

        }

        public void AddDish(DishDTO dto)
        {
            Context.Add(new Dish
            {
                Title = dto.Titile,
                Price = dto.Price,
                Serving = dto.Serving,
                Ingredients = dto.Ingridients,
                CategoryId = dto.CategoryId
                
            });
        }

        public PageResponse<DishDTO> Execute(DishSearch request)
        {

            var query = GetAll();

            if (request.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= request.MinPrice);
            }

            if (request.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= request.MaxPrice);
            }

            if (request.Title != null)
            {
                var keyword = request.Title.ToLower();

                query = query.Where(p => p.Title.ToLower().Contains(keyword));
            }

            if (request.CategoryId != null)
            {
                query = query.Where(p => p.CategoryId == request.CategoryId);
            }        

            var totalCount = query.Count();
            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PageResponse<DishDTO>
            {
                CurrentPage = request.PageNumber,
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

        public void RemoveDish(int id)
        {
            var dish = Get(id);
            Remove(dish);
        }

        public void UpdateDidh(DishDTO dto, int id)
        {
            var dish = Get(id);
            dish.Title = dto.Titile;
            dish.Price = dto.Price;
            dish.Serving = dto.Serving;
            dish.Ingredients = dto.Ingridients;
            dish.ModifiedAt = DateTime.Now;
        }
    }
}
