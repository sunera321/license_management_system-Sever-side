namespace license_management_system_Sever_side.Models.DTOs
{
    public class EndClientWithRequestKeysDTO
    {
        public AddEndClientDto AddEndClientDto { get; set; }
        public IEnumerable<RequestKeyDto> RequestKeyDtos { get; set; }
    }
}
