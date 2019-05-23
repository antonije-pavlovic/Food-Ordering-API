using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface ICartRepository:IRepository<Cart>
    {
        void addToCart(int id,int userId,int quantity,double amount);
        int RemoveFromCart(int userId,int dishId);
    }
}
