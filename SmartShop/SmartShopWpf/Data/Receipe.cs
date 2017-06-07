﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShopWpf.Data
{
    public class Receipe
    {
        public const string NAME = "SMARTSHOP";
        public const string ADDRESS = "Katowice, ul. Mariusza Cebuli 8";
        public string kindOfPayment { get; set; }
        public int TransactionNumber { get; set; }
        public DateTime Data { get; set; }
        public List<Basket> listOfBoughtProducts { get; set; }
        public List<Basket> listOfDeletedProducts { get; set; }
        public List<ReturnObject> listOfAllOrdersInTransactionToReturn { get; set; }
        public List<ReturnObject> listOfReturnsOrders { get; set; }
        public float PriceSum { get; set; }
        public float PriceToReturn { get; set; }
        public string OverDiscount { get; set; }
        public int CashNumber { get; set; }
        public int CashierNumber { get; set; }
    }
}
