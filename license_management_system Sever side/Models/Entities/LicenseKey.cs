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

        [Column("Key"), MaxLength(50)]
        [DisplayName("Key")]
        public  string Key { get; set; }

        [Column("activation_date")]
        [DisplayName("Activati Date")]
        public DateTime ActivationDate { get; set; }

        [Column("deactivated_Date")]
        [DisplayName("Deactivated Date")]
        public DateTime DeactivatedDate { get; set; }



        // Navigation property for the related RequestKey
        public virtual ICollection<RequestKey> RequestKeys { get; set; }

    }
}
