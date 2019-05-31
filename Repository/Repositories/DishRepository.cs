using Application.DTO;
using Application.Responsens;
using Application.Searches;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Repository.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public DishRepository(DbContext context) : base(context)
        {
        }
    }
}
