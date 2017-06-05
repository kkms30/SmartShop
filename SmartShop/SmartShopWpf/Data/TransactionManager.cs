using SmartShop.CommunicateToWebService.Clients;
using SmartShopWpf.Models;
using System;
using System.Collections.Generic;

namespace SmartShopWpf.Data
{
    public class TransactionManager
    {
        private DataHandler data;

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
            transaction.Date = DateTime.Now;

            TransactionClient transactionClient = new TransactionClient(data.Token);

            Transaction newTransaction = transactionClient.CreateNew(transaction);

            data.Transaction = newTransaction;
        }

        public void AddNewOrderToTransaction(Product product, int count, float discount)
        {
            Order order = new Order();
            order.Product = product;
            order.Count = (sbyte)count;
            order.ProductId = product.IdProduct;
            order.Discount = discount;

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