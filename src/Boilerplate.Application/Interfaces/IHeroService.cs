using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.Hero;
using ImmoGest.Application.Filters;

namespace ImmoGest.Application.Interfaces
{
    public interface IHeroService : IDisposable
    {
        #region Hero Methods

        public Task<PaginatedList<GetHeroDto>> GetAllHeroes(GetHeroesFilter filter);

        public Task<GetHeroDto> GetHeroById(Guid id);

        public Task<GetHeroDto> CreateHero(CreateHeroDto hero);

        public Task<GetHeroDto> UpdateHero(Guid id, UpdateHeroDto updatedHero);

        public Task<bool> DeleteHero(Guid id);

        #endregion
    }
}