using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace license_management_system_Sever_side.Models.Entities
{
    public class Modules
    {
        [Key, Column("id")]
        [DisplayName("Module ID")]
        public int ModulesId { get; set; }

        [Column("name"), MaxLength(30)]
        [DisplayName("Name")]
        public string Modulename { get; set; }

        public DateTime CreatedData { get; set; }
        public string Features { get; set; }
        public string ModuleDescription { get; set; }

        [JsonIgnore]
        public ICollection<RequestKey> RequestKey { get; set; }





    }
}
