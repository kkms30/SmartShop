using SmartShop.CommunicateToWebService;
using SmartShop.CommunicateToWebService.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Models.Models;

namespace PluginLogIn
{
    public interface ILogIn
    {
        bool CheckLoginData(string id, string password,ref ProductsClient productsClient,
            ref CashierClient cashierClient,ref Cashier cashier,ref List<Product> products, ref string token);
    }
}
