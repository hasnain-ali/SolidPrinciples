#region License
// <copyright file="PasswordValidator.cs" company="www.Achilles.com">
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
