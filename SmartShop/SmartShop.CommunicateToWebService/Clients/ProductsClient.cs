using System.Collections.Generic;
using SmartShop.CommunicateToWebService.Utils;
using SmartShopWpf.Models;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class ProductsClient : BaseClient<Product>
    {
        public ProductsClient(string token) : base(token, Endpoint.Products)
        {
        }

        public List<Product> GetProducts()
        {
            return base.Get();
        }
    }
}
