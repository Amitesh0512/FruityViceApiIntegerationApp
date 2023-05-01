using FruityViceApiIntegerationApp.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using FruityViceApiIntegerationApp.Models.ResponseModels;
using FruityViceApiIntegerationApp.Exceptions;

namespace FruityViceApiIntegerationApp.Services
{
    public class GetAllFruitsByGenusService: IGetFruitsByGenus
    {
        public async Task<GetFruitsByGenusFinalResponse> GetFruitsByFamilyAsync(string familyName)
        {
            GetFruitsByGenusFinalResponse fruitsByGenusFinalResponse = new GetFruitsByGenusFinalResponse();

            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://www.fruityvice.com");

            try
            {
                var response = await httpClient.PostAsync($"/api/fruit/family/{familyName}", null);

                response.EnsureSuccessStatusCode();

                if (!response.IsSuccessStatusCode)
                {
                    throw new FruityViceApiException(response.StatusCode, $"Failed to get fruits for family '{familyName}'.");
                }

                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var fruits = JsonSerializer.Deserialize<List<GetFruitsByGenus>>(responseBody);

                fruitsByGenusFinalResponse.message = "SUCCESS";
                fruitsByGenusFinalResponse.getFruitsByGenus = fruits;

                return fruitsByGenusFinalResponse;
            }catch (FruityViceApiException ex)
            {
                fruitsByGenusFinalResponse.message = $"ERROR:{ex.Message}";
                return fruitsByGenusFinalResponse;
            }
        }
    }
}
