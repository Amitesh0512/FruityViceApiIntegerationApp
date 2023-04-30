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
        private static readonly HttpClient _httpClient = new HttpClient();
        public async Task<GetFruitsByGenusFinalResponse> GetFruitsByFamilyAsync(string familyName)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://www.fruityvice.com/api/fruit/family"),
                    Content = new StringContent($"{{\"fruitFamily\": \"{familyName}\"}}", Encoding.UTF8, "application/json")
                };

                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    throw new FruityViceApiException(response.StatusCode, $"Failed to get fruits for family '{familyName}'.");
                }

                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var fruits = JsonSerializer.Deserialize<GetFruitsByGenusFinalResponse>(responseBody);
                fruits.StatusCode = response.StatusCode;
                return fruits;
            }catch (FruityViceApiException ex)
            {
                GetFruitsByGenusFinalResponse ExceptionResponse = new GetFruitsByGenusFinalResponse();
                ExceptionResponse.StatusCode = ex.StatusCode;
                return ExceptionResponse;
            }
        }
    }
}
