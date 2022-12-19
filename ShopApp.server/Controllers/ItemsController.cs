
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.server.Extension;
using ShopApp.shared.Dtos;
using ShopApp.shared.Models;
using ShopApp.shared.Services;

namespace ShopApp.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsServices _services;

        public ItemsController(IItemsServices services) => _services = services;

        [HttpGet]
        [Route("{userId}/GetItems")]
        public async Task<ActionResult<IEnumerable<ItemCartDto>>> GetItems(string userId)
        {
            var items = await this._services.GetItems(userId);
            var users = await this._services.GetUsers();
            var products = await this._services.GetProducts();
            if (items == null) return NoContent();
            if (users == null) throw new Exception("No users exist in the system");
            if (products == null) throw new Exception("No products exist in the system");

            else
            {
                var itemsDtos = items.ConvertToDto(users, products);
                return Ok(itemsDtos);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCartDto>> GetItem(string id)
        {

            var item = await _services.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }
            var product = await _services.GetProductById(item.ProductId);

            if (product == null)
            {
                return NotFound();
            }
            var user = await _services.GetUserById(item.UserId);
            if (user == null)
            {
                return NotFound();
            }
            var itemCartDto = item.ConvertToDto(user, product);

            return Ok(itemCartDto);

        }

        [HttpPost]
        public async Task<ActionResult<ItemCartDto>> CreateItem(ItemDto newItem)
        {
            var item = await _services.AddItem(newItem.UserId, newItem.ProductId, newItem.Quantity);
            if (item == null)
            {
                return NotFound();
            }
            var product = await _services.GetProductById(item.ProductId);
            if (product == null)
            {
                return NotFound();
            }
            var user = await _services.GetUserById(item.UserId);
            if (user == null)
            {
                return NotFound();
            }
            var itemCartDto = item.ConvertToDto(user, product);
            return Ok(itemCartDto);

            return CreatedAtAction(nameof(GetItem), new { id = itemCartDto.Id }, itemCartDto);

        }


    }
}
