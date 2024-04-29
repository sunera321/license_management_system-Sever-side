namespace license_management_system_Sever_side.Models.DTOs
{
    public class ClientServerInfoDto
    {
        public string HostUrl { get; set; }
        public string MacAddress { get; set; }
        public string LicenceKey { get; set; }
        public string[] SiteNames { get; set; }
    }
}
