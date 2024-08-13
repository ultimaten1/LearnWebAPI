using LearnWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var product = products.FirstOrDefault(p => p.ProductId ==  Guid.Parse(id));

                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = productViewModel.ProductName,
                Price = productViewModel.Price
            };
            
            products.Add(product);
            return Ok(new
            {
                Success = true,
                Data = product
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, ProductViewModel productViewModel)
        {
            try
            {
                var product = products.FirstOrDefault(p => p.ProductId == Guid.Parse(id));

                if (product == null)
                {
                    return NotFound();
                }

                product.ProductName = productViewModel.ProductName;
                product.Price = productViewModel.Price;

                return Ok(new
                {
                    Success = true,
                    Data = product
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var product = products.FirstOrDefault(p => p.ProductId == Guid.Parse(id));

                if (product == null)
                {
                    return NotFound();
                }

                products.Remove(product);

                return Ok(new
                {
                    Success = true,
                    Data = product
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
