using AutoMapper;
using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Client;
using ImmoGest.Application.Extensions;
using ImmoGest.Application.Filters;
using ImmoGest.Application.Interfaces;
using ImmoGest.Domain.Entities;
using ImmoGest.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImmoGest.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _ClientRepository;

        private readonly IMapper _mapper;

        public ClientService(IMapper mapper, IClientRepository ClientRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _ClientRepository = ClientRepository ?? throw new ArgumentNullException(nameof(ClientRepository));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _ClientRepository.Dispose();
        }

        #region Client Methods

        public async Task<PaginatedList<GetClientDTO>> GetAllClientes(GetClientesFilter filter)
        {

            var Clients = _ClientRepository.GetAllFilter<GetClientesFilter>(filter)
                .WhereIf(filter.TypeClient != null, x => x.TypeClient == filter.TypeClient)
                .WhereIf(filter.TypeTransaction != null, x => x.TypeTransaction == filter.TypeTransaction)
                .WhereIf(!string.IsNullOrEmpty(filter.Name), x => x.Name == filter.Name); ;
               

            return await _mapper.ProjectTo<GetClientDTO>(Clients).ToPaginatedListAsync(filter.CurrentPage, filter.PageSize) ;
        }

        public async Task<GetClientDTO> GetClientById(Guid id)
        {
            return _mapper.Map<GetClientDTO>(await _ClientRepository.GetById(id));
        }

        public async Task<GetClientDTO> CreateClient(CreateClientDto _client)
        {
            var created = _ClientRepository.Create(_mapper.Map<Client>(_client));
            await _ClientRepository.SaveChangesAsync();
            return _mapper.Map<GetClientDTO>(created);
        }

        public async Task<GetClientDTO> UpdateClient(Guid id, UpdateClientDTO updatedClient)
        {
            var originalClient = await _ClientRepository.GetById(id);
            if (originalClient == null) return null;

            
            _ClientRepository.Update(originalClient);
            await _ClientRepository.SaveChangesAsync();
            return _mapper.Map<GetClientDTO>(originalClient);
        }

        public async Task<bool> DeleteClient(Guid id)
        {
            await _ClientRepository.Delete(id);
            return await _ClientRepository.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
