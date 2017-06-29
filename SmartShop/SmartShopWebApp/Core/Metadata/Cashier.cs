using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartShopWebApp.Core.GeneratedModels
{
    [MetadataType(typeof(CashierMetaData))]
    public partial class Cashier
    {
        private bool _shouldSerializeTransactions = true;

        public void SetShouldSerializeTransactions(bool should)
        {
            _shouldSerializeTransactions = should;
        }

        public bool ShouldSerializeTransactions()
        {
            return _shouldSerializeTransactions;
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