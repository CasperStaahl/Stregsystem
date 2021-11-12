using Xunit;
using Stregsystem.Shared;
using System;

namespace test.SharedTests
{
    public class IdTests
    {
        private class TestClass1 { }
        private class TestClass2 { }
        [Fact]
        public void IdRelatedToSeperatClassesIterateIndependently()
        {
            Id<TestClass1> a = new Id<TestClass1>();
            Id<TestClass2> b = new Id<TestClass2>();
            Assert.Equal(a.Number, b.Number);
        }

        private class TestClass3 { }
        [Fact]
        public void IdRelatedToSameClassIterateCodepently()
        {
            Id<TestClass3> a = new Id<TestClass3>();
            Id<TestClass3> b = new Id<TestClass3>();
            Assert.NotEqual(a.Number, b.Number);
        }
    }
}