using Microsoft.AspNetCore.Components;
using ShopApp.client.ClientServices;
using ShopApp.shared.Dtos;

namespace ShopApp.client.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public IClientProductServices _clientproductServices { get; set; }
        [Inject]
        public IClientItemServices _clientItemServices { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public ProductDto product { get; set; }
        public string ErrorMessage { get; set; }
        public List<ItemCartDto> Items { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                product = await _clientproductServices.GetItem(Id);
            }
            catch (Exception ex) { ErrorMessage = ex.Message; }
        }

        //protected async Task AddToCart_Click(ItemDto itemDto)
        //{
            
        //    var itemCartDto = await _clientItemServices.AddItem(itemDto);
        //    NavigationManager.NavigateTo("/ItemCart");
           
  
        //}

       
    }
}
