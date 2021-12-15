using System;
using Stregsystem.Model.Shared;
using Xunit;

namespace StregsystemTests.SharedTests
{
    public class NameTests
    {
        [Fact]
        public void Name_Null_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new Name(null));
        }

        [Fact]
        public void Name_NotNull_DoesNotThrowArgumentException()
        {
            // Arrange
            string nameAsString = "";

            // Act
            Name name = new Name(nameAsString);
        
            // Assert
            Assert.Equal(nameAsString, name.String);
        }
    }
}