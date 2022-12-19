

namespace ShopApp.shared.Dtos
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public string Category { get; set; }
    }
}
