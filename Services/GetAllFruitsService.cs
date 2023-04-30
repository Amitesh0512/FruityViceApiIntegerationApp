using FruityViceApiIntegerationApp.Exceptions;
using FruityViceApiIntegerationApp.Interfaces;
using FruityViceApiIntegerationApp.Models.ResponseModels;
using System.Net.Http;
using System.Text.Json;

namespace FruityViceApiIntegerationApp.Services
{
    public class GetAllFruitsService: IGetAllFruits
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<AllFruitsResponse> GetAllFruitsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://www.fruityvice.com/api/fruit/all");

                if (!response.IsSuccessStatusCode)
                {
                    throw new FruityViceApiException(response.StatusCode, "Failed to get all fruits.");
                }

                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var fruits = JsonSerializer.Deserialize<AllFruitsResponse>(responseBody);
                fruits.StatusCode = response.StatusCode;
                return fruits;
            }
            catch (FruityViceApiException ex)
            {
                AllFruitsResponse allFruitsResponse = new AllFruitsResponse();
                allFruitsResponse.StatusCode = ex.StatusCode;
                allFruitsResponse.getAllFruits = null;
                return allFruitsResponse;
            }
            
        }
    }
}
