using Application.DTO;
using Application.Services;
using DataAccess;
using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RestaurantContext context) : base(context) { }

        public int RegisterUser(AuthDTO dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                RoleId = 1
            };
            Context.Add(user);
            Context.SaveChanges();
            return user.Id;
        }

        public void UpdateUser(AuthDTO dto,int id)
        {
            var user = Get(id);
            if (!String.IsNullOrEmpty(dto.FirstName))
                user.FirstName = dto.FirstName;
            if (!String.IsNullOrEmpty(dto.LastName))
                user.LastName = dto.LastName;
            if (!String.IsNullOrEmpty(dto.Password))
                user.Password = Compute256Hash.ComputeSha256Hash(dto.Password);
            if (!String.IsNullOrEmpty(dto.Email))
                user.Email = dto.Email;
            user.ModifiedAt = DateTime.Now; //ubaci proveru da li je bar nesto poslato da ne modifikuje
        }

        public void SoftDelete(int id)
        {
            var user = Get(id);
            user.ModifiedAt = DateTime.Now;
            user.IsDeleted = 1;
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
