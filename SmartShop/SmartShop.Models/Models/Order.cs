using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShopWpf.Models
{
    public class Order
    {
        public int IdOrder { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> TransactionId { get; set; }
        public sbyte Return { get; set; }
        public sbyte Count { get; set; }
        public Nullable<float> Discount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
