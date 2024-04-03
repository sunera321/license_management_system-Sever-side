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

        [Column("status_Partner_mgt")]
        [DisplayName("Finance Manager Status")]
        public RequestStatus? isFinanceApproval { get; set; } = RequestStatus.Pending;

        [Column("comment_finace_mgt")]
        [DisplayName("Partner Manager Comment")]
        public RequestStatus? isPartnerApproval { get; set; } = RequestStatus.Pending;

        [Column("comment_finace_mgt"), MaxLength(50)]
        [DisplayName("Finace Manager Comment")]
        public string? CommentFinaceMgt { get; set; } =string.Empty;

        [Column("comment_partner_mgt"), MaxLength(50)]
        [DisplayName("Partner Manager Comment")]
        public string? CommentPartnerMgt { get; set; } = string.Empty;
        public int NumberOfDays { get; set; }



        public int EndClientId { get; set; }

        // Navigation property back to EndClient
        [ForeignKey("EndClientId")]
        public virtual EndClient EndClient { get; set; }



        // Navigation property for the related Modules
        public virtual ICollection<Modules> Modules { get; set; }


        public int LicenseKeyId { get; set; }
        // Navigation property back to LicenseKey
        [ForeignKey("LicenseKeyId")]
        public virtual LicenseKey LicenseKey { get; set; }


        public int PartnerId { get; set; }
        // Navigation property back to LicenseKey
        [ForeignKey("PartnerId ")]
        public virtual Partner Partner { get; set; }



        public int FinaceManagerId { get; set; }
        // Navigation property back to LicenseKey
        [ForeignKey("FinaceManagerId")]
        public virtual FinaceManager FinaceManager { get; set; }


        public int PartnerManagerID { get; set; }
        // Navigation property back to LicenseKey
        [ForeignKey("PartnerManagerID")]
        public virtual PartnerManager PartnerManager { get; set; }
    }

    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
