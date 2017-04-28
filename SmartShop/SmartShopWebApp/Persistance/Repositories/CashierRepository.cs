﻿using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            get { return context as ShopContext; }
        }

        public List<Cashier> GetCashiers()
        {
            List<Cashier> cashiers = GetAll().ToList();
            cashiers.ForEach(c => c.SetShouldSerializeTransactions(false));
            return cashiers;
        }
    }   
}