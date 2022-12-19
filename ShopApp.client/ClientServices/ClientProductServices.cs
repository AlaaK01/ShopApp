
using ShopApp.shared.Dtos;
using System.Net.Http;
using System.Net.Http.Json;

namespace ShopApp.client.ClientServices
{
    public class ClientProductServices : IClientProductServices
    {
        private readonly HttpClient _http;
        public ClientProductServices(HttpClient http) => _http = http;

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
           
            var response = await _http.GetAsync("api/products");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<ProductDto>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        
        }
       


        public async Task<ProductDto> GetItem(string id)
        {
            var response = await _http.GetAsync($"api/Products/{id}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(ProductDto);
                }

                return await response.Content.ReadFromJsonAsync<ProductDto>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status code: {response.StatusCode} message: {message}");
            }
           
        }


    }
}