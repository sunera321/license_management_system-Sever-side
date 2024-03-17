using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class LicenseKey
    {
        [Key] public int CID { get; set; }
        public string? HostURL { get; set; }

        public string? ServerMacAddress { get; set; }
        public DateTime ValidDateUntil { get; set; }
        public string? Modules { get; set; }

       
    }
}
