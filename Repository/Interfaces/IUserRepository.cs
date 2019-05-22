using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        int RegisterUser(AuthDTO dto);
        void UpdateUser(AuthDTO dto,int id);
        void SoftDelete(int id);
    }
}
