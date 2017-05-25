using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class CashierClient : BaseClient<Cashier>
    {
        public CashierClient(string token) : base(token, Endpoint.CASHIER) { }

        public Cashier Login(string id)
        {
            return base.Get(id);
        }
    }
}
