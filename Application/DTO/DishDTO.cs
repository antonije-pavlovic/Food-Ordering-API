using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class DishDTO
    {
        public int Id { get; set; }
        public string Titile { get; set; }
        public string Ingridients { get; set; }
        public string Serving { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }       
    }
}
