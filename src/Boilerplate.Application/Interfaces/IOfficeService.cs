using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Office;
using ImmoGest.Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Application.Interfaces
{
  
    public interface IOfficeService : IDisposable
    {
        #region Office Methods

        public Task<PaginatedList<GetOfficeDTO>> GetAllOfficees(GetOfficeFilter filter);

        public Task<GetOfficeDTO> GetOfficeById(Guid id);

        public Task<GetOfficeDTO> CreateOffice(CreateOfficeDto Office);

        public Task<GetOfficeDTO> UpdateOffice(Guid id, UpdateOfficeDTO updatedOffice);

        public Task<bool> DeleteOffice(Guid id);

        #endregion
    }
}
