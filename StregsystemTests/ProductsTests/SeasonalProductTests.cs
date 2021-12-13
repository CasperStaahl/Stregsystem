using Stregsystem.Products;
using StregsystemTests.Fakes;
using Xunit;
using System;
using Stregsystem.Shared;

namespace StregsystemTests.ProductsTests
{
    public class SeasonalProductTests
    {
        [Fact]
        public void IsActive_IsWithinSeasonStartDateAndSeasonEndDateAndIsActive_ReturnsTrue()
        {
            // Arrange
            FakeDateTimeProvider stubDateTimeProvider =
                new FakeDateTimeProvider(new DateTime(2000, 1, 1, 1, 1, 1));
            
            SeasonalProduct product = new SeasonalProduct(1,
                                                          new FakeIdProvider<IProduct>(),
                                                          new Name(""),
                                                          new Ddk(0),
                                                          true,
                                                          true,
                                                          new DateTime(2000, 1, 1, 1, 1, 0),
                                                          new DateTime(2000, 1, 1, 1, 1, 2),
                                                          stubDateTimeProvider);

            // Act
            bool isActive = product.IsActive;

            // Assert
            Assert.True(isActive);
        }

        [Fact]
        public void IsActive_IsWithinSeasonStartDateAndSeasonEndDateAndIsNotActive_ReturnsFalse()
        {
            // Arrange
            FakeDateTimeProvider stubDateTimeProvider =
                new FakeDateTimeProvider(new DateTime(2000, 1, 1, 1, 1, 1));

            SeasonalProduct product = new SeasonalProduct(1,
                                                          new FakeIdProvider<IProduct>(),  
                                                          new Name(""),
                                                          new Ddk(0),
                                                          false,
                                                          true,
                                                          new DateTime(2000, 1, 1, 1, 1, 0),
                                                          new DateTime(2000, 1, 1, 1, 1, 2),
                                                          stubDateTimeProvider);

            // Act
            bool isActive = product.IsActive;

            // Assert
            Assert.False(isActive);
        }

        [Fact]
        public void IsActive_IsNotWithinSeasonStartDateAndSeasonEndDateAndIsActive_ReturnsFalse()
        {
            // Arrange
            FakeDateTimeProvider stubDateTimeProvider =
                new FakeDateTimeProvider(new DateTime(2000, 1, 1, 1, 1, 2));
            
            SeasonalProduct product = new SeasonalProduct(1,
                                                          new FakeIdProvider<IProduct>(),
                                                          new Name(""),
                                                          new Ddk(0),
                                                          true,
                                                          true,
                                                          new DateTime(2000, 1, 1, 1, 1, 0),
                                                          new DateTime(2000, 1, 1, 1, 1, 1),
                                                          stubDateTimeProvider);

            // Act
            bool isActive = product.IsActive;

            // Assert
            Assert.False(isActive);
        }
    }
}