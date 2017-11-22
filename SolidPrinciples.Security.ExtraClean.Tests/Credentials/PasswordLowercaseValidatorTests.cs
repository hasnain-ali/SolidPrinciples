using SolidPrinciples.Security.ExtraClean.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SolidPrinciples.Security.ExtraClean.Tests.Credentials
{
    public class PasswordLowercaseValidatorTests
    {
        [Fact(DisplayName = "PasswordLowercaseValidator_IsValid_WhenNull_ThrowsArgumentNullException")]
        public void PasswordLowercaseValidator_IsValid_WhenNull_ThrowsArgumentNullException()
        {
            var pv = new PasswordLowercaseValidator();
            Assert.Throws<ArgumentNullException>(() => pv.IsValid(null));
        }

        [Theory(DisplayName = "PasswordLowercaseValidator_IsValid_WhenInvalidValue_ReturnsFalse")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("T")]
        [InlineData("TEST@123")]
        [InlineData("TEST@ONETWOTHREE")]
        public void PasswordLowercaseValidator_IsValid_WhenInvalidValue_ReturnsFalse(string password)
        {
            Assert.False(new PasswordLowercaseValidator().IsValid(password));
        }

        [Theory(DisplayName = "PasswordLowercaseValidator_IsValid_WhenValidValue_ReturnsTrue")]
        [InlineData("t")]
        [InlineData("test")]
        [InlineData("TEsT")]
        [InlineData("tEST")]
        [InlineData("Test 123")]
        [InlineData("Test@123")]
        [InlineData("TEST at ONETWOTHREE")]
        [InlineData("TeST@ONETWOTHREE")]
        public void PasswordLowercaseValidator_IsValid_WhenValidValue_ReturnsTrue(string password)
        {
            Assert.True(new PasswordLowercaseValidator().IsValid(password));
        }
    }
}
