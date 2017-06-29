using SmartShopWpf.Models;

namespace SmartShopWpf.Data
{
    public class Basket
    {
        //Indeks koszyka
        public int Number { get; set; }

        public Product Product { get; set; }
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public int Count { get; set; }

        //Cena pojedyczego produktu bez Vatu
        public float SigleWithoutVatPrice { get; set; }

        //Cena pojedycznego produktu z Vatem
        public float SingleWithVatPrice { get; set; }

        //Cena Orderu bez Vatu
        public float TotalPriceWithoutVat { get; set; }

        //Cena Orderu z Vatem
        public float TotalPriceWithVat { get; set; }

        //Cena Orderu po wyborze czy z Vatem czy bez
        public float ChoseOptionPrice { get; set; }

        public string OverwallDiscountName { get; set; }
        public string SigleDiscountName { get; set; }

        //Cena Orderu po wybraniu czy z vatem czy bez oraz przed zniżką całościową.
        public float BeforeDiscount { get; set; }

        //Cena Orderu, którą w rzeczywistości płaci klient i którą przy zwrocie otrzyma.
        public float DiscountValue { get; set; }
    }
}