using Microsoft.AspNetCore.Components;
using ShopApp.shared.Dtos;

namespace ShopApp.client.Pages
{
    public class CardProductBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
        
    }
}
