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
            get { return context as ShopContext; }
        }
    }
}