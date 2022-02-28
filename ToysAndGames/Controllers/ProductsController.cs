using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public List<Product> GetProducts()
        {
            return _service.GetProducts();
        }

        [HttpPost("Create")]
        public void CreateProduct(Product product)
        {
            _service.CreateProduct(product);
        }

        [HttpDelete("Delete/{id}")]
        public void DeleteProduct(int id)
        {
            _service.DeleteProduct(id);
        }

        [HttpPost("Update")]
        public void UpdateProduct(Product product)
        {
            _service.UpdateProduct(product);
        }


    }
}
