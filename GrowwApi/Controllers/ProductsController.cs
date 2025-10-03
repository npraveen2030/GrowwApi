using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrowwApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProductsNew()
        {
            var products = new[]
            {
                new { Id = 1, Name = "Laptop", Price = 50000 },
                new { Id = 2, Name = "Phone", Price = 30000 }
            };
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = new { Id = id, Name = "Sample", Price = 10000 };
            return Ok(product);
        }
    }
}
