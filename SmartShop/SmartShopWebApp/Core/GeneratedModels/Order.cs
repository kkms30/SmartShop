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
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> TransactionId { get; set; }
        public sbyte Return { get; set; }
        public sbyte Count { get; set; }
        public Nullable<float> Discount { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
