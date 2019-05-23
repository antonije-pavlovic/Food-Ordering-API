using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository User { get; }
        ICategoryRepository Category { get; }
        IDishRepository Dish { get; }
        IWalletRepository Wallet { get; }
        ITransactionRepository Transaction { get; }
        ICartRepository Cart { get; }
        void Save();
    }
}
