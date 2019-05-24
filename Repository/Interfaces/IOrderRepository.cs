using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IOrderRepository: IRepository<Order>
    {
        void InsertOrder(int userId,string desc,double total);
    }
}
