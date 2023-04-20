using BethanysPieShopHRM.Shared.Domain;

using Microsoft.EntityFrameworkCore;

using System.Security.Cryptography;
using System.Text;

namespace BethanypieShopsHRM.Api.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public UserRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<LoginModel> AuthenticateUser(string email, string password)
        {
            return await _appDbContext.Login.FirstOrDefaultAsync(u => u.email == email && u.password == password);
        }
        public async Task<LoginModel> AddUser(string email, string password)
        {
            return await _appDbContext.Login.FirstOrDefaultAsync(u => u.email == email && u.password == password);
        }
    }
}
