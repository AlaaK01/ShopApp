using ShopApp.shared.Models;


namespace ShopApp.shared.Services
{
    public interface IUsersServices
    {
        Task<User> CreateAsync(string name, string password, string email);
        Task<User> GetUserById(string id);
        Task<IEnumerable<User>> GetUsers();
        Task Remove(string id);
        Task Update(string id, User updateUser);
    }
}
