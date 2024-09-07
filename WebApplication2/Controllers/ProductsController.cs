using Microsoft.AspNetCore.Mvc;
using System;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                // The logic of product
                if (id <= 0)
                {
                    throw new ArgumentException("Invalid product ID");
                }

                // Finding the product
                var product = new { Id = id, Name = "Sample Product" };

                return Ok(product); // HTTP 200
            }
            catch (ArgumentException ex)
            {
                // Return 400 Bad Request if the product ID is invalid
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error for general exceptions
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }
    }
}
