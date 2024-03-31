using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

namespace license_management_system_Sever_side.Models
{
    public class Key
    {

        [Key]
        public int Cid { get; set; }
        public string? ClientID {  get; set; } 
        public string? Hos { get; set; }

        public string? SerMac { get; set; }
        public int ValidDate { get; set; }
        public Boolean BFI { get; set; } = false;
        public Boolean MR { get; set; } = false;
        public Boolean Retail { get; set; } = false;

        public string? Modules { get; set; }

        // Serialize the Modules property to JSON when setting
        [NotMapped]
        public List<string>? ModulesList
        {
            get => Modules != null ? JsonConvert.DeserializeObject<List<string>>(Modules) : null;
            set => Modules = value != null ? JsonConvert.SerializeObject(value) : null;
        }


    }
}
