using Application.DTO;
using Application.Responsens;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Interfaces
{
    public interface IDishService : IService<DishDTO>
    {
        PageResponse<DishDTO> Execute(DishSearch search);
    }
}
