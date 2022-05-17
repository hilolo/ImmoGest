using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Building;
using ImmoGest.Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Application.Interfaces
{
    public interface IBuildingService 
    {
        #region Building Methods

        public Task<PaginatedList<GetBuildingDTO>> GetAllBuildinges(GetBuildingesFilter filter);

        public Task<GetBuildingDTO> GetBuildingById(Guid id);

        public Task<GetBuildingDTO> CreateBuilding(CreateBuildingDto Building);

        public Task<GetBuildingDTO> UpdateBuilding(Guid id, UpdateBuildingDTO updatedBuilding);

        public Task<bool> DeleteBuilding(Guid id);

        #endregion
    }
}
