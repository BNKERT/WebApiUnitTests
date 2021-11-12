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

        [TestMethod]
        public void GetAllProducts_WhenTheStoreIsnotEmpty_ReturnsAListOfProducts()
        {
            //return []
            _repositoryMock.Setup(repository => repository.getAllProducts()).Returns(new List<Product>
            {
            new Product { ID = 1, Name = "Bananas", Price = 1.50M}
            });

            List<Product> actual = _controller.GetAllProducts().Value;
            Assert.AreEqual(1, actual.Count);
        }



        [TestMethod]
        public void GetProduct_WhenTheStoreIsnotEmpty_ReturnsTheProductIfIdIsValid()
        {
            //arrange
            _repositoryMock.Setup(repository => repository.getProduct(1)).Returns(new Product { ID = 1, Name = "Bananas", Price = 1.50M });
            //act
            Product actual = _controller.GetProduct(1).Value;
            //assert
            Assert.AreEqual(1, actual.ID);
        }



        [TestMethod]
        public void GetProduct_WhenTheStoreIsEmpty_ReturnsNull()
        {
            //arrange
            // Do not need to setup mock repo since it will be empty should return null (no values to choose from)
            //act
            Product actual = _controller.GetProduct(1).Value;
            //assert
            Assert.IsNull(actual);
        }
    }
}
