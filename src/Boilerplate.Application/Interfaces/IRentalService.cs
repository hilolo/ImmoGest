using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Rental;
using ImmoGest.Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Application.Interfaces
{
   
    public interface IRentalService
    {
        #region Rental Methods

        public Task<PaginatedList<GetRentalDTO>> GetAllRentales(GetRentalesFilter filter);

        public Task<GetRentalDTO> GetRentalById(Guid id);

        public Task<GetRentalDTO> CreateRental(CreateRentalDto Rental);

        public Task<GetRentalDTO> UpdateRental(Guid id, UpdateRentalDTO updatedRental);

        public Task<bool> DeleteRental(Guid id);

        #endregion
    }
}
