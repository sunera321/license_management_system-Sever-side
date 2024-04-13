using System.ComponentModel.DataAnnotations;

namespace license_management_system_Sever_side.Models.Entities
{
    public class ActivateKey
    {
        [Key]
        public int Id { get; set; }
        public string Clint_License_Key { get; set; }
    }
}
