using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Office;
using ImmoGest.Application.Filters;
using ImmoGest.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ImmoGest.Api.Controllers
{
  
        [ApiController]
        [Route("api/[controller]")]

        public class OfficeController : ControllerBase
        {
            private readonly IOfficeService _officeService;

            public OfficeController(IOfficeService officeService)
            {
                _officeService = officeService;
            }



            /// <summary>
            /// Returns all heroes in the database
            /// </summary>
            /// <param name="filter"></param>
            /// <returns></returns>
            [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<PaginatedList<GetOfficeDTO>>> GetOffices([FromQuery] GetOfficeFilter filter)
            {
                return Ok(await _officeService.GetAllOfficees(filter));

            }


            /// <summary>
            /// Get one hero by id from the database
            /// </summary>
            /// <param name="id">The hero's ID</param>
            /// <returns></returns>
            [HttpGet]
            [Route("{id}")]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(typeof(GetOfficeDTO), StatusCodes.Status200OK)]
            public async Task<ActionResult<GetOfficeDTO>> GetHeroById(Guid id)
            {
                var hero = await _officeService.GetOfficeById(id);
                if (hero == null) return NotFound();
                return Ok(hero);
            }

            /// <summary>
            /// Insert one hero in the database
            /// </summary>
            /// <param name="dto">The hero information</param>
            /// <returns></returns>
            [HttpPost]
            [AllowAnonymous]
            public async Task<ActionResult<GetOfficeDTO>> Create([FromBody] CreateOfficeDto dto)
            {
                var newOffice = await _officeService.CreateOffice (dto);
                return CreatedAtAction(nameof(GetHeroById), new { id = newOffice.Id }, newOffice);

            }

            /// <summary>
            /// Update a hero from the database
            /// </summary>
            /// <param name="id">The hero's ID</param>
            /// <param name="dto">The update object</param>
            /// <returns></returns>
            [HttpPut("{id}")]
            public async Task<ActionResult<GetOfficeDTO>> Update(Guid id, [FromBody] UpdateOfficeDTO dto)
            {

                var updatedHero = await _officeService.UpdateOffice(id, dto);

                if (updatedHero == null) return NotFound();

                return NoContent();
            }


            /// <summary>
            /// Delete a hero from the database
            /// </summary>
            /// <param name="id">The hero's ID</param>
            /// <returns></returns>
            [HttpDelete]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [Route("{id}")]
            public async Task<ActionResult> Delete(Guid id)
            {
                var deleted = await _officeService.DeleteOffice(id);
                if (deleted) return NoContent();
                return NotFound();
            }
        }
    
}
