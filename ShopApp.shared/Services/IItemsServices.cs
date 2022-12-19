using ShopApp.shared.Models;



namespace ShopApp.shared.Services
{
    public interface IItemsServices
    {

        Task<Item> GetItemById(string id);
        Task<Item> AddItem(string userId, string productId, int quantity);
        Task<IEnumerable<Item>> GetItems(string userId);
        Task DeleteItem(string id);
        Task Update(string id, Item updateItem);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(string id);
        Task<User> GetUserById(string id);
    }
}
