using System.ComponentModel.DataAnnotations;

namespace license_management_system_Sever_side.Models.Entities
{
    public class Loging_Validetion
    {
        [Key]
        public string LogKey { get; set; } = System.Guid.NewGuid().ToString();

        public DateTime LogTime { get; set; } = DateTime.Now;

        public string LogLicenseKey { get; set; }
        public int? ClintId { get; set; }
        public string ClintName { get; set; }
        public string ClintEmail { get; set; }

        public string LogMacAddress { get; set; }

        public string LogHostUrl { get; set; }

        public int? PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerEmail { get; set; }
        public string? StatusCode { get; set; }


    }
}
