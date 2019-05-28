using Application.DTO;
using Application.Responsens;
using Application.Searches;
using DataAccess;
using Domain;
using Repository.Interfaces;
using System;
using System.Linq;

namespace Repository.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(RestaurantContext context) : base(context) { }
        public void InsertTransaction(int walletId, double amount,string type)
        {
            Context.Add(new Transaction
            {
                Amount = amount,
                WalletID = walletId,
                Type = type
            });            
        }

        public PageResponse<TransactionDTO> Execute(TransactionSearch request)
        {
            var query = Find(t => t.WalletID == request.WalletId);

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

        public RestaurantContext RestaurantContext
        {
            get
            {
                return Context as RestaurantContext;
            }
        }

    }
}
