using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShopApp.shared.Models;
using ShopApp.shared.Services;



namespace ShopApp.shared.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IMongoCollection<User> _users;
        public UsersServices(IOptions<ShopAppSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _users = client.GetDatabase(options.Value.DatabaseName).GetCollection<User>(options.Value.CollectionUsers);
        }
        public async Task<User> CreateAsync(string userName, string password, string email)
        {
            var newUser = new User();
            newUser.UserName = userName;
            newUser.Password = password;
            newUser.Email = email;
            await _users.InsertOneAsync(newUser);
            return newUser; 
        }

        public async Task<IEnumerable<User>> GetUsers() => await _users.Find(u => true).ToListAsync();
       
        public async Task<User> GetUserById(string id) => await _users.Find(u => u.Id == id).SingleOrDefaultAsync();

        public async Task Update(string id, User updateUser) => await _users.ReplaceOneAsync(id, updateUser);
        public async Task Remove(string id) => await _users.DeleteOneAsync(u => u.Id == id);
    }
}
