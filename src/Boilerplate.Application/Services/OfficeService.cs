using AutoMapper;
using Boilerplate.Application.DTOs;
using Boilerplate.Application.DTOs.Office;
using Boilerplate.Application.Filters;
using Boilerplate.Application.Interfaces;
using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Application.Services
{

    public class OfficeService : IOfficeService
    {

        private readonly IOfficeRepository _officeRepository;

        private readonly IMapper _mapper;

        public OfficeService(IMapper mapper, IOfficeRepository officeRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _officeRepository = officeRepository ?? throw new ArgumentNullException(nameof(officeRepository));
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _officeRepository.Dispose();
        }

      
        public async Task<GetOfficeDTO> CreateOffice(CreateOfficeDto Office)
        {
            var created = _officeRepository.Create(_mapper.Map<Office>(Office));
            await _officeRepository.SaveChangesAsync();
            return _mapper.Map<GetOfficeDTO>(created);
        }

        public async Task<bool> DeleteOffice(Guid id)
        {
            await _officeRepository.Delete(id);
            return await _officeRepository.SaveChangesAsync() > 0;
        }

      

        public async  Task<PaginatedList<GetOfficeDTO>> GetAllOfficees(GetOfficeFilter filter)
        {

            var offices = _officeRepository
                .GetAll();
                
            return await _mapper.ProjectTo<GetOfficeDTO>(offices).ToPaginatedListAsync(filter.CurrentPage, filter.PageSize);
        }

        public async Task<GetOfficeDTO> GetOfficeById(Guid id)
        {
            return _mapper.Map<GetOfficeDTO>(await _officeRepository.GetById(id));
        }

        public async  Task<GetOfficeDTO> UpdateOffice(Guid id, UpdateOfficeDTO updatedOffice)
        {
            throw new NotImplementedException();
        }
    }
}
