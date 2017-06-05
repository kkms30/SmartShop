using SmartShopWpf.Models;
using System.Collections.Generic;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class OrderClient : BaseClient<Order>
    {
        public OrderClient(string token) : base(token, Endpoint.ORDER)
        {
        }

        public List<Order> GetOrders()
        {
            return base.Get();
        }
    }
}