using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShopWpf.Data
{
   public class ReturnObject
    {


        public int Number { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public float? Discount { get; set;}
    }
}
