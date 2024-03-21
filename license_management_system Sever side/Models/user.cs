 using System.ComponentModel.DataAnnotations;

namespace license_management_system_Sever_side.Models
{
    public class user
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserType { get; set; }

    }
}
