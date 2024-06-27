namespace license_management_system_Sever_side.Models.DTOs
{
    public class ClientLicenseInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public string? KeyStatus { get; set; }
    }
}
