using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IDishRepository: IRepository<Dish>
    {
        void AddDish(DishDTO dto);
        void UpdateDidh(DishDTO dto, int id);
        void RemoveDish(int id);
    }
}
