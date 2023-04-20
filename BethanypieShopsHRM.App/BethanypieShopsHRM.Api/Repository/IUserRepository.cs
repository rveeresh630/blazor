using BethanysPieShopHRM.Shared.Domain;

namespace BethanypieShopsHRM.Api.Repository
{
    public interface IUserRepository
    {
        Task<LoginModel> AuthenticateUser(string email, string password);
        Task<LoginModel> AddUser(string email, string password);
    }
}
