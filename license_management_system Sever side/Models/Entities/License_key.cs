using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace license_management_system_Sever_side.Models.Entities
{
 /*   public enum KeyStatus
    {
        Activated,
        Available,
        Expired,
        Check_but_invalid

    }*/
    public class License_key
    {
        [Key, Column("Key_name"), MaxLength(100)]
        [DisplayName("Key")]
        public string? Key_name { get; set; }

        [Column("activation_date")]
        [DisplayName("Activati Date")]
        public DateTime ActivationDate { get; set; }

        [Column("deactivated_Date")]
        [DisplayName("Deactivated Date")]
        public DateTime DeactivatedDate { get; set; }

        [Column("key_status")]
        [DisplayName("Key Status")]
        public string Key_Status { get; set; }

        [Column("macAddress")]
        [DisplayName("Mac Address")]
        public string? MacAddress { get; set; }

        [Column("Clint Id")]
        [DisplayName("Clint Id")]
        public int? ClintId { get; set; }


        [ForeignKey("RequestId")]
        public int RequestId { get; set; }

        [JsonIgnore]
        public RequestKey RequestKey { get; set; }

    }
   
}

