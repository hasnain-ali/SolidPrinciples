using SolidPrinciples.Security.SuperClean.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SolidPrinciples.Security.SuperClean.Tests.Credentials
{
     public class PasswordLengthValidatorTests
    {
        [Fact(DisplayName = "PasswordLengthValidator_IsValid_WhenNull_ThrowsArgumentNullException")]
        public void PasswordLengthValidator_IsValid_WhenNull_ThrowsArgumentNullException()
        {
            var pv = new PasswordLengthValidator();
            Assert.Throws<ArgumentNullException>(() => pv.IsValid(null));
        }

        [Theory(DisplayName = "PasswordLengthValidator_IsValid_WhenInvalidValue_ReturnsFalse")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("T")]
        [InlineData("Test@12")]
        [InlineData("ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword This1")] // 257 chars
        public void PasswordLengthValidator_IsValid_WhenInvalidValue_ReturnsFalse(string password)
        {
            Assert.False(new PasswordLengthValidator().IsValid(password));
        }

        [Theory(DisplayName = "PasswordLengthValidator_IsValid_WhenValidValue_ReturnsTrue")]
        [InlineData("Test@123")]
        [InlineData("Test@1234")]
        [InlineData("ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword This")] // 256 Chars
        [InlineData("ThisIsThePassword")]
        public void PasswordLengthValidator_IsValid_WhenValidValue_ReturnsTrue(string password)
        {
            Assert.True(new PasswordLengthValidator().IsValid(password));
        }
    }
}
