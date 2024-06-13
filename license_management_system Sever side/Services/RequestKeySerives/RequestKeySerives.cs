using AutoMapper;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<bool> SetFinanceApproval(int id)
        {
            var client = await _context.RequestKeys.FindAsync(id);
            if (client == null)
                return false;

            client.isFinanceApproval = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SetPartnerApproval(int id)
        {
            var client = await _context.RequestKeys.FindAsync(id);
            if (client == null)
                return false;

            client.isPartnerApproval = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectFinanceManagement(int requestId, string rejectionReason)
        {
            var requestKey = await _context.RequestKeys.FindAsync(requestId);
            if (requestKey == null)
                return false;

            requestKey.CommentFinaceMgt = rejectionReason;
            requestKey.isFinanceApproval = false;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectPartnerManagement(int requestId, string rejectionReason)
        {
            var requestKey = await _context.RequestKeys.FindAsync(requestId);
            if (requestKey == null)
                return false;

            requestKey.CommentPartnerMgt = rejectionReason;
            requestKey.isPartnerApproval = false;

            await _context.SaveChangesAsync();
            return true;
        }


    }
}