using SmartShopWebApp.Core.Repositories;
using System;

namespace SmartShopWebApp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IShopRepository Shops { get; }
        ICashboxRepository Cashboxes { get; }
        ITransactionRepository Transactions { get; }
        ICashierRepository Cashiers { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        int Complete();
    }
}