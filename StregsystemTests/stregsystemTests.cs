using System.Collections.Generic;
using Stregsystem;
using Stregsystem.Loggers;
using Stregsystem.Model;
using Stregsystem.Model.Products;
using Stregsystem.Model.Shared;
using Stregsystem.Model.Users;
using StregsystemTests.Fakes;
using Xunit;

namespace StregsystemTests
{
    public class StregsystemTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetProductById_ValidProductId_ReturnsProductWithId(int productId)
        {
            // Arrange
            IStregsystem stregsystem = CreateTestStregsystem();

            // Act
            IProduct product = stregsystem.GetProductById(productId);

            // Assert
            int actual = product.Id;
            int expected = productId;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        public void GetProductById_InvalidProductId_ThrowsProductDoesNotExistException(int productId)
        {
            // Arrange
            IStregsystem stregsystem = CreateTestStregsystem();

            // Act
            // Assert
            Assert.Throws<ProductDoesNotExistException>(() => 
                stregsystem.GetProductById(productId));
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        public void GetUserByUsername_ValidUsername_ReturnsUserWithUserName(string username)
        {
            // Arrange
            IStregsystem stregsystem = CreateTestStregsystem();

            // Act
            IUser user = stregsystem.GetUserByUsername(new Username(username));

            // Assert
            string actual = user.Username.ToString();
            string expected = username;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetUserByUsername_InvalidUsername_ThrowsUserDoesNotExistException()
        {
            // Arrange
            IStregsystem stregsystem = CreateTestStregsystem();

            // Act
            // Assert
            Assert.Throws<UserDoesNotExistException>(() => 
                stregsystem.GetUserByUsername(new Username("0")));
        }

        private IStregsystem CreateTestStregsystem()
        {
            IList<IProduct> stubProducts = new List<IProduct>();
            stubProducts.Add(new FakeProduct() { Id = 1 });
            stubProducts.Add(new FakeProduct() { Id = 2 });
            stubProducts.Add(new FakeProduct() { Id = 3 });

            IList<IUser> stubUsers = new List<IUser>();
            stubUsers.Add(new FakeUser() { Username = new Username("1") });
            stubUsers.Add(new FakeUser() { Username = new Username("2") });
            stubUsers.Add(new FakeUser() { Username = new Username("3") });

            IIdProvider stubIdProvider = new FakeIdProvider();

            ILogger stubLogger = new FakeLogger();

            return new Stregsystem.Model.Stregsystem(stubProducts,
                                               stubUsers,
                                               stubIdProvider,
                                               stubLogger);
        }
    }
}