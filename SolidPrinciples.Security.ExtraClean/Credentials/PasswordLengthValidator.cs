namespace SolidPrinciples.Security.ExtraClean.Credentials
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion

    public class PasswordLengthValidator
    {
        public bool IsValid(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            return password.Length >= 8 && password.Length <= 256;
        }
    }
}
