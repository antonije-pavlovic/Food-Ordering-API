﻿using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        void RegisterUser(AuthDTO dto);
    }
}
