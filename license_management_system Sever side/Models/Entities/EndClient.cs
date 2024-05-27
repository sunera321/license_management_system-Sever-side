using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Reflection;

namespace license_management_system_Sever_side.Models.Entities
{
    public class EndClient
    {
        

        [Key, Column("id")]
        [DisplayName("Clint ID")]
        public int Id { get; set; }

        [Column("name"), MaxLength(30)]
        [DisplayName("Name")]
        [Required]
        public  string Name { get; set; }

        [Column("email"), MaxLength(50)]
        [DisplayName("Email Address")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Column("phone_number"), MaxLength(15)]
        [DisplayName("Phone Number")]
        public  string? PhoneNumber { get; set; }

        [Column("City"), MaxLength(30)]
        [DisplayName("City")]
        public string? City { get; set; }
        [Column("Region"), MaxLength(30)]
        [DisplayName("Region")]
        public string? Region { get; set; }
        [Column("Country") ]
        [DisplayName("Country")]
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Website { get; set; }
        public string? Industry { get; set; }
        public string? AdditionalInfo { get; set; }

        public DateTime? ActivetDate { get; set; } =null;
        public DateTime? ExpireDate { get; set; } = null;
        public string? MackAddress { get; set; } = null;
        public string? HostUrl { get; set; } = null;

        public int? ModuleID { get; set; } = null;


        // Foreign key property for Partner
        [ForeignKey("PartnerId")]
        public int PartnerId { get; set; }

        // Navigation property for Partner
        [JsonIgnore]
        public virtual Partner? Partner { get; set; }

        

    }
}
