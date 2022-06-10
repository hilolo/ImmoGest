using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Rental;
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
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _RentalService;

        public RentalController(IRentalService RentalService)
        {
            _RentalService = RentalService;
        }


        /// <summary>
        /// Returns all Rentales in the database
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetRentalDTO>>> GetRentales([FromQuery] GetRentalesFilter filter)
        {
            return Ok(await _RentalService.GetAllRentales(filter));
        }


        /// <summary>
        /// Get one Rental by id from the database
        /// </summary>
        /// <param name="id">The Rental's ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetRentalDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetRentalDTO>> GetRentalById(Guid id)
        {
            var Rental = await _RentalService.GetRentalById(id);
            if (Rental == null) return NotFound();
            return Ok(Rental);
        }

        /// <summary>
        /// Insert one Rental in the database
        /// </summary>
        /// <param name="dto">The Rental information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GetRentalDTO>> Create([FromBody] CreateRentalDto dto)
        {
            var newRental = await _RentalService.CreateRental(dto);
            return CreatedAtAction(nameof(GetRentalById), new { id = newRental.Id }, newRental);

        }

        /// <summary>
        /// Update a Rental from the database
        /// </summary>
        /// <param name="id">The Rental's ID</param>
        /// <param name="dto">The update object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<GetRentalDTO>> Update(Guid id, [FromBody] UpdateRentalDTO dto)
        {

            var updatedRental = await _RentalService.UpdateRental(id, dto);

            if (updatedRental == null) return NotFound();

            return NoContent();
        }


        /// <summary>
        /// Delete a Rental from the database
        /// </summary>
        /// <param name="id">The Rental's ID</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _RentalService.DeleteRental(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
