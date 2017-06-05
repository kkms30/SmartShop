using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Persistance.Mappers
{
    public class Report
    {
        public String Name { get; set; } 
        public int Sum { get; set; }
        public decimal TotalPrice { get; set; }
    }
}