using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SmartShopWpf.Data
{
    public class Basket
    {

        public int Number { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Count { get; set; }        
        public float SigleWithoutVatPrice { get; set; }        
        public float SingleWithVatPrice { get; set; }
        public float TotalPriceWithoutVat { get; set; }
        public float TotalPriceWithVat { get; set; }



        public static explicit operator Basket(ListViewItem v)
        {
            throw new NotImplementedException();
        }
    }
}
