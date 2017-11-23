using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Security.Interfaces
{
    public interface ICredentialService
    {
        void ChangePassword(string username, string currentPassword, string newPassword, string confirmNewPassword);
    }
}
