using System.Net.Mail;

namespace SolidPrinciples.Security.Clean.Notification
{
    public class PasswordChangeNotifier
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
    }
}
