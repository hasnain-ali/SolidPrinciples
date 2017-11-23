namespace SolidPrinciples.Security.SuperClean.Credentials
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion

    public class PasswordNumberValidator
    {
        public bool IsValid(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (!password.ToCharArray().Any(char.IsNumber))
            {
                return false;
            }

            return true;
        }
    }
}
