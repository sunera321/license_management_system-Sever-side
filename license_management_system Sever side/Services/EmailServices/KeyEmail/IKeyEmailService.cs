using license_management_system_Sever_side.Models.DTOs;
namespace license_management_system_Sever_side.Services.EmailServices.KeyEmail
{
    public interface IKeyEmailService
    {
        // Declaring a method to send an email, taking a RequestDTO as a parameter
        string SendEmail(SendKeyMailDto request);
    }
}
