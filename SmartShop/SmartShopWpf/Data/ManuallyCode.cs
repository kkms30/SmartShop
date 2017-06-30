using System;
using System.Collections.Generic;
using SmartShop.Models.Models;

namespace SmartShopWpf.Data
{
    public class ManuallyCode
    {
        public Product CheckedProduct = new Product();
        public Basket BasketContainer = new Basket();
        private const float Vat = 1.23F;

        private static ManuallyCode _instance;

        private ManuallyCode()
        {
        }

        public static ManuallyCode GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ManuallyCode();
            }
            return _instance;
        }

        public Basket AddToBasketList(int getCount, int counter)
        {
            if (getCount < 0 || counter < 0)
                throw new ArgumentException();

            string getName = CheckedProduct.Name.Trim();
            byte[] getImage = CheckedProduct.Image;
            float getSingleWithoutVatPrice = CheckedProduct.Price;
            int getIdProduct = CheckedProduct.IdProduct;

            double countSingleWithVat = Math.Round(getSingleWithoutVatPrice * Vat, 2);
            float getSingleWithVatPrice = (float) countSingleWithVat;
            float getTotalPriceWithVat = getSingleWithVatPrice * getCount;
            float getTotalPriceWithoutVat = getSingleWithoutVatPrice * getCount;

            Basket basket = new Basket()
            {
                Number = counter,
                IdProduct = getIdProduct,
                Product = CheckedProduct,
                Name = getName,
                Image = getImage,
                Count = getCount,
                SingleWithoutVatPrice = getSingleWithoutVatPrice,
                SingleWithVatPrice = getSingleWithVatPrice,
                TotalPriceWithoutVat = getTotalPriceWithoutVat,
                TotalPriceWithVat = getTotalPriceWithVat
            };
            BasketContainer = basket;
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
                    CheckedProduct = codeInList;

                    return true;
                }
            }
            return false;
        }
    }
}