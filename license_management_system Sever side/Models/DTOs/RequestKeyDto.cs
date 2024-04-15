using license_management_system_Sever_side.Models.Entities;

namespace license_management_system_Sever_side.Models.DTOs
{
    public class RequestKeyDto
    {


        

        public int NumberOfDays { get; set; }

        public int EndClientId { get; set; }


        public int PartnerId { get; set; }


        public int? ModuleId { get; set; }

    }
}
