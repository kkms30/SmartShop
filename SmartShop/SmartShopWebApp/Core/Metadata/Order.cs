using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Core.GeneratedModels
{
    [MetadataType(typeof(OrderMetaData))]
    public partial class Order
    {
        private bool shouldSerializeProduct = true;
        private bool shouldSerializeTransaction = true;

        public void SetShouldSerializeProduct(bool should)
        {
            shouldSerializeProduct = should;
        }

        public void SetShouldSerializeTransaction(bool should)
        {
            shouldSerializeTransaction = should;
        }

        public bool ShouldSerializeProduct()
        {
            return shouldSerializeProduct;
        }

        public bool ShouldSerializeTransaction()
        {
            return shouldSerializeTransaction;
        }
    }

    public class OrderMetaData
    {
        [JsonProperty(Order = 1)]
        public int IdOrder { get; set; }
        [JsonProperty(Order = 2)]
        public sbyte Return { get; set; }
        [JsonProperty(Order = 3)]
        public sbyte Count { get; set; }
        [JsonProperty(Order = 4)]
        public Nullable<float> Discount { get; set; }
        [JsonProperty(Order = 5)]
        public int ProductId { get; set; }

        [JsonProperty(Order = 6)]
        public virtual Product Product { get; set; }
        [JsonProperty(Order = 7)]
        public virtual Transaction Transaction { get; set; }

    }
}