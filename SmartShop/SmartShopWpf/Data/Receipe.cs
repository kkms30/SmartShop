using System;
using System.Collections.Generic;

namespace SmartShopWpf.Data
{
    public class Receipe
    {
        public const string Name = "SMARTSHOP";
        public const string Address = "Katowice, ul. Mariusza Cebuli 8";
        public string KindOfPayment { get; set; }
        public int TransactionNumber { get; set; }
        public DateTime Data { get; set; }
        public List<Basket> ListOfBoughtProducts { get; set; }
        public List<Basket> ListOfDeletedProducts { get; set; }
        public List<ReturnObject> ListOfAllOrdersInTransactionToReturn { get; set; }
        public List<ReturnObject> ListOfReturnsOrders { get; set; }
        public float PriceSum { get; set; }
        public float PriceToReturn { get; set; }
        public string OverDiscount { get; set; }
        public int CashNumber { get; set; }
        public int CashierNumber { get; set; }
    }
}