using BethanysPieShopHRM.Shared.Domain;

namespace BethanypieShopHRM.App.Services
{
    public interface IUserService
    {
        Task<LoginResult> AuthenticateUser(string UserName,string Password);
        Task Logout();
    }
}
