using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService.Clients
{
    public abstract class BaseClient<T>
    {
        private RestClient client;
        private string endpoint;

        protected BaseClient(string endpoint)
        {
            client = new RestClient(Endpoint.BASE_URL);
            this.endpoint = endpoint;
        }

        protected List<T> Get(string token)
        {
            var request = new RestRequest(endpoint, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);

            var response = client.Execute(request);
            List<T> items = JsonConvert.DeserializeObject<List<T>>(response.Content);

            return items;
        }
    }
}
