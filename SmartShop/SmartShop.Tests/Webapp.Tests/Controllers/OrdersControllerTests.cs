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
    public class OrdersControllerTests
    {

        [TestCaseSource(nameof(_getReturnsOrdersCases))]
        public void GetReturnsOrders(List<Order> orders, int expectedListSize)
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.Orders.GetOrderWithProducts()).Returns(orders);

            var controller = new OrdersController(mockUnitOfWork.Object);

            // Act 
            List<Order> resultList = (List<Order>) controller.GetOrders();

            // Assert
            resultList.Count.Should().Be(expectedListSize);
        }

        private static object[] _getReturnsOrdersCases =
        {
            new object[] {new List<Order>(), 0},
            new object[] {new List<Order>() {new Order()}, 1},
            new object[] {new List<Order>() {new Order(), new Order()}, 2}
        };
    }
}