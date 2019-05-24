using DataAccess;
using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantContext context) : base(context) { }

        public RestaurantContext RestaurantContext
        {
            get
            {
                return Context as RestaurantContext;
            }
        }

        public void InsertOrder(int userId, string desc, double total)
        {
            Context.Add(new Order
            {
                UserId = userId,
                Description = desc,
                Total = total
            });
        }
    }
}
