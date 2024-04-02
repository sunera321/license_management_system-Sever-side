namespace license_management_system_Sever_side.Models.DTOs
{
    public class ModuleDTO
    {
        public int ModulesId { get; set; }
        public string Modulename { get; set; }
        public DateOnly CreatedData { get; set; }
        public string Features { get; set; }
        public string ModuleDescription { get; set; }
       
    }
}
