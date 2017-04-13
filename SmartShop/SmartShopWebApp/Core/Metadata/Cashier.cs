using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Core.GeneratedModels
{
    [MetadataType(typeof(CashierMetaData))]
    public partial class Cashier
    {
        private bool shouldSerializeTransactions = true;

        public void SetShouldSerializeTransactions(bool should)
        {
            shouldSerializeTransactions = should;
        }

        public bool ShouldSerializeTransactions()
        {
            return shouldSerializeTransactions;
        }
    }

    internal class CashierMetaData
    {
        [JsonProperty(Order = 1)]
        public int IdCashier { get; set; }
        [JsonProperty(Order = 2)]
        public string Id { get; set; }
        [JsonProperty(Order = 3)]
        public string Password { get; set; }
        [JsonProperty(Order = 4)]
        public string Name { get; set; }
        [JsonProperty(Order = 5)]
        public string Surname { get; set; }

        [JsonProperty(Order = 6)]     
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}