using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


namespace license_management_system_Sever_side.Models.Entities
{
    public class User
    {
        
        public int Id { get; set; }

        public string UserId { get; set; } 
        public string Name { get; set; }

        public string Email { get; set; }
          
    }
    public enum Role
    {
        PartnerManager,
        Partner,
        FinanceManager
    }
   
}
