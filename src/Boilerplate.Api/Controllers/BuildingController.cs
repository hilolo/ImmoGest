using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Building;
using ImmoGest.Application.Filters;
using ImmoGest.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ImmoGest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _BuildingService;

        public BuildingController(IBuildingService BuildingService)
        {
            _BuildingService = BuildingService;
        }


        /// <summary>
        /// Returns all Buildinges in the database
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetBuildingDTO>>> GetBuildinges([FromQuery] GetBuildingesFilter filter)
        {
            return Ok(await _BuildingService.GetAllBuildinges(filter));
        }


        /// <summary>
        /// Get one Building by id from the database
        /// </summary>
        /// <param name="id">The Building's ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetBuildingDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetBuildingDTO>> GetBuildingById(Guid id)
        {
            var Building = await _BuildingService.GetBuildingById(id);
            if (Building == null) return NotFound();
            return Ok(Building);
        }

        /// <summary>
        /// Insert one Building in the database
        /// </summary>
        /// <param name="dto">The Building information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GetBuildingDTO>> Create([FromBody] CreateBuildingDto dto)
        {
            var newBuilding = await _BuildingService.CreateBuilding(dto);
            return CreatedAtAction(nameof(GetBuildingById), new { id = newBuilding.Id }, newBuilding);

        }

        /// <summary>
        /// Update a Building from the database
        /// </summary>
        /// <param name="id">The Building's ID</param>
        /// <param name="dto">The update object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<GetBuildingDTO>> Update(Guid id, [FromBody] UpdateBuildingDTO dto)
        {

            var updatedBuilding = await _BuildingService.UpdateBuilding(id, dto);

            if (updatedBuilding == null) return NotFound();

            return NoContent();
        }


        /// <summary>
        /// Delete a Building from the database
        /// </summary>
        /// <param name="id">The Building's ID</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _BuildingService.DeleteBuilding(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
