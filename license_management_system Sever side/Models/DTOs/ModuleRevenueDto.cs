namespace license_management_system_Sever_side.Models.DTOs
{
    public class ModuleRevenueDto
    {
        public string? ModuleName { get; set; }
        public decimal ModulePrice { get; set; }
        public int NumberOfClients { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
