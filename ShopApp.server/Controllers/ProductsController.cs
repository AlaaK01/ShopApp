
using ShopApp.shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.server.Extension;
using ShopApp.shared.Dtos;
using ShopApp.shared.Models;

namespace ShopApp.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _services;

       public ProductsController(IProductsServices services) => _services = services;


        // api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = await this._services.GetProducts();
            //var categories = await this._services.GetCategories();
            if (products == null) return NotFound();
            else
            {
                var productDtos = products.ConvertToDto();
                return Ok(productDtos);
            }
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(string id)
        {
            var product = await this._services.GetProductById(id);
            if (product == null) return NotFound();
            else
            {
                var productDto = product.ConvertToDto();
                return Ok(productDto);
            }

        }
    }
}
