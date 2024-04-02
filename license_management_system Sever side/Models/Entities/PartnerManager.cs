namespace license_management_system_Sever_side.Models.Entities
{
    public class PartnerManager:User
    {
        public Role UserRole { get; set; }=Role.PartnerManager;

        // Navigation property for the related EndClients
        public virtual ICollection<RequestKey> RequestKeys { get; set; }
    }
}
