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
        public void UserRaisesBelowBalanceThresholdWhenBalanceIsBelowThreshold()
        {
            // Given
            User user = new User(new FakeId<IUser>(),
                                 new Name("Test"),
                                 new Name("Testson"),
                                 new Username("test"),
                                 new Ddk(100),
                                 new MailAddress("test@test.test"));

            // Then
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
        public void EqualsReturnTrueWhenEqual()
        {
            // Given
            User user1 = new User(new FakeId<IUser>(),
                                 new Name("Test"),
                                 new Name("Testson"),
                                 new Username("test"),
                                 new Ddk(100),
                                 new MailAddress("test@test.test"));

            // When
            User user2 = user1;

            // Then
            Assert.True(user1.Equals(user2));
            Assert.True(user2.Equals(user1));
        }

        [Fact]
        public void EqualsReturnFalseWhenNotEqual()
        {
            // Given
            User user1 = new User(new FakeId<IUser>(1),
                                 new Name("Test"),
                                 new Name("Testson"),
                                 new Username("test"),
                                 new Ddk(100),
                                 new MailAddress("test@test.test"));

            User user2 = new User(new FakeId<IUser>(2),
                                 new Name("Test"),
                                 new Name("Testson"),
                                 new Username("test"),
                                 new Ddk(100),
                                 new MailAddress("test@test.test"));

            // Then
            Assert.False(user1.Equals(user2));
            Assert.False(user2.Equals(user1));
        }

        [Fact]
        public void EqualsReturnFalseWhenNotUser()
        {
            // Given
            User user1 = new User(new FakeId<IUser>(),
                                 new Name("Test"),
                                 new Name("Testson"),
                                 new Username("test"),
                                 new Ddk(100),
                                 new MailAddress("test@test.test"));

            String test = "test";

            // Then
            Assert.False(user1.Equals(test));
        }
    }
}