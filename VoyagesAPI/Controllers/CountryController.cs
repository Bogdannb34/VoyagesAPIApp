using Microsoft.AspNetCore.Mvc;
using VoyagesAPI.Entities;
using VoyagesAPI.Interfaces;

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

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(await countryRepo.GetCountriesAsync());
        }
        
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCountry([FromBody] Country country)
        {
            await countryRepo.AddCountryAsync(country);
            //return CreatedAtAction(nameof(GetCountryById), new {id = country.CountryId}, country);
            return Created("Countries", country);
        } 

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCountryById([FromRoute] int id)
        {
            var exists = await countryRepo.GetByIdAsync(id);
            return exists == null ? BadRequest("Country not found!") : Ok(exists);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] Country country)
        {
            var updated = await countryRepo.UpdateCountryAsync(country);
            if (updated)
            {
                return Ok("Country updated successfully!");
            }
            return BadRequest("Country not found!");
        }

        [HttpDelete]
        [Route("del/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await countryRepo.DeleteCountryAsync(id);
            if(deleted)
            {
                return NoContent();
            }
            return BadRequest("Country not found!");
        }
    }
}
