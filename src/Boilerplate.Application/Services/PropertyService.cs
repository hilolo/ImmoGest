using AutoMapper;
using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Property;
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

    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _PropertyRepository;

        private readonly IMapper _mapper;

        public PropertyService(IMapper mapper, IPropertyRepository PropertyRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _PropertyRepository = PropertyRepository ?? throw new ArgumentNullException(nameof(PropertyRepository));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _PropertyRepository.Dispose();
        }

        #region Property Methods

        public async Task<PaginatedList<GetPropertyDTO>> GetAllProperty(GetPropertyFilter filter)
        {

            var Propertys = _PropertyRepository.GetAllFilter<GetPropertyFilter>(filter)
                .Where( x => x.OfficeId == filter.OfficeId)
                .WhereIf(!string.IsNullOrEmpty(filter.identifier), x => x.identifier == filter.identifier)
                .WhereIf(filter.TypeProperty != null, x => x.TypeProperty == filter.TypeProperty)
                .WhereIf(filter.BuildingId != null, x => x.BuildingId == filter.BuildingId);
            

            return await _mapper.ProjectTo<GetPropertyDTO>(Propertys).ToPaginatedListAsync(filter.CurrentPage, filter.PageSize);
        }

        public async Task<GetPropertyDTO> GetPropertyById(Guid id)
        {
            return _mapper.Map<GetPropertyDTO>(await _PropertyRepository.GetById(id));
        }

        public async Task<GetPropertyDTO> CreateProperty(CreatePropertyDto _Property)
        {
            var created = _PropertyRepository.Create(_mapper.Map<Property>(_Property));
            await _PropertyRepository.SaveChangesAsync();
            return _mapper.Map<GetPropertyDTO>(created);
        }

        public async Task<GetPropertyDTO> UpdateProperty(Guid id, UpdatePropertyDTO updatedProperty)
        {
            var originalProperty = await _PropertyRepository.GetById(id);
            if (originalProperty == null) return null;


            _PropertyRepository.Update(originalProperty);
            await _PropertyRepository.SaveChangesAsync();
            return _mapper.Map<GetPropertyDTO>(originalProperty);
        }

        public async Task<bool> DeleteProperty(Guid id)
        {
            await _PropertyRepository.Delete(id);
            return await _PropertyRepository.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
