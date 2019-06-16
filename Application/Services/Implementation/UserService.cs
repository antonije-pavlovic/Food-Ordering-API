using Application.DTO;
using Application.Mailer;
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
        private readonly IMailer _mailer;
        public UserService(IUnitOfWork unitOfWork, IMailer mailer)
        {
            _unitOfWork = unitOfWork;
            _mailer = mailer;
        }

        public void Delete(UpdateUserDTO entity)
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

        public IQueryable<UserDTO> GetAll()
        {
           var users = _unitOfWork.User.GetAll().Select(u => new UserDTO
           {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                isDeleted = u.IsDeleted,
                RoleId = u.RoleId                
            });
            return users;
        }        

        public UserDTO GetById(int id)
        {
           var user = _unitOfWork.User.Find(u => u.Id == id).Select(u => new UserDTO
           {
               Id = u.Id,
               FirstName = u.FirstName,
               LastName = u.LastName,
               Email = u.Email,
               isDeleted = u.IsDeleted,
               RoleId = u.RoleId
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

        public int Insert(UpdateUserDTO data)
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
                RoleId = 2
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

        public string Login(LoginDTO data, IConfiguration config)
        {
            if (String.IsNullOrEmpty(data.Email))
            {
                throw new Exception("Email field is required!");
            }

            if (String.IsNullOrEmpty(data.Password))
            {
                throw new Exception("Password field is required!");
            }

            if (!data.Email.Contains("@"))
            {
                throw new Exception("Enter valid email!");
            }
            data.Password = Compute256Hash.ComputeSha256Hash(data.Password);
            var valid = _unitOfWork.User.Find(u => u.Password == data.Password && u.Email == data.Email && u.IsDeleted == 0).FirstOrDefault();

            if (valid != null)
            {
                var token = GenerateToken.GenerateJSONWebToken(valid, config);
                return token;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public int Register(RegisterDTO data)
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
                RoleId = 2
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

        public void SendMail(MailDTO dto, int id)
        {
            _mailer.SendMail(dto.Subject, dto.Body, id);
        }

        public void Update(UpdateUserDTO entity,int id)
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
            if (entity.RoleId == 1 || entity.RoleId == 2)
                user.RoleId = entity.RoleId;
            user.ModifiedAt = DateTime.Now;            
            _unitOfWork.Save();
        }       
    }
}
