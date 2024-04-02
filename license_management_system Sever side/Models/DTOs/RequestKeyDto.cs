using license_management_system_Sever_side.Models.Entities;

namespace license_management_system_Sever_side.Models.DTOs
{
    public class RequestKeyDto
    {
        public int RequestID { get; set; }
        public RequestStatus isFinanceApproval { get; set; }
        public RequestStatus isPartnerApproval { get; set; }
        public string? CommentFinaceMgt { get; set; }
        public string? CommentPartnerMgt { get; set; }
        public int NumberOfDays { get; set; }

    }
}
