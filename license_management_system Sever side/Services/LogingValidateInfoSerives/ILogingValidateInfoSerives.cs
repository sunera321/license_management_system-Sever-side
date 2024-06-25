using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace license_management_system_Sever_side.Services.LogingValidateInfoSerives
{
    public interface ILogingValidateInfoSerives
    {
        Task<string> AddClientServerDetailsAsync(ClientServerInfoDto serverdata);
     
    }
}
