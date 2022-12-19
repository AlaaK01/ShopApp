using ShopApp.shared.Models;


namespace ShopApp.shared.Services
{
    public interface IProductsServices
    {
        Task<Product> CreateAsync(string name, string description, string url, double price, int quantity, string category);
        Task<Product> GetProductById(string id);
        Task<IEnumerable<Product>> GetByName(string keyword);
        Task<IEnumerable<Product>> GetProducts();
        Task Remove(string id);
        Task Update(string id, Product updateProduct);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(string id);
    }
        
}