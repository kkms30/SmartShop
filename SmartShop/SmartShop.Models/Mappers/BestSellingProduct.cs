using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShopWpf.Models.Mappers
{
    public class BestSellingProduct
    {
        public int ProductId { get; set; }
        public String Name { get; set; }
        public int TotalSales { get; set; }
    }
}