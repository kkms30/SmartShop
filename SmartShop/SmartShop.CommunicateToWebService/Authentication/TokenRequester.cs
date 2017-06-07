using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService.Authentication
{
    public class TokenRequester
    {
        public static string ReuqestToken(string id, string password)
        {
            var request = new RestRequest(Endpoint.TOKEN, Method.POST);
            string encodedBody = string.Format("grant_type=password&username={0}&password={1}",
                id, password);

            request.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);
            request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);

            var response = new RestClient(Endpoint.BASE_URL).Execute<ApiAuthenticationResponse>(request);

            Console.WriteLine(response.Data.access_token);

            return response.Data.access_token;
        }
    }
}
