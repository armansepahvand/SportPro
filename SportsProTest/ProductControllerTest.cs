using System;
using Xunit;
using SportsPro.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SportsPro.Models;
//using System.Linq;
using SportsPro.Infrastructure;
using Moq;
using SportsPro;


namespace SportsProTest
{
    public class ProductControllerTests
    {
        [Fact]
        public void VerifyAddViewType()
        {
            // Arrange
            var repository = new Mock<IProductRepository>();
            var controller = new HomeController(repository.Object);
            //Act
            var result = controller.Add();
            //Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void VerifyListViewType()
        {
            // Arrange
            var repository = new Mock<IProductRepository>();
            var controller = new HomeController(repository.Object);
            //Act
            var result = controller.List();
            //Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void VerifyDeleteViewType()
        {
            // Arrange
            var repository = new Mock<IProductRepository>();
            var controller = new HomeController(repository.Object);
            //Act
            var result = controller.Delete();
            //Assert
            Assert.IsType<ViewResult>(result);
        }

    }
}
