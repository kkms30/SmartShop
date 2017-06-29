using NUnit.Framework;
using SmartShopWpf.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Models.Models;

namespace SmartShop.Tests.Wpf.Tests.Data
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
