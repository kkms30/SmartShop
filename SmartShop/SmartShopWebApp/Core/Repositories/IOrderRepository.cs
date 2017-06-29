using SmartShopWebApp.Core.GeneratedModels;
using System.Collections.Generic;

namespace SmartShopWebApp.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetOrderWithProducts();
    }
}