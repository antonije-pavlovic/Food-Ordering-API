using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface ITransactionRepository: IRepository<Transaction>
    {
        void InsertTransaction(int walletId, double amount,string type);
    }
}
