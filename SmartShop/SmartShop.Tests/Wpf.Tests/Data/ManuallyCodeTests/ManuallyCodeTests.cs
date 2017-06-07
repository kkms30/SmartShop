using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartShopWpf.Models;
using SmartShopWpf.Data;
using NUnit.Framework.Constraints;

namespace SmartShop.Tests.Wpf.Tests
{
    [TestFixture]
    public class ManuallyCodeTests
    {
        [Test]
        public void CheckTheCodeIfResultIsGood()
        {
            //ARRANGE
            ManuallyCode mC = ManuallyCode.GetInstance();
            List<Product> exampleList = new List<Product>();
            Product prod1 = new Product();
            prod1.Code = "333";
            exampleList.Add(prod1);
            //ACT
            bool result = mC.CheckTheCode("333", exampleList);
            bool expected = true;
            //ASSERT
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void CheckTheCodeIfResultIsWrong()
        {
            //ARRANGE
            ManuallyCode mC = ManuallyCode.GetInstance();
            List<Product> exampleList = new List<Product>();
            Product prod1 = new Product();
            prod1.Code = "333";
            exampleList.Add(prod1);
            //ACT
            bool result = mC.CheckTheCode("444", exampleList);
            bool expected = false;
            //ASSERT
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void CheckTheCodeIfOneOfParametersIsNull()
        {
            //ARRANGE
            ManuallyCode mC = ManuallyCode.GetInstance();
            List<Product> exampleList = new List<Product>();
            Product prod1 = new Product();
            prod1.Code = "333";
            exampleList.Add(prod1);
            //ACT
            bool result = mC.CheckTheCode(null, exampleList);
            bool secondResult = mC.CheckTheCode("333", null);
            bool expected = false;
            //ASSERT
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected, secondResult);
        }
        [Test]
        [TestCase(1,2)]
        public void AddToBasketListIfReturnGoodBasket(int x, int y)
        {
            //ARRANGE
            byte[] image = new byte[] { 0x20 };
            Product product = new Product() { Name = "ex", Image = new byte[] { 0x20 }, Price = 20 };
            ManuallyCode mC = ManuallyCode.GetInstance();
            mC.checkedProduct = product;
            //ACT
            Basket basketExpected = new Basket() { Name = product.Name, Image = product.Image, SigleWithoutVatPrice = product.Price, Number = y, Count = x };
            Basket basketResult =  mC.AddToBasketList(x, y);
            //ASSERT
            Assert.IsTrue(basketExpected.Count == basketResult.Count &&
                basketExpected.Number == basketResult.Number &&
                basketExpected.Name == basketResult.Name &&
                basketExpected.Image == basketResult.Image &&
                basketExpected.SigleWithoutVatPrice == basketResult.SigleWithoutVatPrice);
        }
        [Test]
        public void AddToBasketListIfGetCountOrCounterAreLessThenOneAndThrowArgumentException()
        {
            //ARRANGE
            ManuallyCode mC = ManuallyCode.GetInstance();
            //ACT

            //ASSERT
            Assert.Throws(typeof(ArgumentException), () => mC.AddToBasketList(-1, -1));
        }
    }
}
