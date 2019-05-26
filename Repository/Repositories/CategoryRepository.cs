using Application.DTO;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{

    public class CategoryRepository: Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(DbContext context): base(context) { }
        public RestaurantContext RestaurantContext
        {
            get
            {
                return Context as RestaurantContext;
            }
        }

        public void AddCategory(CategoryDTO dto)
        {
            var cat = new Category
            {
                Name = dto.Name                
            };
            Context.Add(cat);
        }

        public void DeleteCategory(CategoryDTO dto)
        {
            Remove(new Category
            {
                Id = dto.Id
            });
        }

        public void UpdateCategory(CategoryDTO dto,int id)
        {
            var cat = Get(id);
            if (!String.IsNullOrEmpty(dto.Name))
                cat.Name = dto.Name;            
        }
    }
}
