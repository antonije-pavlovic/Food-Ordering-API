using Application.DTO;
using Application.Services.Interfaces;
using Domain;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(CategoryDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var cat = _unitOfWork.Category.Find(c => c.Id == id).FirstOrDefault();
            _unitOfWork.Category.Remove(cat);
            _unitOfWork.Save();
        }

        public IQueryable<CategoryDTO> GetAll()
        {
            var categories = _unitOfWork.Category.GetAll().Select(c => new CategoryDTO
            {
                Name = c.Name,
                Id = c.Id,
                CreatedAt = c.CreatedtAt
            });
            return categories;
        }

        public CategoryDTO GetById(int id)
        {
            var cat = _unitOfWork.Category.Find(c => c.Id == id).Select(c => new CategoryDTO
            {
                Name = c.Name,
                Id = c.Id
            }).FirstOrDefault();
            return cat;
        }

        public int Insert(CategoryDTO entity)
        {            
            var cat = new Category
            {
                Name = entity.Name
            };
           _unitOfWork.Category.Add(cat);
            _unitOfWork.Save();
            return cat.Id;
        }

        public void Update(CategoryDTO entity, int id)
        {
            var cat = _unitOfWork.Category.Get(id);
            if (!String.IsNullOrEmpty(entity.Name))
                cat.Name = entity.Name;
            _unitOfWork.Save();
        }
    }
}
