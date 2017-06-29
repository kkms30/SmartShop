using SmartShop.CommunicateToWebService.Clients;
using System.Collections.Generic;
using SmartShop.Models.Models;

namespace PluginLogIn
{
    public interface ILogIn
    {
        bool CheckLoginData(string id, string password,ref ProductsClient productsClient,
            ref CashierClient cashierClient,ref Cashier cashier,ref List<Product> products, ref string token);
    }
}
