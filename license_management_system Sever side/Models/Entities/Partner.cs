namespace license_management_system_Sever_side.Models.Entities
{
    public class Partner : User
    {
        public Role UserRole { get; set; }=Role.Partner;


        // Navigation property for the related EndClients
        public virtual ICollection<EndClient> EndClients { get; set; }


        // Navigation property for the related EndClients
        public virtual ICollection<RequestKey> RequestKeys { get; set; }

    }
}
