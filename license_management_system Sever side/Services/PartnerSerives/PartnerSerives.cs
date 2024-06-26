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
        public async Task<Partner> AddPartner(Partner partner)
        {
            var partnerExist = await _context.Partners.FirstOrDefaultAsync(x => x.Email == partner.Email);
            if (partnerExist != null)
            {
                throw new Exception("Partner already exist");
            }
            await _context.Partners.AddAsync(partner);
            await _context.SaveChangesAsync();
            return (partner);
          
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
