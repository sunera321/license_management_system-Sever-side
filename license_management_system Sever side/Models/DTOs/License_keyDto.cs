namespace license_management_system_Sever_side.Models.DTOs
{
    public class License_keyDto
    {
        public string? Key_name { get; set; }
        public DateTime ActivationDate { get; set; }

        public int RequestId { get; set; }

        public string? Email { get; set; }
        public string? MackAddress { get; set; }
        public string? HostUrl { get; set; }

        public int NumberOfDays { get; set; }

    }
}
