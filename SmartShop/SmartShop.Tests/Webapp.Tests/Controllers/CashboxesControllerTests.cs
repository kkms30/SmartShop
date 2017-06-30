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
    public class CashboxesControllerTests
    {
        [TestCaseSource(nameof(_getReturnsCashboxesCases))]
        public void GetReturnsCashboxes(List<Cashbox> cashboxes, int expectedListSize)
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Cashboxes.GetCashboxes()).Returns(cashboxes);

            var controller = new CashboxesController(unitOfWork.Object);

            // Act 
            List<Cashbox> resultList = controller.GetCashboxes();
            
            // Assert
            resultList.Count.Should().Be(expectedListSize);
        }

        [Test]
        public void GetReturnsCashboxWithSameId()
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Cashboxes.GetCashboxById(5)).Returns(new Cashbox() {Id = 5, });

            var controller = new CashboxesController(unitOfWork.Object);

            // Act 
            IHttpActionResult actionResult = controller.GetCashbox(5);
            var contentResult = actionResult as OkNegotiatedContentResult<Cashbox>;

            // Assert
            contentResult.Should().NotBeNull();
            contentResult.Content.Should().NotBeNull();
            contentResult.Content.Id.Should().Be(5);
        }

        [Test]
        public void GetReturnsHttpResponseException()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.Cashboxes.GetCashboxById(5)).Returns(() => null);

            var controller = new CashboxesController(mockUnitOfWork.Object);

            // Act
            Action action = () => controller.GetCashbox(5);
           
            // Assert
            action.ShouldThrow<HttpResponseException>();
        }

        private static object[] _getReturnsCashboxesCases =
        {
            new object[] {new List<Cashbox>() {new Cashbox()}, 1},
            new object[] {new List<Cashbox>() {new Cashbox(), new Cashbox()}, 2}
        };
    }
}