using SmartShopWpf.Models;
using System.Collections.Generic;

namespace SmartShopWpf.Data
{
    internal sealed class ManuallyCode
    {
        public Product checkedProduct = new Product();
        public Basket basketContainer = new Basket();
        private const float vat = 1.23F;

        private static ManuallyCode instance;

        private ManuallyCode()
        {
        }

        public static ManuallyCode GetInstance()
        {
            if (instance == null)
            {
                instance = new ManuallyCode();
            }
            return instance;
        }

        public Basket AddToBasketList(int getCount, int counter)
        {
            string getName = checkedProduct.Name.Trim();
            byte[] getImage = checkedProduct.Image;

            float getSingleWithoutVatPrice = checkedProduct.Price;
            float getSingleWithVatPrice = getSingleWithoutVatPrice * vat;
            float getTotalPriceWithVat = getSingleWithVatPrice * getCount;
            float getTotalPriceWithoutVat = getSingleWithoutVatPrice * getCount;

            Basket basket = new Basket() { Number = counter, Name = getName, Image = getImage, Count = getCount,SigleWithoutVatPrice=getSingleWithoutVatPrice, SingleWithVatPrice = getSingleWithVatPrice, TotalPriceWithoutVat = getTotalPriceWithoutVat, TotalPriceWithVat=getTotalPriceWithVat };
            basketContainer = basket;
            return basket;
        }

        public bool CheckTheCode(string codeToCheck, List<Product> lstOfProd)
        {
            foreach (var codeInList in lstOfProd)
            {
                if (codeToCheck.Equals(codeInList.Code.Trim()))
                {
                    checkedProduct = codeInList;

                    return true;
                }
            }

            return false;
        }
    }
}