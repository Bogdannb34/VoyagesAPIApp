using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagesAPI.Entities;
using VoyagesAPI.Interfaces;

namespace VoyagesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortController : ControllerBase
    {
        private readonly IPortRepo portRepo;

        public PortController(IPortRepo _portRepo)
        {
            this.portRepo = _portRepo;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetPorts()
        {
            return Ok(await portRepo.GetAllAsync());
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreatePort([FromBody] Port port)
        {
            await portRepo.AddPortAsync(port);
            return Created("Ports", port);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var found = await portRepo.GetByIdAsync(id);
            return found == null ? BadRequest("Port not found!") : Ok(found); 
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdatePort([FromBody] Port port)
        {
            var updated = await portRepo.UpdatePortAsync(port);
            if (updated)
            {
                return Ok("Port updated successfully!");
            }
            return BadRequest("Update failed!");
        }

        [HttpDelete]
        [Route("del/{id}")]
        public async Task<IActionResult> DeletePort([FromRoute] int id)
        {
            var deleted = await portRepo.DeleteAsync(id);
            if (deleted)
            {
                return NoContent();
            }
            return BadRequest("Port not found!");
        }

    }
}
