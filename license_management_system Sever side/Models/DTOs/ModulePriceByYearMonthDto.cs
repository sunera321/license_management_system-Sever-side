namespace license_management_system_Sever_side.Models.DTOs
{
    public class ModulePriceByYearMonthDto
    {

        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalModulePrice { get; set; }
    }
}
