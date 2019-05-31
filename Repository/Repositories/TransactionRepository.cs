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
