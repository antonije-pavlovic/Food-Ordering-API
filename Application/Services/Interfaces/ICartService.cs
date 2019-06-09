using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services.Interfaces
{
    public interface ICartService: IService<InsertCartDTO, CartDTO>
    {
        IQueryable<CartDTO> ListCart(int id);
        void Purchase(int id);
        bool CheckItemExist(int userId, int itemId);
        int Insert(InsertCartDTO dto, int id);
        void Update(UpdateCartDTO dto, int id);
    }
}
