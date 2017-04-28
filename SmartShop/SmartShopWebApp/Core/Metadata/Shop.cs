using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Core.GeneratedModels
{
    [MetadataType(typeof(ShopMetaData))]
    public partial class Shop
    {
        private bool shouldSerializeCashboxes = true;

        public void SetShouldSerializeCashboxes(bool should)
        {
            shouldSerializeCashboxes = should;
        }
        public bool ShouldSerializeCashboxes()
        {
            return shouldSerializeCashboxes;
        }
    }

    public class ShopMetaData
    {
        [JsonProperty(Order = 1)]
        public int IdShop { get; set; }
        [JsonProperty(Order = 2)]
        public string Name { get; set; }
        [JsonProperty(Order = 3)]
        public string Address { get; set; }

        [JsonProperty(Order = 4)]
        public virtual ICollection<Cashbox> Cashboxes { get; set; }
    }
}