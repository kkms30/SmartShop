using SmartShop.CommunicateToWebService.Clients;
using System.Collections.Generic;
using SmartShop.Models.Models;

namespace SmartShopWpf.Data
{
    public class OrderManager
    {
        private DataHandler _data;

        public OrderManager()
        {
            _data = DataHandler.GetInstance();
        }

        public List<Order> GetOrders()
        {
            return new OrderClient(_data.Token).GetOrders();
        }
    }
}