namespace license_management_system_Sever_side.Models
{
    public class Partner : user
    {
        public virtual ICollection<EndClient> EndClients { get; set; }
        public virtual ICollection<RequestKey> RequestKey { get; set; }

    }
}
