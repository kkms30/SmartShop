using System.Collections.Generic;
using SmartShop.Models.Models;

namespace SmartShopWpf.Data
{
    public class DataHandler
    {
        private static DataHandler _instance;

        private DataHandler()
        {
        }

        public static DataHandler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHandler();
            }
            return _instance;
        }

        public Cashier Cashier { get; set; }
        public List<Product> Products { get; set; }
        public Cashbox Cashbox { get; set; }
        public Transaction Transaction { get; set; }
        public string Token { get; set; }

        public void ClearTransaction()
        {
            Transaction = null;
        }
    }
}