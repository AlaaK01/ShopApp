using Microsoft.AspNetCore.Components;
using ShopApp.client.ClientServices;
using ShopApp.shared.Dtos;

namespace ShopApp.client.Pages
{
    public class indexBase : ComponentBase
    {
        [Inject]
        public IClientProductServices ClientProductServices { get; set; }
        public IEnumerable<ProductDto> products { get; set; }
        protected override async Task OnInitializedAsync()
        {
            products = await ClientProductServices.GetItems();
        }


        //protected IOrderedEnumerable<IGrouping<string, ProductDto>> GetProductsByCategory()
        //{
        //    return from product in products
        //           group product by product.Category into ProductsByGroup
        //           orderby ProductsByGroup.Key
        //           select ProductsByGroup;
        //}
        //protected string GetCategoryName(IGrouping<string, ProductDto> groupProductsDto)
        //{
        //    return groupProductsDto.FirstOrDefault(pg => pg.Category == groupProductsDto.Key).Category;
        //}

    }
}
