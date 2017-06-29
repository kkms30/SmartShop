using SmartShopWebApp.Core.GeneratedModels;
using System.Collections.Generic;   

namespace SmartShopWebApp.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductsWithCategories();
    }
}