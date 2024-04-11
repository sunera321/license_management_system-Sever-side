using AutoMapper;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;

namespace license_management_system_Sever_side.Services.PartnerSerives
{
    public class PartnerSerives : IPartnerSerives
    {
        DataContext _context;
        IMapper _mapper;

        public PartnerSerives(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }

        // add new partner
        public async Task AddPartner(Partner partner)
        {
            _context.Partners.Add(partner);
            await _context.SaveChangesAsync();
        }

        //get all partners
        public async Task<IEnumerable<Partner>> GetAllPartners()
        {
            return await _context.Partners.ToListAsync();
        }

        //delete partner
        public async Task DeletePartner(int id)
        {
            var result =await _context.Partners.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _context.Partners.Remove(result);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Partner not found");
            }
        }
    }
}
