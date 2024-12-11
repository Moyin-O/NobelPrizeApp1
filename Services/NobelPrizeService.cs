using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using NobelPrizeApp.Models;

namespace NobelPrizeApp.Services
{
    public class NobelPrizeService
    {
        private readonly HttpClient _httpClient;

        public NobelPrizeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Laureate>> GetLaureatesAsync()
        {
            var response = await _httpClient.GetAsync("https://api.nobelprize.org/2.1/laureates");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var laureatesResponse = JsonSerializer.Deserialize<LaureatesResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return laureatesResponse?.Laureates ?? new List<Laureate>();
        }
    }

    public class LaureatesResponse
    {
        public List<Laureate> Laureates { get; set; } = new List<Laureate>();
    }
}