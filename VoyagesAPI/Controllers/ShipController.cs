using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagesAPI.Entities;
using VoyagesAPI.Interfaces;

namespace VoyagesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private readonly IShipRepo shipRepo;

        public ShipController(IShipRepo _shipRepo)
        {
            this.shipRepo = _shipRepo;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllShips()
        {
            return Ok(await shipRepo.GetAllAsync());
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddShip([FromBody] Ship ship)
        {
            await shipRepo.AddShipAsync(ship);
            return Created("Ships", ship);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetShipById([FromRoute] int id)
        {
            var exists = await shipRepo.GetByIdAsync(id);
            return exists == null ? BadRequest("Ship not found!") : Ok(exists);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateShip([FromBody] Ship ship)
        {
            var edit = await shipRepo.UpdateShipAsync(ship);
            if(edit)
            {
                return Ok("Updated Successfully!");
            }
            return BadRequest("Update failed!");
        }
        
        [HttpDelete]
        [Route("del/{id}")]
        public async Task<IActionResult> DeleteShip([FromRoute] int id)
        {
            var deleted = await shipRepo.DeleteShipAsync(id);
            if (deleted)
            {
                return NoContent();
            }
            return BadRequest("Ship not found!");
        }

    }
}
