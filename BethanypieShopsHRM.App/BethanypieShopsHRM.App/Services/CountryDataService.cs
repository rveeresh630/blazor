using BethanysPieShopHRM.Shared.Domain;
using Blazored.LocalStorage;

using System.Text.Json;

namespace BethanysPieShopHRM.App.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient = default!;
        private readonly ILocalStorageService _localStorageService;


        public CountryDataService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;

        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                (await _httpClient.GetStreamAsync($"api/country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            return await JsonSerializer.DeserializeAsync<Country>
                (await _httpClient.GetStreamAsync($"api/country{countryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
