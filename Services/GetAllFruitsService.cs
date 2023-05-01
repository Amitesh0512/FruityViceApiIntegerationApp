using FruityViceApiIntegerationApp.Exceptions;
using FruityViceApiIntegerationApp.Interfaces;
using FruityViceApiIntegerationApp.Models.ResponseModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace FruityViceApiIntegerationApp.Services
{
    public class GetAllFruitsService: IGetAllFruits
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<AllFruitsResponse> GetAllFruitsAsync()
        {
            AllFruitsResponse allFruitsResponse = new AllFruitsResponse();

            try
            {
                var response = await _httpClient.GetAsync("https://www.fruityvice.com/api/fruit/all");

                if (!response.IsSuccessStatusCode)
                {
                    throw new FruityViceApiException(response.StatusCode, "Failed to get all fruits.");
                }

                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var fruits = JsonSerializer.Deserialize<List<GetAllFruitsResponse>>(responseBody);
                allFruitsResponse.Message = "SUCCESS";
                allFruitsResponse.getAllFruits = fruits;
                return allFruitsResponse;
            }
            catch (FruityViceApiException ex)
            {
                allFruitsResponse.Message = $"Error:{ex.Message}";
                return allFruitsResponse;
            }
            
        }
    }
}
