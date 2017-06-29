using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Core.Repositories;
using System.Data.Entity;

namespace SmartShopWebApp.Persistance.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}