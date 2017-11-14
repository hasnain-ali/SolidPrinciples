#region License
// <copyright file="PasswordLowercaseValidator.cs" company="www.Achilles.com">
//  Achilles.com, 2017,  All rights reserved.
// </copyright>
// <author>Hasnain.Ali</author>
#endregion

namespace SolidPrinciples.Security.Clean.Credentials
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion

    public class PasswordLowercaseValidator
    {
        public bool IsValid(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (!password.ToCharArray().Any(char.IsLower))
            {
                return false;
            }

            return true;
        }
    }
}
