namespace ShopApp.shared.Services
{
    public interface IShopAppSettings
    {
        string CollectionProducts { get; set; }
        string CollectionUsers { get; set; }
        string CollectionItems { get; set; }
        string CollectionCategories { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}