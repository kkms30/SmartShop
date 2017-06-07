using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.CommunicateToWebService;
using SmartShop.CommunicateToWebService.Clients;
using SmartShopWpf.Models;
using SmartShop.CommunicateToWebService.Authentication;

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
                result = true;
                //InitAppData(cashier, products, token);

                //MainWindow mW = new MainWindow(false);
                //mW.Show();
                //this.Close();
            }else { result = false; }
            return result;
        }
    }
}
