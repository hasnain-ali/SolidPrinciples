using System;
using System.Diagnostics;
using System.Net.Mail;

namespace SolidPrinciples.Security.SuperClean.Notification
{
    public class PasswordChangeNotifier : IEmailNotifier, ISmsNotifier
    {
        public void SendEmail(string toEmailAddress)
        {
            var smtpClient = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = @"c:\testemail"
            };
            smtpClient.Send("support@achilles.com", toEmailAddress, "Password changed", "Hi Some One, your pass has been changed successfully");
        }

        public void SendSms(string mobileNumber)
        {
            Debug.WriteLine("SMS: Your pass has been changed.");
        }
    }
}
