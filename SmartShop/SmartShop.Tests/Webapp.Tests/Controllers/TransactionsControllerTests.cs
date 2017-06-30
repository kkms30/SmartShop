using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SmartShopWebApp.Controllers;
using SmartShopWebApp.Core;
using SmartShopWebApp.Core.GeneratedModels;

namespace SmartShop.Tests.Webapp.Tests.Controllers
{
    [TestFixture]
    public class TransactionsControllerTests
    {
        [TestCaseSource(nameof(_getReturnsTransactionsCases))]
        public void GetReturnsTransactions(List<Transaction> transactions, int expectedListSize)
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Transactions.GetTransactions()).Returns(transactions);

            var controller = new TransactionsController(unitOfWork.Object);

            // Act 
            List<Transaction> resultList = controller.GetTransactions();

            // Assert
            resultList.Count.Should().Be(expectedListSize);
        }

        private static object[] _getReturnsTransactionsCases =
        {
            new object[] {new List<Transaction>(), 0},
            new object[] {new List<Transaction>() {new Transaction()}, 1},
            new object[] {new List<Transaction>() {new Transaction(), new Transaction()}, 2}
        };
    }
}
