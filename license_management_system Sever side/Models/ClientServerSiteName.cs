using System.ComponentModel.DataAnnotations;

namespace license_management_system_Sever_side.Models
{
    public class ClientServerSiteName
    {
        [Key]
        public int Id { get; set; }

        public string? SiteName { get; set; }


        public string? MacAddress { get; set; }

        public ClientServer? ClientServer { get; set; }
    }
}
