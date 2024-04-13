namespace license_management_system_Sever_side.Models.DTOs
{
    public class License_keyDto
    {
        public string? Key_name { get; set; }
        public DateTime ActivationDate { get; set; }
        
        public int RequestId { get; set; }
    }
}
