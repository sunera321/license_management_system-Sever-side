using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Services.ActivateKeySerives
{
    public class ActivateKeySerives: IActivateKeySerives
    {
        private DataContext _context;
        private string message;
        public ActivateKeySerives(DataContext context ) 
        {
            _context = context;
        }

        public string ActivateLicnseKey(ActivateKeyDot ValidetKey)
        {
          
            ActivateKeyDot activateKey = new ActivateKeyDot();
            activateKey.Clint_License_Key = ValidetKey.Clint_License_Key;

            License_key key = _context.License_keys.FirstOrDefault(c => c.Key_name == ValidetKey.Clint_License_Key);
            if (key == null)
            {
                Console.WriteLine("Invalid Key");
                message = "Invalid Key";
                return (message);
            }

            else
            {
                if (key.DeactivatedDate > DateTime.Now)
                {
                    if (key.Key_Status == "Activated")
                    {
                        message = "Key Already Activated";
                        return (message);
                    }
                    else
                    {
                        key.Key_Status = "Activated";
                        message = "Activated";
                        //save data base
                        try
                        {
                            _context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e);
                        }
                        return (message);
                        


                    }
                }
                else
                {
                    key.Key_Status = "Expired";
                    message = "Expired";
                    try
                    {
                        _context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e);
                    }
                    return (message);

                }

            }
        }
    }
}
