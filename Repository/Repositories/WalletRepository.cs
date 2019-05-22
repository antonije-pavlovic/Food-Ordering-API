using DataAccess;
using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class WalletRepository: Repository<Wallet>,IWalletRepository
    {
        public WalletRepository(RestaurantContext context) : base(context) { }

        public void CreateWallet(int id)
        {
            Context.Add(new Wallet
            {
                UserId = id,
                Balance = 0.00
            });
        }

        public double InsertMoney(double amount, int userId)
        {
            var wallet = Find(w => w.UserId == userId).FirstOrDefault();
            wallet.Balance = wallet.Balance + amount;
            return wallet.Balance;
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
