using System.Diagnostics;
using System.Net.Mail;

namespace SolidPrinciples.Security.ExtraClean.Notification
{
    public class ForgetPasswordNotifier : IEmailNotifier
    {
        public void SendEmail(string toEmailAddress)
        {
            var smtpClient = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = @"c:\testemail"
            };
            smtpClient.Send("support@achilles.com", toEmailAddress, "Forget Password", "Hi Some One, please click here to reset your password. Thank you.");
        }
    }
}
