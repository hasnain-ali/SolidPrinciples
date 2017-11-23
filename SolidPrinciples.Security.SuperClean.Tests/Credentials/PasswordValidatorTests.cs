using SolidPrinciples.Security.SuperClean.Credentials;
using System;
using Xunit;

namespace SolidPrinciples.Security.SuperClean.Tests.Credentials
{
    public class PasswordValidatorTests
    {
        [Fact(DisplayName = "PasswordValidator_TryValidate_WhenNull_ThrowsArgumentNullException")]
        public void PasswordValidator_TryValidate_WhenNull_ThrowsArgumentNullException()
        {
            string msg;
            var pv = new PasswordValidator();
            Assert.Throws<ArgumentNullException>(() => pv.TryValidate(null, out msg));
        }

        [Fact(DisplayName = "PasswordValidator_TryValidate_WhenInvalidPasswordLengthValue_ReturnsFalseWithMessage")]
        public void PasswordValidator_TryValidate_WhenInvalidPasswordLengthValue_ReturnsFalseWithMessage()
        {
            string msg;
            Assert.False(new PasswordValidator().TryValidate(string.Empty, out msg));
            Assert.Equal("Invalid length for password", msg);
        }

        [Fact(DisplayName = "PasswordValidator_TryValidate_WhenInvalidPasswordNoUpperCaseValue_ReturnsFalseWithMessage")]
        public void PasswordValidator_TryValidate_WhenInvalidPasswordNoUpperCaseValue_ReturnsFalseWithMessage()
        {
            string msg;
            Assert.False(new PasswordValidator().TryValidate("alllowercase", out msg));
            Assert.Equal("No upper case letter in password", msg);
        }

        [Fact(DisplayName = "PasswordValidator_TryValidate_WhenInvalidPasswordNoLowerCaseValue_ReturnsFalseWithMessage")]
        public void PasswordValidator_TryValidate_WhenInvalidPasswordNoLowerCaseValue_ReturnsFalseWithMessage()
        {
            string msg;
            Assert.False(new PasswordValidator().TryValidate("ALLUPPERCASE", out msg));
            Assert.Equal("No lower case letter in password", msg);
        }

        [Fact(DisplayName = "PasswordValidator_TryValidate_WhenInvalidPasswordNoNumberInValue_ReturnsFalseWithMessage")]
        public void PasswordValidator_TryValidate_WhenInvalidPasswordNoNumberInValue_ReturnsFalseWithMessage()
        {
            string msg;
            Assert.False(new PasswordValidator().TryValidate("NoNumberText", out msg));
            Assert.Equal("No number in password", msg);
        }
        
        [Fact(DisplayName = "PasswordValidator_TryValidate_WhenValidPasswordValue_ReturnsTrueWitNoMessage")]
        public void PasswordValidator_TryValidate_WhenValidPasswordValue_ReturnsTrueWitNoMessage()
        {
            string msg;
            Assert.True(new PasswordValidator().TryValidate("Test@123", out msg));
            Assert.Equal(string.Empty, msg);
        }

    }
}
