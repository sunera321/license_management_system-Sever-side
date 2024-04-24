using System.Text.Json.Serialization;

namespace license_management_system_Sever_side.Models.Entities
{
    public class Partner : User
    {
  
        [JsonIgnore]
        public Role UserRole { get; set; }=Role.Partner;

        [JsonIgnore]
        // Navigation property for the related EndClients
        public virtual ICollection<EndClient>? EndClients { get; set; }

        [JsonIgnore]
        // Navigation property for the related EndClients
        public virtual ICollection<RequestKey>? RequestKeys { get; set; }

    }
}
