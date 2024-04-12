namespace license_management_system_Sever_side.Models.DTOs
{
    public class SendClintMailDto
    {
        public string To { get; set; } = string.Empty;
        public string Name { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ContactInfo { get; set; }

    }
}
