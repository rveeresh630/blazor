using BethanypieShopsHRM.App.AuthProvider;

using BethanysPieShopHRM.App.Helper;
using BethanysPieShopHRM.Shared.Domain;
using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace BethanypieShopHRM.App.Services
{
    public class UserService:IUserService
    {
        private readonly HttpClient? _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorageService;

        public UserService(HttpClient httpClient, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
           _authStateProvider = authStateProvider;
        }

        public async Task<LoginResult> AuthenticateUser(string username, string password)
        {

            LoginModel login= new LoginModel();
            login.email = username; 
            login.password=password;

            var loginJson =
               new StringContent(JsonSerializer.Serialize(login), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/login", loginJson);

            if (response.IsSuccessStatusCode)
            {
                var loginResponseContent = await response.Content.ReadFromJsonAsync<LoginResult>();
                if (loginResponseContent?.UserName != null)
                {
                   await _localStorageService.SetItemAsync("accessToken", loginResponseContent.Token);
                    ((AuthProvider)_authStateProvider).NotifyUserAuthentication(loginResponseContent.Token);
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResponseContent.Token);
                }
                return loginResponseContent;
            }

            return null;

       }

        public async Task Logout()
        {
             await _localStorageService.RemoveItemAsync("accessToken");
            ((AuthProvider)_authStateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;

        }

    }
}
