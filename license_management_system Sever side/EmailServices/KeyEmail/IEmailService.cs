using Email_Test.DTOs;

namespace license_management_system_Sever_side.EmailServices.KeyEmail
{
    // Defining an interface for the email service
    public interface IEmailService
    {
        // Declaring a method to send an email, taking a RequestDTO as a parameter
        string SendEmail(RequestDTO request);
    }
}