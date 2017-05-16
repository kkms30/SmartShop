using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShopWpf.Data
{
    public class DataHandler
    {
        private static DataHandler instance;
        private DataHandler() { }

        public static DataHandler GetInstance()
        {
            if (instance == null)
            {
                instance = new DataHandler();
            }
            return instance;
        }

        public Cashier Cashier { get; set; }
        public List<Product> Products { get; set; }
        public string CashboxId { get; set; }
        public string token { get; set; }
        
    }
}
