using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToysAndGames.Dtos;
using ToysAndGames.Interfaces;
using ToysAndGames.Models;

namespace ToysAndGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _service.GetProducts();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto product)
        {
            var result = await _service.CreateProduct(product);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _service.DeleteProduct(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDto product)
        {
            await _service.UpdateProduct(product);
            return Ok();
        }


    }
}
