namespace license_management_system_Sever_side.Models.DTOs
{
    public class SendKeyMailDto
    {
        public string To { get; set; } = string.Empty;
       
        public string LicenseKey { get; set; } = string.Empty;

    }
}