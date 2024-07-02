using license_management_system_Sever_side.Models.DTOs;

public interface IEmailService
{
    void SendEmail(ContactFormDto formData);
}
