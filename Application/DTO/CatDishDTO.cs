using Domain;
using System.Linq;
namespace Application.DTO
{
    public  class CatDishDTO
    {
        public IQueryable<Category> Categories { get; set; }
        public DishDTO Dish { get; set; }
    }
}
