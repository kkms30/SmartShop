using System;
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
        public float ChoseOptionPrice { get; set; }
        public string OverwallDiscountName { get; set; }
        public string SigleDiscountName { get; set; }
        public float SingleDiscount { get; set; }
        public float BeforeDiscount { get; set; }
        public string DiscountName { get; set; }
        public float DiscountValue { get; set; }

        public static explicit operator Basket(ListViewItem v)
        {
            throw new NotImplementedException();
        }
    }
}