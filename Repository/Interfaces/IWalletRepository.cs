using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IWalletRepository: IRepository<Wallet>
    {
        void CreateWallet(int id);
        double InsertMoney(double amount, int userId);
    }
}
