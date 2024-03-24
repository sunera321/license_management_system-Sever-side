using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace license_management_system_Sever_side.Models
{
    public class EndClient
    {
        [Key]
        public int clientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public string Industry { get; set; }
        public string AdditionalInfo { get; set; }
        public string HostURL { get; set; }


        [JsonIgnore]
        public ClientServer? clientServer { get; set; }

        public string? MacAddress { get; set; }
        //partner shuld fill this field withing the clinet registaion process
        

        [JsonIgnore]
        public virtual ICollection<RequestKey> requestKeys { get; set; }

        [ForeignKey("Partner")]
        public int PartnerId { get; set; }
        
        [JsonIgnore]
        public virtual Partner partner { get; set; }


    }
}
