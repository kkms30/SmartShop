using Newtonsoft.Json;
using RestSharp;
using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService
{
    public class ProductClient
    {
        private RestClient client;

        public ProductClient()
        {
            client = new RestClient(Endpoint.BASE_URL);
        }

        public List<Product> GetProducts(string token)
        {
            var request = new RestRequest(Endpoint.PRODUCTS, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);

            var response = client.Execute(request);
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(response.Content);

            return products;
        }
    }
}
