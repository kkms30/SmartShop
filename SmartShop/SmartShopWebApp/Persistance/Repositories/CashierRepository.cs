using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SmartShopWebApp.Persistance.Repositories
{
    public class CashierRepository : Repository<Cashier>, ICashierRepository
    {
        public CashierRepository(DbContext context) : base(context)
        {
        }
        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        public Cashier GetCashierById(string id)
        {
            Cashier cashier = Find(c => c.Id == id).FirstOrDefault();
            if (cashier != null)
            {
                cashier.SetShouldSerializeTransactions(false);
            }
            return cashier;
        }

        public List<Cashier> GetCashiers()
        {
            List<Cashier> cashiers = GetAll().ToList();
            cashiers.ForEach(c => c.SetShouldSerializeTransactions(false));
            return cashiers;
        }

        public Cashier GetCashierByCredentials(string id, string password)
        {
            Cashier cashier = Find(c => c.Id == id && c.Password == password).FirstOrDefault();
            return cashier;
        }
    }   
}