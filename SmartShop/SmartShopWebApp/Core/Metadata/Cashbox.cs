using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Core.GeneratedModels
{
    [MetadataType(typeof(CashboxMetaData))]
    public partial class Cashbox
    {
        private bool shouldSerializeShop = true;
        private bool shouldSerializeTransactions = true;

        public void SetShouldSerializeShop(bool should)
        {
            shouldSerializeShop = should;
        }

        public void SetShouldSerializeTransactions(bool should)
        {
            shouldSerializeTransactions = should;
        }

        public bool ShouldSerializeShop()
        {
            return shouldSerializeShop;
        }

        public bool ShouldSerializeTransactions()
        {
            return shouldSerializeTransactions;
        }
    }

    public class CashboxMetaData
    {
        [JsonProperty(Order = 1)]
        public int IdCashbox { get; set; }
        [JsonProperty(Order = 2)]
        public int Id { get; set; }
        [JsonProperty(Order = 3)]
        public int ShopId { get; set; }

        [JsonProperty(Order = 4)]
        public virtual Shop Shop { get; set; }
        [JsonProperty(Order = 5)]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}