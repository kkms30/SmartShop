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
    public class ProductsControllerTests
    {
        [TestCaseSource(nameof(_getReturnsOrdersCases))]
        public void GetReturnsProducts(List<Product> products, int expectedListSize)
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Products.GetProductsWithCategories()).Returns(products);

            var controller = new ProductsController(unitOfWork.Object);

            // Act 
            List<Product> resultList = (List<Product>) controller.GetProducts();

            // Assert
            resultList.Count.Should().Be(expectedListSize);
        }

        private static object[] _getReturnsOrdersCases =
        {
            new object[] {new List<Product>(), 0},
            new object[] {new List<Product>() {new Product()}, 1},
            new object[] {new List<Product>() {new Product(), new Product()}, 2}
        };
    }
}