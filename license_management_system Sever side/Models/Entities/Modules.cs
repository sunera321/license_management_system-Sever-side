using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

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

        [Column("image path"), MaxLength(100)]
        [DisplayName("Image Path")]
        public string ImagePath { get; set; }

        [Column("created data")]
        [DisplayName("Created Data")]
        public DateTime CreatedData { get; set; } = System.DateTime.Now;

        [Column("features"), MaxLength(100)]
        [DisplayName("Features")]
        public string Features { get; set; }

        [Column("module description"), MaxLength(100)]
        [DisplayName("Module Description")]
        public string ModuleDescription { get; set; }

        // Navigation property for many-to-many relationship
        public virtual ICollection<EndClientModule> EndClientModules { get; set; } = new List<EndClientModule>();
    }
}
