using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Security.Interfaces.Credentials
{
    public interface IPasswordValidator
    {
        bool TryValidate(string password, out string errorMessage);
    }
}
