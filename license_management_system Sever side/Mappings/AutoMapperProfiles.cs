using AutoMapper;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using System.Numerics;

namespace license_management_system_Sever_side.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            
            CreateMap<EndClient, AddEndClientDto>().ReverseMap();
            CreateMap<RequestKey, RequestKeyDto>().ReverseMap();
            CreateMap<Modules, ModuleDto>().ReverseMap();
           
        }
    }
}
