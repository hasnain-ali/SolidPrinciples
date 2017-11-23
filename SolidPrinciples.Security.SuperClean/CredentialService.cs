using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciples.Security.SuperClean.Credentials;
using SolidPrinciples.Security.SuperClean.Notification;
using SolidPrinciples.Security.Interfaces;
using SolidPrinciples.Security.Interfaces.Credentials;
using SolidPrinciples.Security.Interfaces.Notification;

namespace SolidPrinciples.Security.SuperClean
{
    public class CredentialService : ICredentialService
    {
        private IPasswordValidator _passwordValidator;
        private IEmailNotifier _emailNotifier;
        private ISmsNotifier _smsNotifier;

        public CredentialService()
        {
            _passwordValidator = new PasswordValidator();
            _emailNotifier = new PasswordChangeNotifier();
            _smsNotifier = new PasswordChangeNotifier();
        }

        public CredentialService(IPasswordValidator passwordValidator, IEmailNotifier emailNotifier, ISmsNotifier smsNotifier)
        {
            _passwordValidator = passwordValidator;
            _emailNotifier = emailNotifier;
            _smsNotifier = smsNotifier;
        }

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
            if (!_passwordValidator.TryValidate(newPassword, out passwordValidationErrorMessage))
            {
                throw new ArgumentException(passwordValidationErrorMessage, "newPassword");
            }

            // All done, now send email and SMS
            _emailNotifier.SendEmail("some.one@somewhere.com");
            _smsNotifier.SendSms("+441234567890");
        }
    }
}
