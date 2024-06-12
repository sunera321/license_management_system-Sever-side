using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace license_management_system_Sever_side.Models.Entities
{
    public class EndClientModule
    {
        [Key, Column(Order = 0)]
        public int EndClientId { get; set; }

        [Key, Column(Order = 1)]
        public int ModuleId { get; set; }

        // Navigation properties
        public EndClient EndClient { get; set; }
        public Modules Module { get; set; }
    }
}