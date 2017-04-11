//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartShopWebApp.Core.GeneratedModels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }

        private bool shouldSerializeCategory = true;
        private bool shouldSerializeOrders = true;

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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

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
}