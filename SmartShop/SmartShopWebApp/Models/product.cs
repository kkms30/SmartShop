//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartShopWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int idproducts { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public float price { get; set; }
        public byte[] image { get; set; }
        public int categories_idcategories { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
