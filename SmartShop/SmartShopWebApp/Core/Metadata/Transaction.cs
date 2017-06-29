using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartShopWebApp.Core.GeneratedModels
{
    [MetadataType(typeof(TransactionMetaData))]
    public partial class Transaction
    {
        private bool _shouldSerializeCashbox = true;
        private bool _shouldSerializeCashier = true;
        private bool _shouldSerializeOrders = true;

        public void SetShouldSerializeCashbox(bool should)
        {
            _shouldSerializeCashbox = should;
        }
        public void SetShouldSerializeCashier(bool should)
        {
            _shouldSerializeCashier = should;
        }
        public void SetShouldSerializeOrders(bool should)
        {
            _shouldSerializeOrders = should;
        }

        public bool ShouldSerializeCashbox()
        {
            return _shouldSerializeCashbox;
        }
        public bool ShouldSerializeCashier()
        {
            return _shouldSerializeCashier;
        }
        public bool ShouldSerializeOrders()
        {
            return _shouldSerializeOrders;
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