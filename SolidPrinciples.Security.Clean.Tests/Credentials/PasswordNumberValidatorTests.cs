using SolidPrinciples.Security.Clean.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SolidPrinciples.Security.Clean.Tests.Credentials
{
    public class PasswordNumberValidatorTests
    {
        [Fact(DisplayName = "PasswordNumberValidator_IsValid_WhenNull_ThrowsArgumentNullException")]
        public void PasswordNumberValidator_IsValid_WhenNull_ThrowsArgumentNullException()
        {
            var pv = new PasswordNumberValidator();
            Assert.Throws<ArgumentNullException>(() => pv.IsValid(null));
        }

        [Theory(DisplayName = "PasswordNumberValidator_IsValid_WhenInvalidValue_Returns_False")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("T")]
        [InlineData("Test@One")]
        [InlineData("Test@OneTwoThree")]
        [InlineData("ThisIsThePassword ThisIsThePassword ThisIsThePassword ThisIsThePassword")]
        public void PasswordNumberValidator_IsValid_WhenInvalidValue_Returns_False(string password)
        {
            Assert.False(new PasswordNumberValidator().IsValid(password));
        }

        [Theory(DisplayName = "PasswordNumberValidator_IsValid_WhenInvalidValue_ReturnsTrue")]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("12Three")]
        [InlineData("One2Three")]
        [InlineData("Test@123")]
        [InlineData("Test@1234")]
        [InlineData("ThisIsThePassword ThisIsThePassword ThisIsThePassword Th1s")]
        [InlineData("This1sThePassword")]
        public void PasswordNumberValidator_IsValid_WhenInvalidValue_ReturnsTrue(string password)
        {
            Assert.True(new PasswordNumberValidator().IsValid(password));
        }
    }
}
