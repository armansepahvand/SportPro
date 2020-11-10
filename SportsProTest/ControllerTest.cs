using System;
using Xunit;
using SportsPro.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SportsPro.Models;
using System.Linq;
using SportsPro.Infrastructure;
using Moq;
using SportsPro;

namespace SportsProTest
{
    public class HomeControllerTests
    {
        [Fact]
        public void VerifyIndexViewType()
        {
            //Arrange
            var repository = new Mock<IProductRepository>();
            var controller = new HomeController(repository.Object);
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void VerifyAboutViewType()
        {
            //Arrange
            var repository = new Mock<IProductRepository>();
            var controller = new HomeController(repository.Object);
            //Act
            var result = controller.About();
            //Assert
            Assert.IsType<ViewResult>(result);
        }


    }
}
