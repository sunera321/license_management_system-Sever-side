using license_management_system_Sever_side.Models.DTOs;

namespace license_management_system_Sever_side.Services.EmailServices.ContectMail
{
    public interface IContectEmalService
    {
        // Declaring a method to send an email, taking a RequestDTO as a parameter
        string SendEmail(SendClintMailDto request);
    }
}


