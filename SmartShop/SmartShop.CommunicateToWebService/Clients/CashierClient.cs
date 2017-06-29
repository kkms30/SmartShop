using SmartShop.CommunicateToWebService.Utils;
using SmartShopWpf.Models;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class CashierClient : BaseClient<Cashier>
    {
        public CashierClient(string token) : base(token, Endpoint.Cashier) { }

        public Cashier Login(string id)
        {
            return base.Get(id);
        }
    }
}
