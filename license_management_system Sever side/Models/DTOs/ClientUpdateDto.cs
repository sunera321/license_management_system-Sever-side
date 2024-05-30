namespace license_management_system_Sever_side.Models.DTOs
{
    public class ClientUpdateDto
    {
        public string? Website { get; set; }
        public string? MackAddress { get; set; }
        public string? HostUrl { get; set; }

        public int ModuleID { get; set; }
    }
}
