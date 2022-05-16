using Boilerplate.Application.DTOs;
using Boilerplate.Application.DTOs.Office;
using Boilerplate.Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Application.Interfaces
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
