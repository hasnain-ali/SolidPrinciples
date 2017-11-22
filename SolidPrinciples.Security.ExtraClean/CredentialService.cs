using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciples.Security.ExtraClean.Credentials;
using SolidPrinciples.Security.ExtraClean.Notification;

namespace SolidPrinciples.Security.ExtraClean
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

            string passwordValidationErrorMessage;
            if (!new PasswordValidator().TryValidate(newPassword, out passwordValidationErrorMessage))
            {
                throw new ArgumentException(passwordValidationErrorMessage, "newPassword");
            }

            // All done, now send email
            new PasswordEmailNotifier().SendEmail("some.one@somewhere.com");
        }
    }
}
