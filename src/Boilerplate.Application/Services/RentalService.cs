using AutoMapper;
using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Rental;
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

    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _RentalRepository;

        private readonly IMapper _mapper;

        public RentalService(IMapper mapper, IRentalRepository RentalRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _RentalRepository = RentalRepository ?? throw new ArgumentNullException(nameof(RentalRepository));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _RentalRepository.Dispose();
        }

        #region Rental Methods

        public async Task<PaginatedList<GetRentalDTO>> GetAllRentales(GetRentalesFilter filter)
        {

            var Rentals = _RentalRepository.GetAllFilter<GetRentalesFilter>(filter)
                  .Where( x => x.OfficeId == filter.OfficeId)
                   .WhereIf(filter.PropertyId != null, x => x.PropertyId == filter.PropertyId)
                    .WhereIf(filter.ClientId != null, x => x.ClientId == filter.ClientId);


            return await _mapper.ProjectTo<GetRentalDTO>(Rentals).ToPaginatedListAsync(filter.CurrentPage, filter.PageSize);
        }

        public async Task<GetRentalDTO> GetRentalById(Guid id)
        {
            return _mapper.Map<GetRentalDTO>(await _RentalRepository.GetById(id));
        }

        public async Task<GetRentalDTO> CreateRental(CreateRentalDto _Rental)
        {
            var created = _RentalRepository.Create(_mapper.Map<Rental>(_Rental));

            await _RentalRepository.SaveChangesAsync();
            return _mapper.Map<GetRentalDTO>(created);
        }

        public async Task<GetRentalDTO> UpdateRental(Guid id, UpdateRentalDTO updatedRental)
        {
            var originalRental = await _RentalRepository.GetById(id);
            if (originalRental == null) return null;


            _RentalRepository.Update(originalRental);
            await _RentalRepository.SaveChangesAsync();
            return _mapper.Map<GetRentalDTO>(originalRental);
        }

        public async Task<bool> DeleteRental(Guid id)
        {
            await _RentalRepository.Delete(id);
            return await _RentalRepository.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
