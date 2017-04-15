using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SmartShopWebApp.Persistance.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }
        public ShopContext ShopContext
        {
            get { return context as ShopContext; }
        }

        public List<Order> GetOrderWithProducts()
        {
            List<Order> orders = ShopContext.Orders.ToList();
            orders.ForEach(o =>
            {
                o.SetShouldSerializeTransaction(false);
                o.Product.SetShouldSerializeOrders(false);
                o.Product.Category.SetShouldSerializeProducts(false);
            });
            return orders;
        }
    }   
}