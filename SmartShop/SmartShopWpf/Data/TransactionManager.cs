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

        public void AddOrdersToTransaction(List<Basket> basketsList)
        {
            foreach (Basket basket in basketsList)
            {
                AddNewOrderToTransaction(basket);
            }
        }

        public void AddNewOrderToTransaction(Basket basket)
        {
            Order order = new Order();
            order.Product = basket.Product;
            order.Count = (sbyte)basket.Count;
            order.Discount = basket.DiscountValue;
            order.ProductId = basket.Product.IdProduct;
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