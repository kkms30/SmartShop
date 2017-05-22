using Newtonsoft.Json;
using RestSharp;
using SmartShop.CommunicateToWebService.Clients;
using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService
{
    public class ProductsClient : BaseClient<Product>
    {
        public ProductsClient() : base(Endpoint.PRODUCTS)
        {
        }

        public List<Product> GetProducts(string token)
        {
            return base.Get(token);
        }
    }
}
