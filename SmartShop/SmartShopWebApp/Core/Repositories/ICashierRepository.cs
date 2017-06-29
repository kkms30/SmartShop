using SmartShopWebApp.Core.GeneratedModels;
using System.Collections.Generic;

namespace SmartShopWebApp.Core.Repositories
{
    public interface ICashierRepository : IRepository<Cashier>
    {
        Cashier GetCashierById(string id);
        List<Cashier> GetCashiers();
        Cashier GetCashierByCredentials(string id, string password);

    }
}