using System;
using Stregsystem.Shared;
using Xunit;

namespace StregsystemTests.SharedTests
{
    public class NameTests
    {
        [Fact]
        public void NameCanNotHaveStringValueOfNull()
        {
            // Then
            Assert.Throws<ArgumentNullException>(() => new Name(null));
        }

        [Fact]
        public void NameCanBeSet()
        {
            // Given
            string nameAsString = "Torben";

            // When
            Name name = new Name(nameAsString);
        
            // Then
            Assert.Equal(nameAsString, name.String);
        }
    }
}