using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartShopWebApp.Core.GeneratedModels
{
    [MetadataType(typeof(ShopMetaData))]
    public partial class Shop
    {
        private bool _shouldSerializeCashboxes = true;

        public void SetShouldSerializeCashboxes(bool should)
        {
            _shouldSerializeCashboxes = should;
        }
        public bool ShouldSerializeCashboxes()
        {
            return _shouldSerializeCashboxes;
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