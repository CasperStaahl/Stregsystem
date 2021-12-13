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
        public void Username_InvalidNameString_ThrowsArgumentException(string name)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new Username(name));
        }

        [Theory]
        [InlineData("casper1234")]
        [InlineData("casper")]
        [InlineData("casper_1234")]
        [InlineData("casper_casper")]
        [InlineData("1_2_3_4")]
        [InlineData("___")]
        public void Username_ValidNameString_UsernameIsSet(string nameAsString)
        {
            // Arrange 
            Username name = new Username(nameAsString);
            
            // Assert
            Assert.Equal(name.ToString(), nameAsString); 
        }
        
    }

}