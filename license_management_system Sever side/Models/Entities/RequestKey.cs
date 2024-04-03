using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Foolproof;

namespace license_management_system_Sever_side.Models.Entities
{
    public class RequestKey
    {
        [Key, Column("request_id")]
        [DisplayName("Request ID")]
        public int RequestID { get; set; }



        [Column("status_finance_mgt")]

        [DisplayName("Finance Manager Status")]
        [EnumDataType(typeof(RequestStatus), ErrorMessage = "Invalid status. Please select from Pending, Approved, or Rejected.")]
        public RequestStatus? isFinanceApproval { get; set; } = RequestStatus.Pending;

        [Column("status_Partner_mgt")]
        [DisplayName("Partner Manager Comment")]
        [EnumDataType(typeof(RequestStatus), ErrorMessage = "Invalid status. Please select from Pending, Approved, or Rejected.")]
        public RequestStatus? isPartnerApproval { get; set; } = RequestStatus.Pending;

        [Column("comment_finace_mgt"), MaxLength(50)]
        [DisplayName("Finace Manager Comment")]
        public string? CommentFinaceMgt { get; set; } =string.Empty;

        [Column("comment_partner_mgt"), MaxLength(50)]
        [DisplayName("Partner Manager Comment")]
        public string? CommentPartnerMgt { get; set; } = string.Empty;
        public int NumberOfDays { get; set; }

        public string? MackAddress { get; set; }
        public string? HostUrl { get; set; }


        [ForeignKey("EndClientId")]
        public int EndClientId { get; set; }

        // Navigation property back to EndClient

        public virtual EndClient EndClient { get; set; }



       

        [ForeignKey("LicenseKeyId")]
        public int LicenseKeyId { get; set; }
        // Navigation property back to LicenseKey
        
        public virtual LicenseKey LicenseKey { get; set; }

        [ForeignKey("PartnerId ")]
        public int PartnerId { get; set; }
        // Navigation property back to LicenseKey
       
        public virtual Partner Partner { get; set; }


        [ForeignKey("FinaceManagerId")]
        public int FinaceManagerId { get; set; }
        // Navigation property back to LicenseKey
       
        public virtual FinaceManager FinaceManager { get; set; }

        [ForeignKey("PartnerManagerID")]
        public int PartnerManagerID { get; set; }
        // Navigation property back to LicenseKey
        
        public virtual PartnerManager PartnerManager { get; set; }

        public ICollection<Modules> Modules { get; set; }
    }


    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
