using System.ComponentModel.DataAnnotations;

namespace license_management_system_Sever_side.Models
{
    public class ClientST
    {
        [Key] 
        public int CID { get; set; }
        public string? CName { get; set; }

        public int TImePeriod { get; set; }

        public string? PartnerRequested { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? Modules { get; set; }

        public Boolean Partner { get; set; } = false;
        public Boolean Finance { get; set; } = false;
    }
}
