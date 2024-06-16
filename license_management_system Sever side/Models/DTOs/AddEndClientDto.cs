using license_management_system_Sever_side.Models.Entities;

namespace license_management_system_Sever_side.Models.DTOs
{
    public class AddEndClientDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Website { get; set; }
        public string? Industry { get; set; }
        public string? AdditionalInfo { get; set; }
        public int PartnerId { get; set; }

        public List<int> ModuleIds { get; set; } = new List<int>();

    }
}
