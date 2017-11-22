﻿namespace SolidPrinciples.Security.ExtraClean.Credentials
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion

    public class PasswordUppercaseValidator
    {
        public bool IsValid(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (!password.ToCharArray().Any(char.IsUpper))
            {
                return false;
            }

            return true;
        }
    }
}
