using System.Collections.Generic;
using SmartShop.CommunicateToWebService.Utils;
using SmartShop.Models.Models;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class OrderClient : BaseClient<Order>
    {
        public OrderClient(string token) : base(token, Endpoint.Order)
        {
        }

        public List<Order> GetOrders()
        {
            return base.Get();
        }
    }
}