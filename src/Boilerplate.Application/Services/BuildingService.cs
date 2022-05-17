using AutoMapper;
using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Building;
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
   
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _BuildingRepository;

        private readonly IMapper _mapper;

        public BuildingService(IMapper mapper, IBuildingRepository BuildingRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _BuildingRepository = BuildingRepository ?? throw new ArgumentNullException(nameof(BuildingRepository));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _BuildingRepository.Dispose();
        }

        #region Building Methods

        public async Task<PaginatedList<GetBuildingDTO>> GetAllBuildinges(GetBuildingesFilter filter)
        {

            var Buildings = _BuildingRepository.GetAllFilter<GetBuildingesFilter>(filter)
                .WhereIf(filter.OfficeId != null, x => x.OfficeId == filter.OfficeId)
                .WhereIf(!string.IsNullOrEmpty(filter.Name), x => x.Name == filter.Name); 


            return await _mapper.ProjectTo<GetBuildingDTO>(Buildings).ToPaginatedListAsync(filter.CurrentPage, filter.PageSize);
        }

        public async Task<GetBuildingDTO> GetBuildingById(Guid id)
        {
            return _mapper.Map<GetBuildingDTO>(await _BuildingRepository.GetById(id));
        }

        public async Task<GetBuildingDTO> CreateBuilding(CreateBuildingDto _Building)
        {
            var created = _BuildingRepository.Create(_mapper.Map<Building>(_Building));
            await _BuildingRepository.SaveChangesAsync();
            return _mapper.Map<GetBuildingDTO>(created);
        }

        public async Task<GetBuildingDTO> UpdateBuilding(Guid id, UpdateBuildingDTO updatedBuilding)
        {
            var originalBuilding = await _BuildingRepository.GetById(id);
            if (originalBuilding == null) return null;


            _BuildingRepository.Update(originalBuilding);
            await _BuildingRepository.SaveChangesAsync();
            return _mapper.Map<GetBuildingDTO>(originalBuilding);
        }

        public async Task<bool> DeleteBuilding(Guid id)
        {
            await _BuildingRepository.Delete(id);
            return await _BuildingRepository.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
