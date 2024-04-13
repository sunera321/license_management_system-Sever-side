using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace license_management_system_Sever_side.Models.DTOs
{
    public class LicenseKeyDto
    {
        
        public int Id { get; set; }

        public string? Key_name { get; set; }

       
        public DateTime ActivationDate { get; set; }

       
       

        public int RequestId { get; set; }

    }
}
