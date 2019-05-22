using DataAccess;
using Domain;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(RestaurantContext context) : base(context) { }
        public void InsertTransaction(int walletId, double amount)
        {
            Context.Add(new Transaction
            {
                Amount = amount,
                WalletID = walletId,
                Type = "incoming"
            });            
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
