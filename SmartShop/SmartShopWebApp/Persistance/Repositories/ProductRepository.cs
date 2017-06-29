using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SmartShopWebApp.Persistance.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }       

        public List<Product> GetProductsWithCategories()
        {
            List<Product> products =  ShopContext.Products.ToList();
            products.ForEach(p =>
            {
                p.Category.SetShouldSerializeProducts(false);
                p.SetShouldSerializeOrders(false);
            });

            return products;
        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}