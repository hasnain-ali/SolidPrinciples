using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciple.Security.Legacy
{
    public class CredentialManager
    {
        public void ChangePassword(string currentPassword, string newPassword, string confirmNewPassword)
        {
            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                throw new ArgumentNullException("currentPassword");
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                throw new ArgumentNullException("newPassword");
            }

            if (string.IsNullOrWhiteSpace(confirmNewPassword))
            {
                throw new ArgumentNullException("confirmNewPassword");
            }
            
            // Check if current and new are same
            if (newPassword.Equals(currentPassword))
            {
                throw new ArgumentException("New password should be different then the current one");
            }

            // Check if both of new and confirm new are same
            if (!newPassword.Equals(confirmNewPassword))
            {
                throw new ArgumentException("Comfirm password is different then the new password");
            }

            if (newPassword.Length < 8 || newPassword.Length > 256)
            {
                throw new ArgumentException("Invalid length for new password", "newPassword");
            }

            if (!newPassword.ToCharArray().Any(char.IsUpper))
            {
                throw new ArgumentException("No upper case letter in new password", "newPassword");
            }
            else if (!newPassword.ToCharArray().Any(char.IsLower))
            {
                throw new ArgumentException("No lower case letter in new password", "newPassword");
            }
            else if (!newPassword.ToCharArray().Any(char.IsNumber))
            {
                throw new ArgumentException("No number in new password", "newPassword");
            }

            // All done, now send email
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            smtpClient.PickupDirectoryLocation = @"c:\testemail";
            smtpClient.Send("support@achilles.com","some.one@achilles.com","Password changed", "Hi Some One, your pass has been changed successfully");
        }
    }
}
