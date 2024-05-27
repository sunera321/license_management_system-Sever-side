using System.ComponentModel;

namespace license_management_system_Sever_side.Models.Entities
{
    public class ClinetLoging
    {
      
        public int Id { get; set; }
        public string Clint_License_Key { get; set; }
        public string MacAddress { get; set; }
        public string HostUrl { get; set; }
        public string ClintId { get; set; }
        public string ClintName { get; set; }
        public string ClintEmail { get; set; }
        public string PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerEmail { get; set; }
        public DateTime LoginTime { get; set; }
        public string Status { get; set; }
    }
}
