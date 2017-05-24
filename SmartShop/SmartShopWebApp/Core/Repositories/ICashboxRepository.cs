﻿using SmartShopWebApp.Core.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Core.Repositories
{
    public interface ICashboxRepository : IRepository<Cashbox>
    {
        List<Cashbox> GetCashboxes();
        Cashbox GetCashboxById(int id);
  
    }
}