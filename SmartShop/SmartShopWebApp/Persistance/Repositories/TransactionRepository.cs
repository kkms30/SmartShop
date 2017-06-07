using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;

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

        public Transaction GetTransactionById(int id)
        {
            Transaction transaction2 = ShopContext.Transactions.Include(t => t.Cashbox).Include(t => t.Cashier).Where(t => t.Id == id).FirstOrDefault();

            Transaction transaction = Find(t => t.Id == id).FirstOrDefault();
            if (transaction2 == null)
            {
                return null;
            }
            
            SetSerialization(transaction2);
            return transaction2;
        }

        public override void Add(Transaction transaction)
        {
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

        public void ModifyWithNewOrders(Transaction transaction)
        {
            Transaction oldTransaction = GetTransactionById(transaction.Id);

            Task changeStates = Task.Factory.StartNew(() =>
            {

                transaction.Orders.ToList().ForEach(o =>
                {
                    oldTransaction.Orders.Add(o);

                    Category currentCategory = ShopContext.Categories.Find(o.Product.CategoryId);
                    ShopContext.Entry(currentCategory).State = EntityState.Unchanged;

                    Product currentProduct = ShopContext.Products.Find(o.ProductId);
                    ShopContext.Entry(currentProduct).State = EntityState.Unchanged;

                });
            });

            changeStates.Wait();

            oldTransaction.TotalPrice = transaction.TotalPrice;

            base.Modify(oldTransaction);
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