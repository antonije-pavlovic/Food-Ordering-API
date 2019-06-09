using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class InsertDishDTO
    {
        public string Image { get; set; }       
        public string Titile { get; set; }
        public string Ingridients { get; set; }
        public string Serving { get; set; }
        public double Price { get; set; }        
        public int CategoryId { get; set; }
    }
}

