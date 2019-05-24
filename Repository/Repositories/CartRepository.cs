using DataAccess;
using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Repository.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(RestaurantContext context) : base(context) { }        
        public void addToCart(int id, int userId,int quantity,double amount)
        {
            Context.Add(new Cart
            {
                 DishId = id,
                 UserId = userId,
                 Quantity = quantity,
                 Sum = amount
            });
        }

        public int RemoveFromCart(int userId, int dishId)
        {
            var cart = Find(c => c.UserId == userId && c.DishId == dishId).FirstOrDefault();
            
            if (cart != null)
            {
                Context.Remove(cart);
                return 1;
            }               
            else
                return 0;
        }
        

        public RestaurantContext RestaurantContext
        {
            get
            {
                return Context as RestaurantContext;
            }
        }
    }
}
