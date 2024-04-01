
using license_management_system_Sever_side.DTOs;

namespace license_management_system_Sever_side.EmailServices.ContectMail
{
    public interface IContectEmalService
    {
        // Declaring a method to send an email, taking a RequestDTO as a parameter
        string SendEmail(SendMailDto request);
    }
}
