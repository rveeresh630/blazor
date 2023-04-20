using BethanypieShopsHRM.Api.Repository;

using BethanysPieShopHRM.Shared.Domain;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;

namespace BethanypieShopsHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_countryRepository.GetAllCountries());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            return Ok(_countryRepository.GetCountryById(id));
        }
    }
}
