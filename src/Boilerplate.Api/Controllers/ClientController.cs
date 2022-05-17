using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Client;
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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _ClientService;

        public ClientController(IClientService ClientService)
        {
            _ClientService = ClientService;
        }


        /// <summary>
        /// Returns all Clientes in the database
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetClientDTO>>> GetClientes([FromQuery] GetClientesFilter filter)
        {
            return Ok(await _ClientService.GetAllClientes(filter));
        }


        /// <summary>
        /// Get one Client by id from the database
        /// </summary>
        /// <param name="id">The Client's ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetClientDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetClientDTO>> GetClientById(Guid id)
        {
            var Client = await _ClientService.GetClientById(id);
            if (Client == null) return NotFound();
            return Ok(Client);
        }

        /// <summary>
        /// Insert one Client in the database
        /// </summary>
        /// <param name="dto">The Client information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GetClientDTO>> Create([FromBody] CreateClientDto dto)
        {
            var newClient = await _ClientService.CreateClient(dto);
            return CreatedAtAction(nameof(GetClientById), new { id = newClient.Id }, newClient);

        }

        /// <summary>
        /// Update a Client from the database
        /// </summary>
        /// <param name="id">The Client's ID</param>
        /// <param name="dto">The update object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<GetClientDTO>> Update(Guid id, [FromBody] UpdateClientDTO dto)
        {

            var updatedClient = await _ClientService.UpdateClient(id, dto);

            if (updatedClient == null) return NotFound();

            return NoContent();
        }


        /// <summary>
        /// Delete a Client from the database
        /// </summary>
        /// <param name="id">The Client's ID</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _ClientService.DeleteClient(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
