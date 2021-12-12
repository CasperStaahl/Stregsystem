using Xunit;
using Stregsystem.Shared;
using System;

namespace StregsystemTests.SharedTests
{
    public class IdTests
    {
        private class TestClass1 { }
        private class TestClass2 { }

        [Fact]
        public void Id_IdsWithDifferentClassParameter_IterateSeperatly()
        {
            // Arrange
            Id<TestClass1> a = new Id<TestClass1>();
            Id<TestClass2> b = new Id<TestClass2>();

            // Act

            // Assert
            Assert.Equal(a.Number, b.Number);
        }

        private class TestClass3 { }

        [Fact]
        public void Id_IdsWithSameClassParameter_IterateCodepently()
        {
            // Arrange
            Id<TestClass3> a = new Id<TestClass3>();
            Id<TestClass3> b = new Id<TestClass3>();

            // Act

            // Acsset
            Assert.NotEqual(a.Number, b.Number);
        }

        private class TestClass4 { }

        [Fact]
        public void Id_UseSameId_ThrowsArgumenException()
        {
            // Arrange
            Id<TestClass4> a = new Id<TestClass4>(0);

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => new Id<TestClass4>(0));
        }
    }
}