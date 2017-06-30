using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SmartShopWebApp.Controllers;
using SmartShopWebApp.Core;
using SmartShopWebApp.Core.GeneratedModels;

namespace SmartShop.Tests.Webapp.Tests.Controllers
{
    [TestFixture]
    public class CashiersControllerTests
    {
        [TestCaseSource(nameof(_getReturnsCashiersCases))]
        public void GetReturnsCashiers(List<Cashier> cashiers, int expectedListSize)
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Cashiers.GetCashiers()).Returns(cashiers);

            var controller = new CashiersController(unitOfWork.Object);

            // Act 
            List<Cashier> resultList = controller.GetCashiers();

            // Assert
            resultList.Count.Should().Be(expectedListSize);
        }

        [Test]
        public void GetReturnsCashierWithSameId()
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Cashiers.GetCashierById("1")).Returns(new Cashier() {Id = "1"});

            var controller = new CashiersController(unitOfWork.Object);

            // Act 
            IHttpActionResult actionResult = controller.GetCashier("1");
            var contentResult = actionResult as OkNegotiatedContentResult<Cashier>;

            // Assert
            contentResult.Should().NotBeNull();
            contentResult.Content.Should().NotBeNull();
            contentResult.Content.Id.Should().Be("1");
        }

        [Test]
        public void GetReturnsHttpResponseException()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.Cashiers.GetCashierById("2")).Returns(() => null);

            var controller = new CashiersController(mockUnitOfWork.Object);

            // Act
            Action action = () => controller.GetCashier("2");

            // Assert
            action.ShouldThrow<HttpResponseException>();
        }

        private static object[] _getReturnsCashiersCases =
        {
            new object[] {new List<Cashier>() {new Cashier()}, 1},
            new object[] {new List<Cashier>() {new Cashier(), new Cashier()}, 2}
        };
    }
}