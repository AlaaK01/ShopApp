

namespace ShopApp.shared.Dtos
{
    public class ItemCartDto
    {
       
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }
        
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}
