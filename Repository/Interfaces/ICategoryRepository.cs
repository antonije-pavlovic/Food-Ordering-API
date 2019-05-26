using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void AddCategory(CategoryDTO dto);
        void UpdateCategory(CategoryDTO dto,int id);
        void DeleteCategory(CategoryDTO dto);
    }
}
