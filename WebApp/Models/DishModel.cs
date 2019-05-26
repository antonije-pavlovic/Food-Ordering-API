using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DishModel
    {
        public IEnumerable<DishDTO> MyProperty { get; set; }
    }
}
