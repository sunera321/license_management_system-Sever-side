using AutoMapper;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Services.EndClientSerives
{
    public class EndClientService : IEndClientService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EndClientService(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }

        // Add new end client
        public async Task AddEndClient(AddEndClientDto endClientDto)
        {
            // Map the end client dto to end client entity
            var endClientEntity = _mapper.Map<EndClient>(endClientDto);

            // Add the new end client
            _context.EndClients.Add(endClientEntity);
            await _context.SaveChangesAsync();

            // Handle the addition of multiple modules
            foreach (var moduleId in endClientDto.ModuleIds)
            {
                var endClientModule = new EndClientModule
                {
                    EndClientId = endClientEntity.Id,
                    ModuleId = moduleId
                };
                _context.EndClientModules.Add(endClientModule);
            }

            await _context.SaveChangesAsync();
        }

        // Get all clients
        public async Task<IEnumerable<AddEndClientDto>> GetAllEndClients()
        {
            var endClients = await _context.EndClients.ToListAsync();
            return _mapper.Map<List<AddEndClientDto>>(endClients);
        }

        // Update end client
        public async Task UpdateEndClient(AddEndClientDto endClientDto)
        {
            // Map the end client dto to end client entity
            var endClientEntity = _mapper.Map<EndClient>(endClientDto);

            _context.EndClients.Update(endClientEntity);
            await _context.SaveChangesAsync();
        }

        // Delete end client
        public async Task DeleteEndClient(int Id)
        {
            var endClient = await _context.EndClients.FirstOrDefaultAsync(x => x.Id == Id);
            if (endClient != null)
            {
                _context.EndClients.Remove(endClient);
                await _context.SaveChangesAsync();
            }
        }

        // Get clients that have a license key
        public async Task<IEnumerable<ControllPanalClientDto>> GetkeyHasEndClients()
        {
            var endClients = await _context.EndClients.Where(x => x.ActiveDate != null).ToListAsync();
            return _mapper.Map<List<ControllPanalClientDto>>(endClients);
        }
    }
}
