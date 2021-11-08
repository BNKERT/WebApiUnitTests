using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestWebApi.Controllers;
using Moq;
using UnitTestWebApi.Data;
using System.Linq;
using UnitTestWebApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UnitTestWebApi.Repositories;

namespace WebApi.Tests
{
    [TestClass]
    public class ProductsControllerTests
    {
        private ProductsController _controller;
        private Mock<IProductRepository> _repositoryMock;

        //run before each test
        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IProductRepository>();
            _controller = new ProductsController(_repositoryMock.Object);
        }

        //run after each test
        [TestCleanup]
        public void Cleanup()
        {
            _repositoryMock = null;
            _controller = null;
        }

        [TestMethod]
        public void GetAllProducts_WhenTheStoreIsEmpty_ReturnsAnEmptyList()
        {
            //return []
            _repositoryMock.Setup(repository => repository.getAllProducts()).Returns(new List<Product>());

            var expected = new List<Product>();
            List<Product> actual = _controller.GetAllProducts().Value;
            Assert.AreEqual(expected.Count, actual.Count);
        }
    }
}
