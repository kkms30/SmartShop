using SmartShopWebApp.Core;
using SmartShopWebApp.Core.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartShopWebApp.Core.Repositories;
using SmartShopWebApp.Persistance.Repositories;

namespace SmartShopWebApp.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopEntities context;


        public UnitOfWork(ShopEntities context)
        {
            this.context = context;
            Shops = new ShopRepository(context);
        }

        public IShopRepository Shops { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}