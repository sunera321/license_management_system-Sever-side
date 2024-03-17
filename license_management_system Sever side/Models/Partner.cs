using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Partner
    {

        [Key] public int PId { get; set; }
        
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }

    }
}
