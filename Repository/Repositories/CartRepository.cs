using DataAccess;
using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Repository.Repositories
{
    public class CartRepository : Repository<Cart>,ICartRepository
    {
        public CartRepository(RestaurantContext context) : base(context) { }       
     
        public RestaurantContext RestaurantContext
        {
            get
            {
                return Context as RestaurantContext;
            }
        }
    }
}
