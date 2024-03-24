using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace license_management_system_Sever_side.Models
{
    public class RequestKey
    {
        [Key]
        public int RequestId { get; set; }
        public string Key { get; set; }
        public DateTime RequiredTime { get; set; }
        public bool isFinanceApproval {  get; set; }=false;
        public bool isPartnerMgrApproval { get; set; } = false; 
        public string? CommentFinaceMgt { get; set; }=null;
        public string? CommentPartnerMgt { get; set; }=null;
        public string Status { get; set; }

        [JsonIgnore]
        public virtual ICollection<Module> modules { get; set; }

        [JsonIgnore]
        public virtual ICollection<EndClient> endClients { get; set; }

        [JsonIgnore]
        public virtual licenseKey licenseKey { get; set; }

        [ForeignKey("Partner")]
        public int PartnerId { get; set; }
        [JsonIgnore]
        public virtual Partner partner { get; set; }

        public virtual ICollection<PartnerManager> partnersManager { get; set; }
        public virtual ICollection<FinaceManager> finaceManager { get; set; }

    }
}
