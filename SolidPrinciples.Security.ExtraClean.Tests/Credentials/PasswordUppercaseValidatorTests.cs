using SolidPrinciples.Security.ExtraClean.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SolidPrinciples.Security.ExtraClean.Tests.Credentials
{
    public class PasswordUppercaseValidatorTests
    {
        [Fact(DisplayName = "PasswordUppercaseValidator_IsValid_WhenNull_ThrowsArgumentNullException")]
        public void PasswordUppercaseValidator_IsValid_WhenNull_ThrowsArgumentNullException()
        {
            var pv = new PasswordUppercaseValidator();
            Assert.Throws<ArgumentNullException>(() => pv.IsValid(null));
        }

        [Theory(DisplayName = "PasswordUppercaseValidator_IsValid_WhenInvalidValue_ReturnsFalse")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("t")]
        [InlineData("test@onetwothree")]
        [InlineData("test@123")]
        public void PasswordUppercaseValidator_IsValid_WhenInvalidValue_ReturnsFalse(string password)
        {
            Assert.False(new PasswordUppercaseValidator().IsValid(password));
        }

        [Theory(DisplayName = "PasswordUpperCaseValidator_IsValid_WhenValidValue_ReturnsTrue")]
        [InlineData("T")]
        [InlineData("teSt")]
        [InlineData("TEsT")]
        [InlineData("tEST")]
        [InlineData("Test 123")]
        [InlineData("Test@123")]
        [InlineData("TEST at ONETWOTHREE")]
        [InlineData("TeST@ONETWOTHREE")]
        public void PasswordUpperCaseValidator_IsValid_WhenValidValue_ReturnsTrue(string password)
        {
            Assert.True(new PasswordUppercaseValidator().IsValid(password));
        }
    }
}
