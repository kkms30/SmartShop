using SmartShopWpf.Models;
using System.Collections.Generic;

namespace SmartShopWpf.Data
{
    internal sealed class ManuallyCode
    {
         public Product checkedProduct = new Product();
         public Basket basketContainer = new Basket();
        
       

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
            float getPrice = checkedProduct.Price*getCount;

            Basket basket = new Basket() { Number = counter, Name = getName, Image = getImage, Count = getCount, Price = getPrice };
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