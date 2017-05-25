﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService.Clients
{
    public abstract class BaseClient<T>
    {
        private RestClient client;
        private string endpoint;
        private string token;

        protected BaseClient(string token, string endpoint)
        {
            client = new RestClient(Endpoint.BASE_URL);

            this.token = token;
            this.endpoint = endpoint;
        }

        protected List<T> Get()
        {
            var request = new RestRequest(endpoint, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);

            var response = client.Execute(request);
            List<T> items = JsonConvert.DeserializeObject<List<T>>(response.Content);

            return items;
        }

        protected T Get(string id)
        {
            var request = new RestRequest(endpoint + id, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);

            var response = client.Execute(request);
            T item = JsonConvert.DeserializeObject<T>(response.Content);

            return item;
        }

        protected T Post(T item)
        {
            var request = new RestRequest(endpoint, Method.POST);
            var json = JsonConvert.SerializeObject(item);

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);

            var response = client.Execute(request);
            T itemReturned = JsonConvert.DeserializeObject<T>(response.Content);

            Console.WriteLine();

            return itemReturned;
        }

        protected void Put(int id, T item)
        {
            var request = new RestRequest(endpoint + id, Method.PUT);
            var json = JsonConvert.SerializeObject(item);

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);

            var response = client.Execute(request);

            /*eturn response.Content == HttpStatusCode.NoContent ? true : false;*/


        }
    }
}
