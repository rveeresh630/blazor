using BethanysPieShopHRM.Shared.Domain;
using System;

namespace BethanypieShopsHRM.Api.Repository
{
    public class CountryRepository: ICountryRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public CountryRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _appDbContext.Countries;
        }

        public Country GetCountryById(int countryId)
        {
            return _appDbContext.Countries.FirstOrDefault(c => c.CountryId == countryId);
        }
    }
}
