using license_management_system_Sever_side.Models.Entities;

namespace license_management_system_Sever_side.Models.DTOs
{
    public class RequestKeyDto
    {


        public Boolean isFinanceApproval { get; set; }

        public Boolean isPartnerApproval { get; set; }

        public string CommentFinaceMgt { get; set; }

        public string CommentPartnerMgt { get; set; }

        public int NumberOfDays { get; set; }

        public int EndClientId { get; set; }


        public int PartnerId { get; set; }

        public int? FinaceManagerId { get; set; }

        public int? PartnerManagerID { get; set; }

        public int? ModuleId { get; set; }

    }
}
