using SmartShop.CommunicateToWebService.Clients;
using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartShopWpf.Data
{
    public class TransactionManager
    {
        DataHandler data;
        public TransactionManager()
        {
            data = DataHandler.GetInstance();
        }

        public List<Transaction> GetTransactions()
        {
            return new TransactionClient(data.Token).GetTransactions();
        }

        public void PrepareNewTransaction()
        {
            Transaction transaction = new Transaction();
            transaction.CashboxId = data.Cashbox.IdCashbox;
            transaction.CashierId = data.Cashier.IdCashier;

            TransactionClient transactionClient = new TransactionClient(data.Token);

            Transaction newTransaction = transactionClient.CreateNew(transaction);

            data.Transaction = newTransaction;

        }

        public void AddNewOrderToTransaction(Product product, int count)
        {
            Order order = new Order();
            order.Product = product;
            order.Count = (sbyte) count;
            order.ProductId = product.IdProduct;

            order.TransactionId = data.Transaction.IdTransaction;
            data.Transaction.Orders.Add(order);      
                  
        }

        public void FinalizeTransaction()
        {

                TransactionClient transactionClient = new TransactionClient(data.Token);
                transactionClient.UpdateTransaction(data.Transaction);

        }
    }
}
