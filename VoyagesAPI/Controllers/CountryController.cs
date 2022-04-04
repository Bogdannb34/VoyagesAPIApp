using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagesAPI.Entities;
using VoyagesAPI.Interfaces;
using VoyagesAPI.Repository;

namespace VoyagesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly ICountryRepo countryRepo;

        public CountryController(ICountryRepo _countryRepo)
        {
            this.countryRepo = _countryRepo;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await countryRepo.GetCountriesAsync();
            return Ok(countries);
        } 
    }
}
