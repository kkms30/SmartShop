using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SmartShopWebApp.Persistance.Repositories
{
    public class CashboxRepository : Repository<Cashbox>, ICashboxRepository
    {
        public CashboxRepository(ShopContext context) : base(context)
        {
        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        public Cashbox GetCashboxById(int id)
        {
            Cashbox cashbox = Find(c => c.Id == id).FirstOrDefault();
            SetSerialization(cashbox);
            return cashbox;
        }

        public List<Cashbox> GetCashboxes()
        {
            List<Cashbox> cashboxes = GetAll().ToList();
            cashboxes.ForEach(SetSerialization);
            return cashboxes;
        }

        private void SetSerialization(Cashbox cashbox)
        {
            cashbox.SetShouldSerializeTransactions(false);
            cashbox.Shop.SetShouldSerializeCashboxes(false);
        }
    }
}