using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CategoryModel
    {
        public IEnumerable<CategoryDTO> MyProperty { get; set; }
    }
}
