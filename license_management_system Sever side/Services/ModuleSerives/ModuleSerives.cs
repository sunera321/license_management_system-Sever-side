using AutoMapper;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Services.ModuleSerives
{
    public class ModuleSerives : IModuleSerives
    {
        DataContext _context;
        IMapper _mapper;
        public ModuleSerives(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
        //add new module
        public async Task AddModule(ModuleDto AddModule)
        {
            // map the module dto to module entity
            var moduleEntity = _mapper.Map<Modules>(AddModule);

            _context.Modules.Add(moduleEntity);
            await _context.SaveChangesAsync();
        }

        //get all modules
        public async Task<IEnumerable<ModuleDto>> GetAllModule()
        {
            var modules = await _context.Modules.ToListAsync();
            return _mapper.Map<List<ModuleDto>>(modules);
        }

    }
}
