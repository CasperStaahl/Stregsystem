using Stregsystem.Exceptions;
using Stregsystem.Products;
using Stregsystem.Shared;
using Stregsystem.Transactions;
using Stregsystem.Users;
using StregsystemTests.Fakes;
using Xunit;

namespace StregsystemTests.TransactionsTests
{

    public class BuyTransactionTests
    {
        [Fact]
        public void BuyTransactionSubtractsRightAmount()
        {
                // Given
                IUser user = new FakeUser() { Balance = new Ddk(100) };
            IProduct product = new FakeProduct() { Price = new Ddk(100), IsActive = true };
            BuyTransaction transaction = new BuyTransaction(user, product);

            // When
            transaction.Execute();

            // Then
            Ddk expected = new Ddk(0);
            Ddk actual = transaction.User.Balance;
            Assert.True(expected == actual);
        }

        [Fact]
        public void WhenExecutedThrowsExceptionWhenNotEnoughMoney()
        {
            // Given
            IUser user = new FakeUser() { Balance = new Ddk(50) };
            IProduct product = new FakeProduct() { Price = new Ddk(100), IsActive = true };
            BuyTransaction transaction = new BuyTransaction(user, product);

            // Then
            Assert.Throws<InsufficientCredistException>(() => transaction.Execute());
        }

        [Fact]
        public void ThrowsPrductIsNotActiveExceptionWhenProductIsNotActive()
        {
            // Given
            IUser user = new FakeUser() { Balance = new Ddk(50) };
            IProduct product = new FakeProduct() { Price = new Ddk(100), IsActive = false };
            BuyTransaction transaction = new BuyTransaction(user, product);

            // Then
            Assert.Throws<ProductIsNotActiveException>(transaction.Execute);
        }

        [Fact]
        public void BoughtOnCreditDoesNotThowInsufficientCreditsException()
        {
            // Given
            IUser user = new FakeUser() { Balance = new Ddk(0) };
            IProduct product = new FakeProduct()
            {
                Price = new Ddk(100),
                IsActive = true,
                CanBeBoughtOnCredit = true
            };
            BuyTransaction transaction = new BuyTransaction(user, product);

            // When
            transaction.Execute();

            // Then
            Ddk expected = new Ddk(-100);
            Ddk actual = transaction.User.Balance;
            Assert.True(expected == actual);
        }
    }
}