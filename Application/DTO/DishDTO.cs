using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class DishDTO: InsertDishDTO
    {
        public int Id { get; set; }
        public string Category { get; set; }
    }
}
