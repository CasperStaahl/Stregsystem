using System;
using Stregsystem.Users;
using Xunit;

namespace StregsystemTests.UsersTests
{
    public class UsernameTests
    {
        [Theory]
        [InlineData("    ")]
        [InlineData("CASPER")]
        [InlineData("@")]
        [InlineData("")]
        public void InvalidUsernameThrowsArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Username(name));
        }

        [Theory]
        [InlineData("casper1234")]
        [InlineData("casper")]
        [InlineData("casper_1234")]
        [InlineData("casper_casper")]
        [InlineData("1_2_3_4")]
        [InlineData("___")]
        public void ValidUsernameIsSet(string nameAsString)
        {
            // Given 
            Username name = new Username(nameAsString);
            
            // Then
            Assert.Equal(name.ToString(), nameAsString); 
        }
        
    }

}