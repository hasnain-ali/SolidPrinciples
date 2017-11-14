using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciples.Security.Clean.Credentials;
using SolidPrinciples.Security.Clean.Notification;

namespace SolidPrinciples.Security.Clean
{
    public class CredentialService
    {
        public void ChangePassword(string username, string currentPassword, string newPassword, string confirmNewPassword)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("username");
            }

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

            if (!new PasswordLengthValidator().IsValid(newPassword))
            {
                throw new ArgumentException("Invalid length for new password", "newPassword");
            }

            if (!new PasswordUppercaseValidator().IsValid(newPassword))
            {
                throw new ArgumentException("No upper case letter in new password", "newPassword");
            }
            else if (!new PasswordLowercaseValidator().IsValid(newPassword))
            {
                throw new ArgumentException("No lower case letter in new password", "newPassword");
            }
            else if (!new PasswordNumberValidator().IsValid(newPassword))
            {
                throw new ArgumentException("No number in new password", "newPassword");
            }

            // All done, now send email
            new PasswordEmailNotifier().SendEmail("some.one@somewhere.com");
        }
    }
}
