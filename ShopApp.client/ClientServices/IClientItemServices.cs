using ShopApp.shared.Dtos;
using ShopApp.shared.Models;

namespace ShopApp.client.ClientServices
{
    public interface IClientItemServices
    {
        Task<List<ItemCartDto>> GetItems(string userId);
        Task<ItemCartDto> AddItem(ItemDto itemDto); 
    }
}
