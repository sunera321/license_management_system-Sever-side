namespace license_management_system_Sever_side.DTOs
{
    public class SendMailDto
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ContactInfo { get; set; }

    }
}
