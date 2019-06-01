using Application.DTO;
using Application.Responsens;
using Application.Searches;
using Application.Services.Interfaces;
using Domain;
using Microsoft.Extensions.Configuration;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(AuthDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var user = _unitOfWork.User.Get(id);
            user.ModifiedAt = DateTime.Now;
            user.IsDeleted = 1;            
            _unitOfWork.Save();
        }

        public PageResponse<TransactionDTO> Execute(TransactionSearch request)
        {           
            var query = _unitOfWork.Transaction.Find(t => t.WalletID == request.WalletId);

            if (request.MinAmount.HasValue)
            {
                query = query.Where(t => t.Amount >= request.MinAmount);
            }

            if (request.MaxAmount.HasValue)
            {
                query = query.Where(t => t.Amount <= request.MaxAmount);
            }

            if (request.Type != null)
            {
                var keyword = request.Type.ToLower();
                query = query.Where(t => t.Type.ToLower().Contains(keyword));
            }


            var totalCount = query.Count();
            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PageResponse<TransactionDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PageCount = pagesCount,
                Data = query.Select(t => new TransactionDTO
                {
                    Amount = t.Amount,
                    Type = t.Type,
                    CreatedAt = t.CreatedtAt
                })
            };            
            return response;
        }

        public IQueryable<AuthDTO> GetAll()
        {
           var users = _unitOfWork.User.GetAll().Select(u => new AuthDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                IsDeleted = u.IsDeleted
            });
            return users;
        }        

        public AuthDTO GetById(int id)
        {
           var user = _unitOfWork.User.Find(u => u.Id == id).Select(u => new AuthDTO
           {
               Id = u.Id,
               FirstName = u.FirstName,
               LastName = u.LastName,
               Email = u.Email,
               IsDeleted = u.IsDeleted
           }).FirstOrDefault();
            return user;
        }

        public PageResponse<TransactionDTO> GetTRansactions(TransactionSearch search, int id)
        {
            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == id).FirstOrDefault();
            search.WalletId = wallet.Id;
            var transactions = this.Execute(search);
            return transactions;
        }

        public int Insert(AuthDTO data)
        {
            if (String.IsNullOrEmpty(data.FirstName))
                throw new Exception("First name is required");
            if (String.IsNullOrEmpty(data.LastName))
                throw new Exception("Last name is required");
            if (String.IsNullOrEmpty(data.Email))
                throw new Exception("email name is required");
            if (String.IsNullOrEmpty(data.Password))
                throw new Exception("Password name is required");
            if (!data.Email.Contains("@"))
                throw new Exception("Emmail is not in good forma");
            data.Password = Compute256Hash.ComputeSha256Hash(data.Password);
            var user = new User
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = data.Password,
                RoleId = 1
            };
            _unitOfWork.User.Add(user);
            _unitOfWork.Save();
            var userId = user.Id;
            _unitOfWork.Wallet.Add(new Wallet
            {
                UserId = userId,
                Balance = 0.00
            });            
            _unitOfWork.Save();
            return userId;
        }

        public string Login(AuthDTO data, IConfiguration config)
        {
            if (String.IsNullOrEmpty(data.Password))
                throw new Exception("LPassword is required");
            if (String.IsNullOrEmpty(data.Email))
                throw new Exception("Email is required");
            if (!data.Email.Contains("@"))
                throw new Exception("Emmail is not in good forma");

            data.Password = Compute256Hash.ComputeSha256Hash(data.Password);
            var valid = _unitOfWork.User.Find(u => u.Password == data.Password && u.Email == data.Email && u.IsDeleted == 0);

            if (valid.Count() == 1)
            {
                var user = new AuthDTO
                {
                    Id = valid.First().Id,
                    FirstName = valid.First().FirstName,
                    LastName = valid.First().LastName,
                    Email = valid.First().Email
                };
                var token = GenerateToken.GenerateJSONWebToken(user, config);
                return token;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public void Update(AuthDTO entity,int id)
        {
            var user = _unitOfWork.User.Get(id);
            if (!String.IsNullOrEmpty(entity.FirstName))
                user.FirstName = entity.FirstName;
            if (!String.IsNullOrEmpty(entity.LastName))
                user.LastName = entity.LastName;
            if (!String.IsNullOrEmpty(entity.Password))
                user.Password = Compute256Hash.ComputeSha256Hash(entity.Password);
            if (!String.IsNullOrEmpty(entity.Email))
                user.Email = entity.Email;
            if (entity.IsDeleted == 0 || entity.IsDeleted == 1)
                user.IsDeleted = entity.IsDeleted;
            user.ModifiedAt = DateTime.Now;            
            _unitOfWork.Save();
        }
    }
}
