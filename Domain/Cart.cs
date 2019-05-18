using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Cart
    {
        public  int Id { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int DishId { get; set; }
        public User User { get; set; }
        public Dish Dish { get; set; }
        public double Sum { get; set; }

    }
}
