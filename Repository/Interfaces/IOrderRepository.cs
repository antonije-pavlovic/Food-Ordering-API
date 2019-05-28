using Application.DTO;
using Application.Responsens;
using Application.Searches;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IOrderRepository: IRepository<Order>,ICommand<OrderSearch, PageResponse<OrderDTO>>
    {
        void InsertOrder(int userId,string desc,double total);
    }
}
