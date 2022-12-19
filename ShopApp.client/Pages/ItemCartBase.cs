using Microsoft.AspNetCore.Components;
using ShopApp.client.ClientServices;
using ShopApp.shared.Dtos;

namespace ShopApp.client.Pages
{
    public class ItemCartBase : ComponentBase
    {
        [Inject]
        public IClientItemServices clientItemServices { get; set; }
        public List<ItemCartDto> itemCarts { get; set; }
        public string ErrorMessage { get; set;  }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                itemCarts = await clientItemServices.GetItems(HardCoded.UserId);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
