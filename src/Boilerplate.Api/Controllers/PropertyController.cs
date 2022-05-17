using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Property;
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
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _PropertyService;

        public PropertyController(IPropertyService PropertyService)
        {
            _PropertyService = PropertyService;
        }


        /// <summary>
        /// Returns all Property in the database
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetPropertyDTO>>> GetProperty([FromQuery] GetPropertyFilter filter)
        {
            return Ok(await _PropertyService.GetAllProperty(filter));
        }


        /// <summary>
        /// Get one Property by id from the database
        /// </summary>
        /// <param name="id">The Property's ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetPropertyDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetPropertyDTO>> GetPropertyById(Guid id)
        {
            var Property = await _PropertyService.GetPropertyById(id);
            if (Property == null) return NotFound();
            return Ok(Property);
        }

        /// <summary>
        /// Insert one Property in the database
        /// </summary>
        /// <param name="dto">The Property information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GetPropertyDTO>> Create([FromBody] CreatePropertyDto dto)
        {
            var newProperty = await _PropertyService.CreateProperty(dto);
            return CreatedAtAction(nameof(GetPropertyById), new { id = newProperty.Id }, newProperty);

        }

        /// <summary>
        /// Update a Property from the database
        /// </summary>
        /// <param name="id">The Property's ID</param>
        /// <param name="dto">The update object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<GetPropertyDTO>> Update(Guid id, [FromBody] UpdatePropertyDTO dto)
        {

            var updatedProperty = await _PropertyService.UpdateProperty(id, dto);

            if (updatedProperty == null) return NotFound();

            return NoContent();
        }


        /// <summary>
        /// Delete a Property from the database
        /// </summary>
        /// <param name="id">The Property's ID</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _PropertyService.DeleteProperty(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }

}
