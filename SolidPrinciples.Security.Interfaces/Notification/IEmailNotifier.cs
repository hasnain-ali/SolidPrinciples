using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Security.Interfaces.Notification
{
    public interface IEmailNotifier
    {
        void SendEmail(string toEmailAddress);
    }
}
