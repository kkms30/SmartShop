using System.Collections.Generic;
using SmartShop.CommunicateToWebService.Utils;
using SmartShop.Models.Models;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class TransactionClient : BaseClient<Transaction>
    {
        public TransactionClient(string token) : base(token, Endpoint.Transaction) { }

        public Transaction CreateNew(Transaction transaction)
        {
            return base.Post(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            base.Put(transaction.IdTransaction, transaction);
        }

        public List<Transaction> GetTransactions()
        {
            return base.Get();
        }
    }
}
