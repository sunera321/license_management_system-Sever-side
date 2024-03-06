using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace license_management_system_Sever_side.Models
{
    public class PartnerManager :user
    {
        [ForeignKey("RequestKey")]
        public int RequestId { get; set; }
        [JsonIgnore]
        public virtual RequestKey requestKey { get; set; }
    }
}
