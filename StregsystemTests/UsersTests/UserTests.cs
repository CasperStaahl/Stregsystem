using System;
using System.Net.Mail;
using Stregsystem.Shared;
using Stregsystem.Users;
using StregsystemTests.Fakes;
using Xunit;

namespace StregsystemTests
{
    public class UserTests
    {
        [Fact]
        public void BelowBalanceThreshold_BalanceBelowThreshold_RaiseBelowBalanceThreshold()
        {
            // Arrange
            User user = new User(1,
                                 new FakeIdProvider(),
                                 new Name("Test"),
                                 new Name("Testson"),
                                 new Username("test"),
                                 new Ddk(100),
                                 new MailAddress("test@test.test"));

            // Assert
            var evt = Assert.Raises<EventArgs>
            (
                h => user.BelowBalanceThreshold += h,
                h => user.BelowBalanceThreshold -= h,
                () => user.Balance = new Ddk(49)
            );

            Assert.NotNull(evt);
            Assert.Equal(user, evt.Sender);
            Assert.Equal(EventArgs.Empty, evt.Arguments);
        }

        [Fact]
        public void Equal_UserEqualToSelf_ReturnTrue()
        {
            // Arrange
            User user1 = new User(1,
                                  new FakeIdProvider(),
                                  new Name("Test"),
                                  new Name("Testson"),
                                  new Username("test"),
                                  new Ddk(100),
                                  new MailAddress("test@test.test"));

            // Act
            User user2 = user1;

            // Assert
            Assert.True(user1.Equals(user2));
            Assert.True(user2.Equals(user1));
        }

        [Fact]
        public void Equal_NotEqual_ReturnFalse()
        {
            // Arrange
            User user1 = new User(1,
                                  new FakeIdProvider(),
                                  new Name("Test"),
                                  new Name("Testson"),
                                  new Username("test"),
                                  new Ddk(100),
                                  new MailAddress("test@test.test"));

            User user2 = new User(2,
                                  new FakeIdProvider(),
                                  new Name("Test"),
                                  new Name("Testson"),
                                  new Username("test"),
                                  new Ddk(100),
                                  new MailAddress("test@test.test"));

            // Assert
            Assert.False(user1.Equals(user2));
            Assert.False(user2.Equals(user1));
        }

        [Fact]
        public void Equals_NotUser_ReturnFalse()
        {
            // Arrange
            User user1 = new User(1,
                                  new FakeIdProvider(),
                                  new Name("Test"),
                                  new Name("Testson"),
                                  new Username("test"),
                                  new Ddk(100),
                                  new MailAddress("test@test.test"));

            String test = "test";

            // Assert
            Assert.False(user1.Equals(test));
        }
    }
}