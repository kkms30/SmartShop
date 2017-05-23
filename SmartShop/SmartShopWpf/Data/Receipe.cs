using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShopWpf.Data
{
    public class Receipe
    {
        public const string NAME = "SMARTSHOP";
        public const string ADDRESS = "Katowice, ul. M. Cebularza 8";
        public int TransactionNumber { get; set; }
        public DateTime Data { get; set; }
        public List<Basket> listOfBoughtProducts { get; set; }
        public float PriceSum { get; set; }
        public int CashNumber { get; set; }
        public int CashierNumber { get; set; }
    }
}
