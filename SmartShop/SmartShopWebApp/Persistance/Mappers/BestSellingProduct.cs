using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Persistance.Mappers
{
    public class BestSellingProduct
    {
        public int Ordinal { get; set; }
        public String Name { get; set; }
        public int TotalSales { get; set; }
    }
}