using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Core.GeneratedModels
{
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {
        private bool _shouldSerializeProducts = true;

        public void SetShouldSerializeProducts(bool should)
        {
            _shouldSerializeProducts = should;
        }

        public bool ShouldSerializeProducts()
        {
            return _shouldSerializeProducts;
        }
    }

    public class CategoryMetaData
    {
        [JsonProperty(Order = 1)]
        public int IdCategory { get; set; }
        [JsonProperty(Order = 2)]
        public string Name { get; set; }

        [JsonProperty(Order = 3)]
        public virtual ICollection<Product> Products { get; set; }
    }
}