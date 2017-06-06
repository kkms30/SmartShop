using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;

namespace SmartShopWpf.Data
{
    public sealed class ManuallyCode
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
            if (getCount < 0 || counter < 0)
                throw new ArgumentException();

            string getName = checkedProduct.Name.Trim();
            byte[] getImage = checkedProduct.Image;
            float getSingleWithoutVatPrice = checkedProduct.Price;
            int getIdProduct = checkedProduct.IdProduct;

            double countSingleWithVat = Math.Round(getSingleWithoutVatPrice * vat, 2);
            float getSingleWithVatPrice = (float)countSingleWithVat;
            float getTotalPriceWithVat = getSingleWithVatPrice * getCount;
            float getTotalPriceWithoutVat = getSingleWithoutVatPrice * getCount;

            //MessageBox.Show("Cena Pobrana z bazy"+getSingleWithoutVatPrice);
            //MessageBox.Show("Cena z Vatem przed float"+countSingleWithVat);
            //MessageBox.Show("Cena z Vatem po float" + getSingleWithVatPrice);

            Basket basket = new Basket() { Number = counter,IdProduct=getIdProduct, Name = getName, Image = getImage, Count = getCount,SigleWithoutVatPrice=getSingleWithoutVatPrice, SingleWithVatPrice = getSingleWithVatPrice, TotalPriceWithoutVat = getTotalPriceWithoutVat, TotalPriceWithVat=getTotalPriceWithVat };
            basketContainer = basket;
            return basket;
        }

        public bool CheckTheCode(string codeToCheck, List<Product> lstOfProd)
        {
            if (codeToCheck == null || lstOfProd == null)
                return false;

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