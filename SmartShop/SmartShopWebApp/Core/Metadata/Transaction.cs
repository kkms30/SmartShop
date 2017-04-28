using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Core.GeneratedModels
{
    [MetadataType(typeof(TransactionMetaData))]
    public partial class Transaction
    {
        private bool shouldSerializeCashbox = true;
        private bool shouldSerializeCashier = true;
        private bool shouldSerializeOrders = true;

        public void SetShouldSerializeCashbox(bool should)
        {
            shouldSerializeCashbox = should;
        }
        public void SetShouldSerializeCashier(bool should)
        {
            shouldSerializeCashier = should;
        }
        public void SetShouldSerializeOrders(bool should)
        {
            shouldSerializeOrders = should;
        }

        public bool ShouldSerializeCashbox()
        {
            return shouldSerializeCashbox;
        }
        public bool ShouldSerializeCashier()
        {
            return shouldSerializeCashier;
        }
        public bool ShouldSerializeOrders()
        {
            return shouldSerializeOrders;
        }
    }

    public class TransactionMetaData
    {
        [JsonProperty(Order = 1)]
        public int IdTransaction { get; set; }
        [JsonProperty(Order = 2)]
        public int CashboxId { get; set; }
        [JsonProperty(Order = 4)]
        public int CashierId { get; set; }
        [JsonProperty(Order = 6)]
        public int Id { get; set; }
        [JsonProperty(Order = 7)]
        public System.DateTime Date { get; set; }
        [JsonProperty(Order = 8)]
        public float TotalPrice { get; set; }
        [JsonProperty(Order = 9)]
        public Nullable<float> Discount { get; set; }

        [JsonProperty(Order = 3)]
        public virtual Cashbox Cashbox { get; set; }
        [JsonProperty(Order = 5)]
        public virtual Cashier Cashier { get; set; }
        [JsonProperty(Order = 10)]
        public virtual ICollection<Order> Orders { get; set; }
    }
}