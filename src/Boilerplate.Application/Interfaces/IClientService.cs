using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Client;
using ImmoGest.Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImmoGest.Application.Interfaces
{
    public interface IClientService : IDisposable
    {
        #region Client Methods

        public Task<PaginatedList<GetClientDTO>> GetAllClientes(GetClientesFilter filter);

        public Task<GetClientDTO> GetClientById(Guid id);

        public Task<GetClientDTO> CreateClient(CreateClientDto Client);

        public Task<GetClientDTO> UpdateClient(Guid id, UpdateClientDTO updatedClient);

        public Task<bool> DeleteClient(Guid id);

        #endregion
    }
}


