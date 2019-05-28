using Application.DTO;
using Application.Responsens;
using Application.Searches;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IDishRepository: IRepository<Dish>,ICommand<DishSearch, PageResponse<DishDTO>>
    {
        void AddDish(DishDTO dto);
        void UpdateDidh(DishDTO dto, int id);
        void RemoveDish(int id);
    }
}
