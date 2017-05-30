﻿using NUnit.Framework;
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
        [Test]
        public void PrepareNewTrasactionIfHappend()
        {
            //ARRANGE
            TransactionManager tM = new TransactionManager();
            DataHandler data = DataHandler.GetInstance();
            data.Cashbox = new Cashbox();
            data.Cashier = new Cashier();
            //ACT
            tM.PrepareNewTransaction();
            //ASSERT
            Assert.AreNotEqual(null, data.Transaction);
        }
        [Test]
        public void AddNewOrderToTransactionIfHappend()
        {
            //ARRANGE
            TransactionManager tM = new TransactionManager();
            Product product = new Product() { IdProduct = 5 };
            DataHandler data = DataHandler.GetInstance();
            Transaction tran = new Transaction() { IdTransaction = 5 };
            data.Transaction = tran;
            //ACT
            tM.AddNewOrderToTransaction(product, 2);
            //ASSERT
            Assert.AreEqual(true,data.Transaction.Orders.Count > 0);
        }

    }
}
