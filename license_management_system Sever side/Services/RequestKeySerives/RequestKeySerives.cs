using AutoMapper;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Services.RequestKeySerives
{
    public class RequestKeySerives : IRequestKeySerives
    {

        DataContext _context;
        IMapper _mapper;

        public RequestKeySerives(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
        //add new request key
        public async Task AddRequestKey(RequestKeyDto requestKey)
        {
            // map the request key dto to request key entity
            var requestKeyEntity = _mapper.Map<RequestKey>(requestKey);

            _context.RequestKeys.Add(requestKeyEntity);
            await _context.SaveChangesAsync();
        }
        
        //get all request keys
        
        public async Task<IEnumerable<RequestKeyDto>> GetAllrequestkeys()
        {
            var requestKeys = await _context.RequestKeys.ToListAsync();
            return _mapper.Map<List<RequestKeyDto>>(requestKeys);
        }
    }
}
