using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

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

        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Website { get; set; }
        public string? Industry { get; set; }
        public string? AdditionalInfo { get; set; }

        [JsonIgnore]
        public virtual ICollection<RequestKey>? RequestKeys { get; set; }


        // Foreign key property for Partner
        public int PartnerId { get; set; }

        // Navigation property for Partner
        [ForeignKey("PartnerId")]
        public virtual Partner? Partner { get; set; }

    }
}
