using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class Activate
    {

        [Key] public int LID { get; set; }
       
        public int HsenidUser { get; set; }
        public int HsenidPartner { get; set; }

        public int CID { get; set; }

        
        [ForeignKey("CID")]
        public LicenseKey LicenseKey { get; set; }


    }
}
