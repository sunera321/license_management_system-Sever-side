using license_management_system_Sever_side.Models.Entities;

namespace license_management_system_Sever_side.Models.DTOs
{
    public class RequestKeyDto
    {
     
        public RequestStatus isFinanceApproval { get; set; }
        public RequestStatus isPartnerApproval { get; set; }
        public string? CommentFinaceMgt { get; set; }
        public string? CommentPartnerMgt { get; set; }
        public int NumberOfDays { get; set; }
        public int ClientId { get; set; }
/*        public string MackAddress { get; set; }
        public string HostUrl { get; set; }
*/
    }
}
