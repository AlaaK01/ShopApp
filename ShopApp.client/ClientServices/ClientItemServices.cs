using ShopApp.shared.Dtos;
using ShopApp.shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace ShopApp.client.ClientServices
{
    public class ClientItemServices : IClientItemServices
    {
        private readonly HttpClient _http;
        public ClientItemServices(HttpClient http) => _http = http;

        public async Task<ItemCartDto> AddItem(ItemDto itemDto)
        {
            var response = await _http.PostAsJsonAsync<ItemDto>("api/ItemCart", itemDto);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(ItemCartDto);
                }

                return await response.Content.ReadFromJsonAsync<ItemCartDto>();

            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status:{response.StatusCode} Message -{message}");
            }

        }


        public async Task<List<ItemCartDto>> GetItems(string userId)
        {
             var response = await _http.GetAsync($"api/ItemCart/{userId}/GetItems");

            if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {   
                        return Enumerable.Empty<ItemCartDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<ItemCartDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }
        }

       
        
    }
}
