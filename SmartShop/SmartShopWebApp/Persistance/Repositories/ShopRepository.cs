using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SmartShopWebApp.Persistance.Repositories
{
    public class ShopRepository : Repository<Shop>, IShopRepository
    {
        public ShopRepository(ShopContext context) : base(context)
        {
        }

        public Shop GetShopWithCashboxes(int id)
        {
            Shop shop = ShopContext.Shops.Include(s => s.Cashboxes).SingleOrDefault(s => s.IdShop == id);
            if (shop != null)
            {
                shop.Cashboxes.ToList().ForEach(c =>
                {
                    c.SetShouldSerializeShop(false);
                    c.SetShouldSerializeTransactions(false);
                });
                return shop;
            }
            return null;
        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}