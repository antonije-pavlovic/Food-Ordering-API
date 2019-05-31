using Application.DTO;
using Application.Responsens;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Interfaces
{
    public interface IOrderService: IService<OrderDTO>
    {
        PageResponse<OrderDTO> GetOrders(OrderSearch search, int id);
    }
}
