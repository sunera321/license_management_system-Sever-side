using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace license_management_system_Sever_side.Models
{
    public class licenseKey
    {
        [Key]
        public int KeyId { get; set; }
        public string LicenseKey { get; set; }
        public DateTime Activetiondate { get; set; }
        public DateTime DeactivatedDta { get; set; }
        public bool IsActive { get; set; }
        public bool IsIssused { get; set; }
        public bool IsExpired { get; set; }

        public int RequestId { get; set; }
        [JsonIgnore]
        public virtual RequestKey requestKey { get; set; }


    }
}
