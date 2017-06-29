using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using SmartShop.CommunicateToWebService.Utils;

namespace SmartShop.CommunicateToWebService.Clients
{
    public abstract class BaseClient<T>
    {
        private RestClient _client;
        private string _endpoint;
        private string _token;

        protected BaseClient(string token, string endpoint)
        {
            _client = new RestClient(Endpoint.BaseUrl);
            _token = token;
            _endpoint = endpoint;
        }

        protected List<T> Get()
        {
            var request = new RestRequest(_endpoint, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddParameter("Authorization", "Bearer " + _token, ParameterType.HttpHeader);

            var response = _client.Execute(request);
            List<T> items = JsonConvert.DeserializeObject<List<T>>(response.Content);

            return items;
        }

        protected T Get(string id)
        {
            var request = new RestRequest(_endpoint + id, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddParameter("Authorization", "Bearer " + _token, ParameterType.HttpHeader);

            var response = _client.Execute(request);
            T item = JsonConvert.DeserializeObject<T>(response.Content);

            return item;
        }

        protected T Post(T item)
        {
            var request = new RestRequest(_endpoint, Method.POST);
            var json = JsonConvert.SerializeObject(item);

            Trace.WriteLine(json);

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.AddParameter("Authorization", "Bearer " + _token, ParameterType.HttpHeader);

            var response = _client.Execute(request);
            T itemReturned = JsonConvert.DeserializeObject<T>(response.Content);

            Console.WriteLine();

            return itemReturned;
        }

        protected void Put(int id, T item)
        {
            var request = new RestRequest(_endpoint + id, Method.PUT);
            var json = JsonConvert.SerializeObject(item);

            Trace.WriteLine(json);

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.AddParameter("Authorization", "Bearer " + _token, ParameterType.HttpHeader);

            var response = _client.Execute(request);
            Trace.WriteLine(response.Content);
        }
    }
}