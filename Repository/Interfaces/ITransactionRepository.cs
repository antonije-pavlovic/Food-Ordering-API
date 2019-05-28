using Application.DTO;
using Application.Responsens;
using Application.Searches;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface ITransactionRepository: IRepository<Transaction>,ICommand<TransactionSearch, PageResponse<TransactionDTO>>
    {
        void InsertTransaction(int walletId, double amount,string type);
    }
}
