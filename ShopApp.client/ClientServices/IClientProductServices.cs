using ShopApp.shared.Dtos;

namespace ShopApp.client.ClientServices
{
    public interface IClientProductServices
    {
        Task<IEnumerable<ProductDto>> GetItems();
        Task<ProductDto> GetItem(string id);
    }
}

