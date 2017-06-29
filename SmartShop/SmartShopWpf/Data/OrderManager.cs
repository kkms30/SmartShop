using SmartShop.CommunicateToWebService.Clients;
using SmartShopWpf.Models;
using System.Collections.Generic;

namespace SmartShopWpf.Data
{
    internal class OrderManager
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