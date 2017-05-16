using SmartShopWebApp.Core.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Core.Repositories
{
    public interface ICashierRepository : IRepository<Cashier>
    {
        List<Cashier> GetCashiers();
        Cashier GetCashierByCredentials(string id, string password);
    }
}