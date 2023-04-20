using BethanysPieShopHRM.Shared.Domain;

namespace BethanypieShopsHRM.Api.Repository
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}
