using System.ComponentModel.DataAnnotations;

namespace license_management_system_Sever_side.Models
{
    public class Key
    {

        [Key]
        public int Cid { get; set; }
        public string? Hos { get; set; }

        public string? SerMac { get; set; }
        public int ValidDate { get; set; }
        public Boolean BFI { get; set; } = false;
        public Boolean MR { get; set; } = false;
        public Boolean Retail { get; set; } = false;
        public string? Modules { get; set; }

    }
}
