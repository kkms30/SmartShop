using System.Collections.Generic;
using SmartShop.CommunicateToWebService.Clients;
using SmartShop.CommunicateToWebService.Authentication;
using SmartShop.Models.Models;

namespace PluginLogIn
{
    public class LogIn : ILogIn
    {
        public bool CheckLoginData(string id, string password, ref ProductsClient productsClient, ref CashierClient cashierClient, ref Cashier cashier, ref List<Product> products, ref string token)
        {
            token = TokenRequester.ReuqestToken(id, password);
            bool result = false;
            if (token != null)
            {
                cashierClient = new CashierClient(token);
                productsClient = new ProductsClient(token);

                cashier = cashierClient.Login(id);
                products = productsClient.GetProducts();
                result = true;
            }else { result = false; }

            if (cashier != null && products.Count > 0 && result)
            {
                result = true;;
            }else { result = false; }
            return result;
        }
    }
}
