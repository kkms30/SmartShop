using SmartShop.CommunicateToWebService.Clients;
using SmartShopWpf.Models;
using System;
using System.Collections.Generic;

namespace SmartShopWpf.Data
{
    public class TransactionManager
    {
        private DataHandler _data;

        public TransactionManager()
        {
            _data = DataHandler.GetInstance();
        }

        public List<Transaction> GetTransactions()
        {
            return new TransactionClient(_data.Token).GetTransactions();
        }

        public void PrepareNewTransaction()
        {
            Transaction transaction = new Transaction
            {
                CashboxId = _data.Cashbox.IdCashbox,
                CashierId = _data.Cashier.IdCashier,
                Date = DateTime.Now
            };

            TransactionClient transactionClient = new TransactionClient(_data.Token);

            Transaction newTransaction = transactionClient.CreateNew(transaction);

            _data.Transaction = newTransaction;
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
            Order order = new Order
            {
                Product = basket.Product,
                Count = (sbyte) basket.Count,
                Discount = basket.DiscountValue,
                ProductId = basket.Product.IdProduct,
                TransactionId = _data.Transaction.IdTransaction
            };
            _data.Transaction.Orders.Add(order);
        }


        public void FinalizeTransaction()
        {
            TransactionClient transactionClient = new TransactionClient(_data.Token);
            transactionClient.UpdateTransaction(_data.Transaction);
        }
    }
}