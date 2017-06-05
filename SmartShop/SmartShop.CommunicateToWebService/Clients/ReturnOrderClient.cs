using SmartShopWebApp.Persistance.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class ReturnOrderClient : BaseClient<ReturnOrder>
    {
        public ReturnOrderClient(string token) : base(token, Endpoint.RETURN_ORDER)
        {
        }

        public void ReturnOrder(ReturnOrder returnOrder)
        {
            base.Put(returnOrder.IdOrder, returnOrder);
        }
    }
}
