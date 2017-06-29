using NUnit.Framework;
using SmartShop.Models.Models;
using SmartShopWpf.Data;

namespace SmartShop.Tests.Wpf.Tests.Data.TransactionManagerTests
{
    [TestFixture]
    public class TransactionManagerTests
    {
        private DataHandler data;
        TransactionManager tM;
        [OneTimeSetUp]
        public void Init()
        {
            data = DataHandler.GetInstance();
            tM = new TransactionManager();
        }

        [Test]
        public void PrepareNewTrasactionIfHappend()
        {
            //ARRANGE
            data.Cashbox = new Cashbox() { IdCashbox = 5 };
            data.Cashier = new Cashier() { IdCashier = 5 };
            data.Token = "opo";
            //ACT
            tM.PrepareNewTransaction();
            //ASSERT
            Assert.AreNotEqual(null, data.Transaction);
        }


    }
}
