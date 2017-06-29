using SmartShopWebApp.Core.GeneratedModels;
using System.Collections.Generic;

namespace SmartShopWebApp.Core.Repositories
{
    public interface ICashboxRepository : IRepository<Cashbox>
    {
        List<Cashbox> GetCashboxes();
        Cashbox GetCashboxById(int id);
  
    }
}