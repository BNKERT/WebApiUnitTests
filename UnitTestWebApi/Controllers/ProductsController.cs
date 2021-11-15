using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UnitTestWebApi.Models;
using UnitTestWebApi.Repositories;

namespace UnitTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //TODO inject DB into controller
        private IProductRepository _repository;


        //TODO: Add DI into constructor
        public ProductsController(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        //All basic CRUD (create,read,update,delete) operations
        //TODO: Implement endpoints
        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            //returns 200 Status code with body being the result
            return _repository.getAllProducts();
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            return _repository.getProduct(id);
        }

        [HttpPut]
        public ActionResult<Product> UpdateProduct(Product product)
        {
            //mocking repository -> telling to return a valid product (not null)
            Product existingProduct = _repository.getProduct(product.ID);
            //mocked product isn't null so go in
            if(existingProduct != null)
            {
                //update the mocked product
                _repository.updateProduct(product);
                //return that product
                return product;
            }

            return null;
        }


        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            if(_repository.getProduct(product.ID) == null)
            {
                _repository.createProduct(product);
                return product;
            }
            return null;
        }

        [HttpDelete]
        public ActionResult<Product> DeleteProduct(int id)
        {
            Product product = _repository.getProduct(id);
            if (product != null)
            {
                _repository.deleteProduct(id);
                return product;
                
            }
            return null;
        }

    }
}
