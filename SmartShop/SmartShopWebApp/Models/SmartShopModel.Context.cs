﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class smartshopEntities : DbContext
    {
        public smartshopEntities()
            : base("name=smartshopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cashbox> cashboxs { get; set; }
        public virtual DbSet<cashier> cashiers { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<orderdetail> orderdetails { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<shop> shops { get; set; }
        public virtual DbSet<transaction> transactions { get; set; }
    }
}
