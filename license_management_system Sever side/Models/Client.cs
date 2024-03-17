using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Client
    {
        
        [Key] public int CID { get; set; }
        public string? CName { get; set; }
         
        public int TImePeriod { get; set; }

        public string? PartnerRequested { get; set; }
        public string? Email { get; set;}
        public string? Country { get; set; }
        public string? Modules { get; set;}

    }
}
