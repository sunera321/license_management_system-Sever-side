using license_management_system_Sever_side.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace license_management_system_Sever_side.Models.Entities
{
    public class ClientServerInfo
    {
            // need ro remove

            [Key]
            public string? MacAddress { get; set; }

            public string? HostUrl { get; set; }

            public string licenceKey { get; set; }

            public DateTime testDate { get; set; }

            [JsonIgnore]
            public virtual ICollection<ClientServerSiteName>? SiteNames { get; set; }


    }
}
