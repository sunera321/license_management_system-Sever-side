namespace license_management_system_Sever_side.Models.Entities
{
    public class FinaceManager : User
    {
        public Role UserRole { get; set; }=Role.FinanceManager;

        // Navigation property for the related EndClients
        public virtual ICollection<RequestKey> RequestKeys { get; set; }
    }
}
