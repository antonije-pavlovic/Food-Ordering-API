using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class InsertCartDTO: UpdateCartDTO
    {
        public int DishId { get; set; }
    }
}
