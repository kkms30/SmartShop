using NUnit.Framework;
using SmartShopWpf.Data;
using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //TransactionManager tM = new TransactionManager();
            //DataHandler data = DataHandler.GetInstance();
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
