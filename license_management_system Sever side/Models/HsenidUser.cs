using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class HsenidUser
    {
        [Key] public int Id { get; set; }
        public int EmpID {  get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Department { get; set; }
    }
}
