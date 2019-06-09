using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public double DishPrice { get; set; }
        public double Sum { get; set; }
        public int Quantity { get; set; }
    }
}
