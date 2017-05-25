using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class TransactionClient : BaseClient<Transaction>
    {
        public TransactionClient(string token) : base(token, Endpoint.TRANSACTION) { }

        public Transaction CreateNew(Transaction transaction)
        {
            return base.Post(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            base.Put(transaction.IdTransaction, transaction);
        }
    }
}
