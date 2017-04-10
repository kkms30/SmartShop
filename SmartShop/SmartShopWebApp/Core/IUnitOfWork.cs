using SmartShopWebApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IShopRepository Shops { get; }
        int Complete();
    }
}