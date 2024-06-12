namespace license_management_system_Sever_side.Models.DTOs
{
    public class ClientUpdateDto
    {
        public string? Website { get; set; }
        public string? MackAddress { get; set; }
        public string? HostUrl { get; set; }

        // Change EndClientModules from int to List<int>
        public List<int> EndClientModules { get; set; } = new List<int>();
    }
}
