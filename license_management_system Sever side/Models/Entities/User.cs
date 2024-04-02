namespace license_management_system_Sever_side.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
          
    }
    public enum Role
    {
        PartnerManager,
        Partner,
        FinanceManager
    }
   
}
