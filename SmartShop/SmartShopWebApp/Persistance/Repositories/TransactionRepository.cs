using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SmartShopWebApp.Persistance.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DbContext context) : base(context)
        {
        }
        public ShopContext ShopContext
        {
            get { return context as ShopContext; }
        }

        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactions = GetAll().ToList();
            transactions.ForEach(t => SetSerialization(t));
            return transactions;
        }

        public Transaction GetTransactionByIdTransaction(int idTransaction)
        {
            Transaction transaction = Get(idTransaction);
            SetSerialization(transaction);
            return transaction;
        }

        public Transaction GetTransactionById(int idTransaction)
        {
            Transaction transaction = Find(t => t.IdTransaction == idTransaction).FirstOrDefault();
            if (transaction == null)
            {
                return null;
            }
            SetSerialization(transaction);
            return transaction;
        }

        public override void Add(Transaction transaction)
        {
            ShopContext.Cashboxes.Attach(transaction.Cashbox);
            ShopContext.Cashiers.Attach(transaction.Cashier);
            ShopContext.Shops.Attach(transaction.Cashbox.Shop);
            transaction.Orders.ToList().ForEach(o =>
            {
                ShopContext.Products.Attach(o.Product);
                ShopContext.Categories.Attach(o.Product.Category);
            });
            ShopContext.Transactions.Add(transaction);
        }

        public override void Modify(Transaction transaction)
        {
            base.Modify(transaction);
            transaction.Orders.ToList().ForEach(o =>
            {
                new OrderRepository(ShopContext).Modify(o);
            });
        }


        private void SetSerialization(Transaction transaction)
        {
            transaction.Cashbox.SetShouldSerializeTransactions(false);
            transaction.Cashbox.Shop.SetShouldSerializeCashboxes(false);
            transaction.Cashier.SetShouldSerializeTransactions(false);

            transaction.Orders.ToList().ForEach(o =>
            {
                o.SetShouldSerializeTransaction(false);
                o.Product.SetShouldSerializeOrders(false);
                o.Product.Category.SetShouldSerializeProducts(false);
            });
        }
    }
}