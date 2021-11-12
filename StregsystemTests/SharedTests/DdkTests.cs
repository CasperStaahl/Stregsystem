using System;
using Stregsystem.Shared;
using Xunit;

namespace StregsystemTests.SharedTests
{
    public class DDKTests
    {

        [Fact]
        public void DdkAddition()
        {
            Ddk a = new Ddk(new Decimal(4.6));
            Ddk b = new Ddk(new Decimal(5.4));
            Ddk expected = a + b; 

            Ddk actual = new Ddk(new Decimal(10));

            Assert.Equal(expected, actual);
        }
    }
}