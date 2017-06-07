using SmartShop.CommunicateToWebService.Clients;
using SmartShopWpf.Models;
using System;
using System.Collections.Generic;

namespace SmartShopWpf.Data
{
    internal class OrderManager
    {
        private DataHandler data;

        public OrderManager()
        {
            data = DataHandler.GetInstance();
        }

        public List<Order> GetOrders()
        {
            return new OrderClient(data.Token).GetOrders();
        }
    }
}