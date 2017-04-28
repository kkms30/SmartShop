﻿using SmartShopWebApp.Core.GeneratedModels;
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
            get { return context as ShopContext; }
        }

        public Cashbox GetCashboxByIdCashbox(int id)
        {
            Cashbox cashbox = Find(c => c.IdCashbox == id).FirstOrDefault();
            SetSerialization(cashbox);
            return cashbox;
        }

        public List<Cashbox> GetCashboxes()
        {
            List<Cashbox> cashboxes = GetAll().ToList();
            cashboxes.ForEach(c =>
            {
                SetSerialization(c);
            });
            return cashboxes;
        }

        private void SetSerialization(Cashbox cashbox)
        {
            cashbox.SetShouldSerializeTransactions(false);
            cashbox.Shop.SetShouldSerializeCashboxes(false);
        }
    }
}