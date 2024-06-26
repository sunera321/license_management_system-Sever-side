namespace license_management_system_Sever_side.Models.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public string CustomerId { get; set; }
    }

}
