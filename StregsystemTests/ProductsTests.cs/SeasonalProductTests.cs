using Stregsystem.Products;
using Stregsystem.Shared;
using Xunit;
using System;

namespace StregsystemTests.ProductsTests.cs
{
    public class SeasonalProductTests
    {
        // [Theory]
        [InlineData(1, 0, 0, 1, 0, 0)]
        [InlineData(0, 1, 0, 0, 1, 0)]
        [InlineData(0, 0, 1, 0, 0, 1)]
        [InlineData(7, 4, 3, 2, 8, 4)]
        public void IsActiveBetweenStartDateAndEndDate(
                                                       int startDateMinutesOffset,
                                                       int startDateHoursOffset,
                                                       int startDateDaysOffset,
                                                       int endDateMinutesOffset,
                                                       int endDateHoursOffset,
                                                       int endDateDaysOffset)
        {
            // Given
            SeasonalProduct product
                = new SeasonalProduct(1,
                                      new Name("test"),
                                      new Ddk(100),
                                      true,
                                      true,
                                      DateTime.Now.AddMinutes(-startDateMinutesOffset)
                                                  .AddHours(-startDateHoursOffset)
                                                  .AddDays(-startDateDaysOffset),
                                      DateTime.Now.AddMinutes(endDateMinutesOffset)
                                                  .AddHours(endDateHoursOffset)
                                                  .AddDays(endDateDaysOffset));
            // When
            // Then
            Assert.True(product.IsActive);
        }
    }
}