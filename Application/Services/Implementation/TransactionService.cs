using Application.DTO;
using Application.Services.Interfaces;
using Domain;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Delete(TransactionDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TransactionDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public TransactionDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(TransactionDTO entity)
        {
            var transaction = new Transaction
            {
                Amount = entity.Amount,
                WalletID = entity.WalletId,
                Type = entity.Type
            };
            _unitOfWork.Transaction.Add(transaction);
            return transaction.Id;
        }

        public void Update(TransactionDTO entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
