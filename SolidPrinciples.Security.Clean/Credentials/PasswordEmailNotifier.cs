#region License
// <copyright file="PasswordEmailNotifier.cs" company="www.Achilles.com">
//  Achilles.com, 2017,  All rights reserved.
// </copyright>
// <author>Hasnain.Ali</author>
#endregion

using System.Net.Mail;

namespace SolidPrinciples.Security.Clean.Credentials
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion

    public class PasswordEmailNotifier
    {
        public void SendEmail(string toEmailAddress)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            smtpClient.PickupDirectoryLocation = @"c:\testemail";
            smtpClient.Send("support@achilles.com", toEmailAddress, "Password changed", "Hi Some One, your pass has been changed successfully");
        }
    }
}
