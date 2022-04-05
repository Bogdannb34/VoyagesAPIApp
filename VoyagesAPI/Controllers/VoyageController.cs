using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagesAPI.Entities;
using VoyagesAPI.Interfaces;

namespace VoyagesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoyageController : ControllerBase
    {
        private readonly IVoyageRepo voyageRepo;

        public VoyageController(IVoyageRepo _voyageRepo)
        {
            this.voyageRepo = _voyageRepo;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllVoyages()
        {
            return Ok(await voyageRepo.GetAllAsync());
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateVoyage([FromBody] Voyage voyage)
        {
            await voyageRepo.CreateVoyageAsync(voyage);
            return Created("Voyages", voyage);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetVoyageById([FromRoute] int id)
        {
            var voyage = await voyageRepo.GetByIdAsync(id);
            return voyage == null ? BadRequest("Voyage not found!") : Ok(voyage);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateVoyage([FromBody] Voyage voyage)
        {
            var edited = await voyageRepo.UpdateAsync(voyage);
            if(edited)
            {
                return Ok("Voyage updated successfully!");
            }
            return BadRequest("Update failed!");
        }

        [HttpDelete]
        [Route("del/{id}")]
        public async Task<IActionResult> DeleteVoyage([FromRoute] int id)
        {
            var deleted = await voyageRepo.DeleteAsync(id);
            if(deleted)
            {
                return NoContent();
            }
            return BadRequest("Voyage not found!");
        }

    }
}
