using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService
{
    public class Endpoint
    {
        public static readonly string BASE_URL = "http://localhost:46468";
        public static readonly string TOKEN = "/token";
        public static readonly string CASHIER = "/api/Cashiers/";
        public static readonly string PRODUCTS = "/api/Products/";
        public static readonly string TRANSACTION = "/api/Transactions/";
        public static readonly string TOP10 = "/api/Top10/";
        public static readonly string ORDER = "/api/Orders/";
    }
}
