using System;
using Stregsystem.Shared;
using Xunit;

namespace StregsystemTests.SharedTests
{
    class NameTests
    {
        [Fact]
        public void NameCanNotHaveStringValueOfNull()
        {
            // Then
            Assert.Throws<ArgumentNullException>(() => new Name(null));
        }
        
    }

}