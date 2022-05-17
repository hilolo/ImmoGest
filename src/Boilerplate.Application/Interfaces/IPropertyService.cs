using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Property;
using ImmoGest.Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Application.Interfaces
{
   

    public interface IPropertyService
    {
        #region Property Methods

        public Task<PaginatedList<GetPropertyDTO>> GetAllProperty(GetPropertyFilter filter);

        public Task<GetPropertyDTO> GetPropertyById(Guid id);

        public Task<GetPropertyDTO> CreateProperty(CreatePropertyDto Property);

        public Task<GetPropertyDTO> UpdateProperty(Guid id, UpdatePropertyDTO updatedProperty);

        public Task<bool> DeleteProperty(Guid id);

        #endregion
    }
}
