﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Foolproof;
using System.Text.Json.Serialization;
using System;

namespace license_management_system_Sever_side.Models.Entities
{
    public class RequestKey
    {
        public RequestKey()
        {
            isFinanceApproval = false;
            isPartnerApproval = false;
        }

        [Key, Column("request_id")]
        [DisplayName("Request ID")]
        public int RequestID { get; set; }

        [Column("status_finance_mgt")]
        [DisplayName("Finance Manager Status")]


        public bool isFinanceApproval { get; set; }

        [Column("status_Partner_mgt")]
        [DisplayName("Partner Manager Status")]

        public bool isPartnerApproval { get; set; }

        [Column("issued")]
        [DisplayName("Key issued")]
        public bool issued { get; set; } = false;


        [Column("comment_finace_mgt"), MaxLength(50)]
        [DisplayName("Finace Manager Comment")]
        public string? CommentFinaceMgt { get; set; } = null;

        [Column("comment_partner_mgt"), MaxLength(50)]
        [DisplayName("Partner Manager Comment")]
        public string? CommentPartnerMgt { get; set; } = null;
        public int NumberOfDays { get; set; }

        [ForeignKey("EndClientId")]
        public int EndClientId { get; set; }
        // Navigation property back to EndClient
        public virtual EndClient EndClient { get; set; }


        [ForeignKey("PartnerId ")]
        public int PartnerId { get; set; }
        // Navigation property back to LicenseKey

        public virtual Partner Partner { get; set; }

        [ForeignKey("FinaceManagerId")]
        public int? FinaceManagerId { get; set; }
        // Navigation property back to LicenseKey

        public virtual FinaceManager FinaceManager { get; set; }

        [ForeignKey("PartnerManagerID")]
        public int? PartnerManagerID { get; set; }
        // Navigation property back to LicenseKey

        public virtual PartnerManager? PartnerManager { get; set; }
        [JsonIgnore]
     
        public License_key? License_key { get; set; }

    }
    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
}