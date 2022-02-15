using System;
using Xunit;
using Moq;
using RepoTest.API.Data;
using RepoTest.API.Models;
using RepoTest.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RepoTest.API.Dtos;

namespace RepoTest.test
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            //Arrange
            var repoPRoduct = new Mock<IProductRepository>();
            repoPRoduct.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((ProductDtos)null);
            var controller = new ProductController(repoPRoduct.Object);
            //act
            var rnd = new Random();
            var result = await  controller.getProduct(rnd.Next(2,10));
            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
