﻿using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services.Interfaces
{
    public interface ICartService: IService<CartDTO>
    {
        IQueryable<CartDTO> ListCart(int id);
        void Purchase(int id);
    }
}