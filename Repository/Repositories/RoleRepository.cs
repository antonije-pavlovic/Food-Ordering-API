using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class RoleRepository : Repository<Role>, IRolesRepository
    {
        public RoleRepository(DbContext context) : base(context) { }
        public RestaurantContext RestaurantContext
        {
            get
            {
                return Context as RestaurantContext;
            }
        }
    }
}
