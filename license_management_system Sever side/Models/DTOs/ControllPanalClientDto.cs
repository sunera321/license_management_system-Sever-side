namespace license_management_system_Sever_side.Models.DTOs
{
    public class ControllPanalClientDto
    {

        public int Id { get; set; }
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
        public string? MackAddress { get; set; }
        public string? HostUrl { get; set; }
        public DateTime? ActivetDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int PartnerId { get; set; }
    }
}