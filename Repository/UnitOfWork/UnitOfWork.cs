using DataAccess;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantContext _context;
         public UnitOfWork(RestaurantContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Category = new CategoryRepository(_context);
            Dish = new DishRepository(_context);
            Wallet = new WalletRepository(_context);
            Transaction = new TransactionRepository(_context);
        }

        public IUserRepository User { get; private set; }
        public ICategoryRepository Category { get; private set; }

        public IDishRepository Dish { get; private set; }

        public IWalletRepository Wallet { get; private set; }

        public ITransactionRepository Transaction { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
