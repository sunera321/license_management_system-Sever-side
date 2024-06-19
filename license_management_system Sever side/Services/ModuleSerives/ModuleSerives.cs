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

        //update module
        public async Task UpdateModule(ModuleDto module)
        {
            // map the module dto to module entity
            var moduleEntity = _mapper.Map<Modules>(module);

            _context.Modules.Update(moduleEntity);
            await _context.SaveChangesAsync();
        }
        //get module statistics
        public async Task<List<ModuleStatisticDTO>> GetModuleStatistics()
        {
            var query = @"SELECT a.name, COUNT(b.moduleId) AS total 
                      FROM Modules a 
                      INNER JOIN EndClientModules b ON a.id = b.moduleId 
                      GROUP BY a.name;";

            var result = await _context.Set<ModuleStatisticDTO>()
                                       .FromSqlRaw(query)
                                       .ToListAsync();
            return result;
        }

    }
}
