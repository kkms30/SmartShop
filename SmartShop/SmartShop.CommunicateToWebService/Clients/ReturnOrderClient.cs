using SmartShop.CommunicateToWebService.Utils;
using SmartShopWebApp.Persistance.Mappers;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class ReturnOrderClient : BaseClient<ReturnOrder>
    {
        public ReturnOrderClient(string token) : base(token, Endpoint.ReturnOrder)
        {
        }

        public void ReturnOrder(ReturnOrder returnOrder)
        {
            base.Put(returnOrder.IdOrder, returnOrder);
        }
    }
}