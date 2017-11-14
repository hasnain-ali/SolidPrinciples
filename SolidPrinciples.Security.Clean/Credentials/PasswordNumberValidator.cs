#region License
// <copyright file="PasswordNumberValidator.cs" company="www.Achilles.com">
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
