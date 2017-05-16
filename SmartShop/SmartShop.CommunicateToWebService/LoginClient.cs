using RestSharp;
using RestSharp.Authenticators;
using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService
{
    public class LoginClient
    {
        private RestClient client;

        public LoginClient()
        {
            client = new RestClient(Endpoint.BASE_URL);
        }

        public Cashier Login(string id, string token)
        {
            var request = new RestRequest(Endpoint.LOGIN + id, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);
            
            var response = client.Execute<Cashier>(request);
            Console.WriteLine(response.Data.Name);

            return response.Data;
        }

        public string GetToken(string id, string password)
        {          
            var request = new RestRequest(Endpoint.TOKEN, Method.POST);
            string encodedBody = string.Format("grant_type=password&username={0}&password={1}",
                id, password);

            request.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);
            request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);
            
            var response = client.Execute<ApiAuthenticationResponse>(request);
            Console.WriteLine(response.Data.access_token);

            return response.Data.access_token;
        }
    }
}
