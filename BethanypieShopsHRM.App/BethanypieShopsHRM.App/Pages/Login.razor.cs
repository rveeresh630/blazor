using BethanypieShopHRM.App.Services;

using BethanysPieShopHRM.App.Services;

using Microsoft.AspNetCore.Components;

using System.ComponentModel.DataAnnotations;

namespace BethanypieShopsHRM.App.Pages
{
    public partial class Login
    {

        [Inject]
        public IUserService? UserService { get; set; }

        private Model model = new Model();
        private bool loading;
        private string error;

        protected override void OnInitialized()
        {
            // redirect to home if already logged in
            //if (AuthenticationService.User != null)
            //{
            //    NavigationManager.NavigateTo("");
            //}
        }

        private async void HandleValidSubmit()
        {
            loading = true;
            try
            {
                var response=await UserService.AuthenticateUser(model.Username, model.Password);
                if (response!=null)
                {
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    error = "Username or Password is Invalid";
                    loading = false;
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                loading = false;
                StateHasChanged();
            }
        }

        private class Model
        {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }
        }
    }
}
