using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace license_management_system_Sever_side.Models.Entities
{
    public class LicenseKey
    {
        [Key, Column("key_id")]
        [DisplayName("Key ID")]
        public int Id { get; set; }

        [Column("Key_name"), MaxLength(50)]
        [DisplayName("Key")]
        public  string? Key_name { get; set; }

        [Column("activation_date")]
        [DisplayName("Activati Date")]
        public DateTime ActivationDate { get; set; }

        [Column("deactivated_Date")]
        [DisplayName("Deactivated Date")]
        public DateTime DeactivatedDate { get; set; }

        [ForeignKey("request_id")]
        public int? RequestID { get; set; }
        // Navigation property back to LicenseKey

        public virtual RequestKey? RequestKey{ get; set; }




    }
}
