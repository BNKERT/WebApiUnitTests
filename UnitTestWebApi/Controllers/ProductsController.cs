using Microsoft.AspNetCore.Mvc;
using System;
using UnitTestWebApi.Models;

namespace UnitTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //TODO inject DB into controller

        //TODO: Add DI into constructor
        public ProductsController()
        {

        }
        //All basic CRUD (create,read,update,delete) operations
        //TODO: Implement endpoints
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

    }
}
