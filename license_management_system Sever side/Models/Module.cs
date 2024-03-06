using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace license_management_system_Sever_side.Models
{
    public class Module
    {
        [Key]
        public int moduleId {  get; set; }
        public string moduleName { get; set; }
        public DateTime CreatedData { get; set; }
        public string Features { get; set; }
        public string moduleDescription { get; set; }

        [JsonIgnore]
        public virtual ICollection<RequestKey> requestKeys { get; set; }
    }
}
