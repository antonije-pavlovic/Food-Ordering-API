using Application.DTO;
using Application.Services.Interfaces;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services.Implementation
{
    public class WalletService : IWalletService
    {
        private IUnitOfWork _unitOfWork;
        private ITransactionService _transactionService;
        public WalletService(IUnitOfWork unitOfWork, ITransactionService transactionService)
        {
            _unitOfWork = unitOfWork;
            _transactionService = transactionService;
        }
        public void Delete(WalletDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<WalletDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public WalletDTO GetById(int id)
        {
            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == id).FirstOrDefault();
            return new WalletDTO
            {
                Balance = wallet.Balance
            };
        }

        public int Insert(WalletDTO entity)
        {
            throw new NotImplementedException();
        }

        public double InsertTransaction(WalletDTO dto, int id)
        {            
            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == id).FirstOrDefault();
            wallet.Balance += dto.Balance;
            _transactionService.Insert(new TransactionDTO
            {
                Amount = dto.Balance,
                WalletId = wallet.Id,
                Type = "income"
            });
            _unitOfWork.Save();
            return wallet.Balance;
        }

        public void Update(WalletDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
