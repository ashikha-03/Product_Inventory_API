using Microsoft.AspNetCore.Mvc;
using ProductInventoryAPI.Models;
using ProductInventoryAPI.Services;
using System;
using System.Collections.Generic;

namespace ProductInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Ok(_productService.GetAllProducts());
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST: api/Product (Insert Sample Data)
        [HttpPost("InsertSampleData")]
        public ActionResult InsertSampleData()
        {
            var sampleProducts = new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    Name = "Sample Product 1",
                    Brand = "Brand A",
                    ReleaseYear = 2022,
                    Price = 99.99m
                },
                new Product
                {
                    ProductID = 2,
                    Name = "Sample Product 2",
                    Brand = "Brand B",
                    ReleaseYear = 2021,
                    Price = 149.99m
                },
                new Product
                {
                    ProductID = 3,
                    Name = "Sample Product 3",
                    Brand = "Brand C",
                    ReleaseYear = 2023,
                    Price = 199.99m
                }
            };

            foreach (var product in sampleProducts)
            {
                _productService.AddProduct(product);
            }

            return Ok("Sample products added successfully!");
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = product.ProductID }, product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
                return NotFound();

            _productService.UpdateProduct(id, product);
            return NoContent();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            _productService.DeleteProduct(id);
            return NoContent();
        }

        internal OkObjectResult GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
