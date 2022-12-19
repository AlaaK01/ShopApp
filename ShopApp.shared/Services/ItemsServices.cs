using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OpenXmlPowerTools;
using ShopApp.shared.Models;



namespace ShopApp.shared.Services
{
    public class ItemsServices : IItemsServices
    {
        private readonly IMongoCollection<Item> _items;
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<Product> _products;
        public ItemsServices(IOptions<ShopAppSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _items = client.GetDatabase(options.Value.DatabaseName).GetCollection<Item>(options.Value.CollectionItems);
            _users = client.GetDatabase(options.Value.DatabaseName).GetCollection<User>(options.Value.CollectionUsers);
            _products = client.GetDatabase(options.Value.DatabaseName).GetCollection<Product>(options.Value.CollectionProducts);
        }
       

        public async Task<IEnumerable<Item>> GetItems(string userId)
        {
            var user = await _users.Find(u => userId == u.Id).FirstOrDefaultAsync();
            if (user != null)
            {
                return await _items.Find(X => X.UserId == userId).ToListAsync();
            }
            return null;
           
        }

        public async Task<IEnumerable<User>> GetUsers() => await _users.Find(u => true).ToListAsync();
        public async Task<User> GetUserById(string id) => await _users.Find(u => u.Id == id).SingleOrDefaultAsync();
        public async Task<IEnumerable<Product>> GetProducts() => await _products.Find(x => true).ToListAsync();
        public async Task<Product> GetProductById(string id) => await _products.Find(x => x.Id == id).SingleOrDefaultAsync();
        public async Task<Item> GetItemById(string id) => await _items.Find(x => x.Id == id).SingleOrDefaultAsync();

        public async Task<Item> AddItem(string userId, string productId, int quantity)
        {
            var item = new Item();
            item.UserId = userId;
            item.ProductId = productId;
            item.Quantity = quantity;
            await _items.InsertOneAsync(item);
            return item;
        }

        public async Task DeleteItem(string id) => await _items.DeleteOneAsync(x => x.Id == id);

        public async Task Update(string id, Item updateItem) => await _items.ReplaceOneAsync(id, updateItem);

    }
}
