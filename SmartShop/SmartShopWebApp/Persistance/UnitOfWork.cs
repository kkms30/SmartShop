﻿using SmartShopWebApp.Core;
using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Core.Repositories;
using SmartShopWebApp.Persistance.Repositories;

namespace SmartShopWebApp.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _context;
        
        public UnitOfWork(ShopContext context)
        {
            _context = context;
            Shops = new ShopRepository(context);
            Cashboxes = new CashboxRepository(context);
            Transactions = new TransactionRepository(context);
            Cashiers = new CashierRepository(context);
            Orders = new OrderRepository(context);
            Products = new ProductRepository(context);
            Categories = new CategoryRepository(context);      
        }

        public IShopRepository Shops { get; private set; }
        public ICashboxRepository Cashboxes { get; private set; }
        public ITransactionRepository Transactions { get; private set; }
        public ICashierRepository Cashiers { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}