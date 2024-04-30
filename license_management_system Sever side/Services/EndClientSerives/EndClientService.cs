using AutoMapper;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Services.EndClientSerives
{
    public class EndClientService : IEndClientService
    {
        DataContext _context;
        IMapper _mapper;

        public EndClientService(DataContext dataContext, IMapper mapper) 
        { 
            _context = dataContext;
            _mapper = mapper;
        }

        // add new end client
        public async Task AddEndClient(AddEndClientDto endClient)
        {
            // map the end client dto to end client entity
            var endClientEntity = _mapper.Map<EndClient>(endClient);
           

            _context.EndClients.Add(endClientEntity);
            await _context.SaveChangesAsync();

        }

        //get all client
        public async Task<IEnumerable<AddEndClientDto>> GetAllEndClients()
        {

            var endClients = await _context.EndClients.ToListAsync();
            return _mapper.Map<List<AddEndClientDto>>(endClients);
        }
     

        //update end client
        public async Task UpdateEndClient(AddEndClientDto endClient)
        {   
            // map the end client dto to end client entity
            var endClientEntity = _mapper.Map<EndClient>(endClient);

            _context.EndClients.Update(endClientEntity);
            await _context.SaveChangesAsync();
        }


        //delete end client
        public async Task DeleteEndClient(int Id)
        {
            var endClient = await _context.EndClients.FirstOrDefaultAsync(x => x.Id == Id);
            if (endClient != null)
            {
                _context.EndClients.Remove(endClient);
                await _context.SaveChangesAsync();
            }
        }

        ////get only have licenkey client
        public async Task<IEnumerable<ControllPanalClientDto>> GetkeyHasEndClients()
        {
        
            var endClients = await _context.EndClients.Where(x => x.ActivetDate != null).ToListAsync();
            return _mapper.Map<List<ControllPanalClientDto>>(endClients);
        }






    }
}
