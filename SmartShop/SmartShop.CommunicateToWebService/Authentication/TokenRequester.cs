using RestSharp;
using System;
using SmartShop.CommunicateToWebService.Utils;

namespace SmartShop.CommunicateToWebService.Authentication
{
    public class TokenRequester
    {
        public static string ReuqestToken(string id, string password)
        {
            var request = new RestRequest(Endpoint.Token, Method.POST);
            string encodedBody = $"grant_type=password&username={id}&password={password}";

            request.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);
            request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);

            var response = new RestClient(Endpoint.BaseUrl).Execute<ApiAuthenticationResponse>(request);

            Console.WriteLine(response.Data.AccessToken);

            return response.Data.AccessToken;
        }
    }
}