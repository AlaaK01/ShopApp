namespace ShopApp.shared.Services
{
    public class ShopAppSettings : IShopAppSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionProducts { get; set; }
        public string CollectionUsers { get; set; }
        public string CollectionCategories { get; set; }
        public string CollectionItems { get; set; }

    }
}
