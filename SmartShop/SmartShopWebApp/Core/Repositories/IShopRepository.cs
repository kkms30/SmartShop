using SmartShopWebApp.Core.GeneratedModels;

namespace SmartShopWebApp.Core.Repositories
{
    public interface IShopRepository : IRepository<Shop>
    {
        Shop GetShopWithCashboxes(int id);
    }
}