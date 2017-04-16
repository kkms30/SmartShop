using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Core.GeneratedModels
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
        private bool shouldSerializeCategory = true;
        private bool shouldSerializeOrders = true;

        public void SetShouldSerializeCategory(bool should)
        {
            shouldSerializeCategory = should;
        }
        public void SetShouldSerializeOrders(bool should)
        {
            shouldSerializeOrders = should;
        }
        public bool ShouldSerializeCategory()
        {
            return shouldSerializeCategory;
        }
        public bool ShouldSerializeOrders()
        {
            return shouldSerializeOrders;
        }
    }

    public class ProductMetaData
    {
        [JsonProperty(Order = 1)]
        public int IdProduct { get; set; }
        [JsonProperty(Order = 2)]
        public string Name { get; set; }
        [JsonProperty(Order = 3)]
        public string Code { get; set; }
        [JsonProperty(Order = 4)]
        public float Price { get; set; }
        [JsonProperty(Order = 5)]
        public byte[] Image { get; set; }
        [JsonProperty(Order = 6)]
        public int CategoryId { get; set; }

        [JsonProperty(Order = 7)]
        public virtual Category Category { get; set; }
        [JsonProperty(Order = 8)]
        public virtual ICollection<Order> Orders { get; set; }
    }
}