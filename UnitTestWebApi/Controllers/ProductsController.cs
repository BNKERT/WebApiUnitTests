using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestWebApi.Data;
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
        public IActionResult GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            return new OkObjectResult(product);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

    }
}
