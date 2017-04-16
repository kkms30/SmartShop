using SmartShopWebApp.Core.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetOrderWithProducts();
    }
}