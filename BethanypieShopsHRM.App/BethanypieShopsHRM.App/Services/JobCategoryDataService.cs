using BethanysPieShopHRM.Shared.Domain;
using Blazored.LocalStorage;

using System.Text.Json;

namespace BethanysPieShopHRM.App.Services
{
    public class JobCategoryDataService : IJobCategoryDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;


        public JobCategoryDataService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
        {
            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>
                (await _httpClient.GetStreamAsync($"api/jobcategory"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<JobCategory> GetJobCategoryById(int jobCategoryId)
        {
            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            return await JsonSerializer.DeserializeAsync<JobCategory>
                (await _httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
