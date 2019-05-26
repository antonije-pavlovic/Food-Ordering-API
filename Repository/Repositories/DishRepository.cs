using Application.DTO;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
