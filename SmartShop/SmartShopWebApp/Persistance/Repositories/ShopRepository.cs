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
        public ShopRepository(ShopEntities context) : base(context)
        {
        }

        public Shop GetShopWithCashboxes(int id)
        {
            Shop shop = ShopEntities.Shops.Include(s => s.Cashboxs).SingleOrDefault(s => s.IdShop == id);
            //List<Cashbox> cashboxes = shop.Cashboxs.ToList();
            //cashboxes.ForEach(c => { c.Shop = null; c.Transactions = null; });
            //shop.Cashboxs = cashboxes;
            return shop;
        }



        public ShopEntities ShopEntities
        {
            get { return context as ShopEntities;  }
        }
    }
}