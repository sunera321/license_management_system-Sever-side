using Email_Test.DTOs;

namespace Email_Test.EmailService
{
    // Defining an interface for the email service
    public interface IEmailService
    {
        // Declaring a method to send an email, taking a RequestDTO as a parameter
        string SendEmail(RequestDTO request);
    }
}