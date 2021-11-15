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

        [TestMethod]
        public void UpdateProduct_WhenTheProductDoesNotExist_ReturnsNull()
        {
            //arrange
            // Do not need to setup mock repo since it will be empty should return null (no values to choose from)
            //act
            var actual = _controller.UpdateProduct(new Product { ID = 1 });

            //assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void UpdateProduct_WhenTheProductDoesExist_ReturnsThatUpdatedProduct()
        {

            //arrange
            //pass any integer returns product
            _repositoryMock.Setup(repository => repository.getProduct(It.IsAny<int>())).Returns(new Product { ID = 1, Name = "Bananas", Price = 1.50M });

            // Do not need to setup mock repo since it will be empty should return null (no values to choose from)
            //act
            Product actual = _controller.UpdateProduct(new Product { ID = 1, Name = "Apples", Price = 2.50M }).Value;

            //assert
            Assert.AreEqual(actual.Name, "Apples");
            Assert.AreEqual(actual.Price, 2.50M);
        }

        [TestMethod]
        public void CreateProduct_WhenTheProductDoesExist_ReturnsNull()
        {

            //arrange
            //pass any integer returns product
            _repositoryMock.Setup(repository => repository.getProduct(It.IsAny<int>())).Returns(new Product { ID = 1, Name = "Bananas", Price = 1.50M });

            // Do not need to setup mock repo since it will be empty should return null (no values to choose from)
            //act
            var actual = _controller.CreateProduct(new Product { ID = 1, Name = "Apples", Price = 2.50M });

            //assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void CreateProduct_WhenTheProductDoesNotExist_ReturnsTheNewProduct()
        {

            //arrange
            //pass any integer returns product

            // Do not need to setup mock repo since it will be empty should return null (no values to choose from)
            //act
            Product actual = _controller.CreateProduct(new Product { ID = 1, Name = "Apples", Price = 2.50M }).Value;

            //assert
            Assert.AreEqual(actual.Name, "Apples");
            Assert.AreEqual(actual.Price, 2.50M);
        }

        [TestMethod]
        public void DeleteProduct_WhenTheProductDoesExist_ReturnTheRemovedProduct()
        {
            Product expectedProduct = new Product { ID = 1, Name = "Bananas", Price = 1.50M };
            //arrange
            //pass any integer returns product
            _repositoryMock.Setup(repository => repository.getProduct(It.IsAny<int>())).Returns(expectedProduct);

            // Do not need to setup mock repo since it will be empty should return null (no values to choose from)
            //act
            Product actual = _controller.DeleteProduct(1).Value;

            //assert
            Assert.AreEqual(actual.Name, expectedProduct.Name);
            Assert.AreEqual(actual.Price, expectedProduct.Price);
        }

        [TestMethod]
        public void CreateProduct_WhenTheProductDoesNotExist_ReturnsNull()
        {

            //arrange
            //pass any integer returns product

            // Do not need to setup mock repo since it will be empty should return null (no values to choose from)
            //act
            var actual = _controller.DeleteProduct(1);

            //assert
            Assert.IsNull(actual);
        }
    }
}
