﻿using System;

namespace SolidPrinciples.Security.ExtraClean.Credentials
{
    public class PasswordValidator
    {
        public bool TryValidate(string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (!new PasswordLengthValidator().IsValid(password))
            {
                errorMessage = "Invalid length for password";
                return false;
            }

            if (!new PasswordUppercaseValidator().IsValid(password))
            {
                errorMessage = "No upper case letter in password";
                return false;
            }
            
            if (!new PasswordLowercaseValidator().IsValid(password))
            {
                errorMessage = "No lower case letter in password";
                return false;
            }
            
            if (!new PasswordNumberValidator().IsValid(password))
            {
                errorMessage = "No number in password";
                return false;
            }

            return true;
        }
    }
}
