using SmartShopWebApp.Core.GeneratedModels;
using System.Collections.Generic;

namespace SmartShopWebApp.Core.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        List<Transaction> GetTransactions();
        Transaction GetTransactionByIdTransaction(int id);
        Transaction GetTransactionById(int id);
        void ModifyWithNewOrders(Transaction transaction);
    }
}