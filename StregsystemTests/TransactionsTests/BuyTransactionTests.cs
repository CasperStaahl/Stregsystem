using Stregsystem.Exceptions;
using Stregsystem.Model.Products;
using Stregsystem.Model.Shared;
using Stregsystem.Model.Transactions;
using Stregsystem.Model.Users;
using StregsystemTests.Fakes;
using Xunit;

namespace StregsystemTests.TransactionsTests
{

    public class BuyTransactionTests
    {
        [Fact]
        public void Execute_ValidBuyTransaction_UserBalanceReduced()
        {
            // Arrange
            IUser mockUser = new FakeUser() { Balance = new Ddk(1) };
            IProduct StubProduct = new FakeProduct() { Price = new Ddk(1), IsActive = true };
            BuyTransaction transaction = 
                new BuyTransaction(mockUser, StubProduct, new FakeIdProvider());

            // Act
            transaction.Execute();

            // Assert
            Ddk expected = new Ddk(0);
            Ddk actual = transaction.User.Balance;
            Assert.True(expected == actual);
        }

        [Fact]
        public void Execute_NotEnoughMoney_ThrowInsufficientCreditsException()
        {
            // Arrange 
            IUser stubUser = new FakeUser() { Balance = new Ddk(0) };
            IProduct stubproduct = new FakeProduct() { Price = new Ddk(1), IsActive = true };
            BuyTransaction transaction = 
                new BuyTransaction(stubUser, stubproduct, new FakeIdProvider());

            // Act

            // Assert
            Assert.Throws<InsufficientCredistException>(transaction.Execute);
        }

        [Fact]
        public void Execute_ProductIsNotActive_ThrowsProductIsNotActiveException()
        {
            // Arrange
            IUser stubUser = new FakeUser() { Balance = new Ddk(1) };
            IProduct stubProduct = new FakeProduct() { Price = new Ddk(1), IsActive = false };
            BuyTransaction transaction = 
                new BuyTransaction(stubUser, stubProduct, new FakeIdProvider());

            // Act

            // Then
            Assert.Throws<ProductIsNotActiveException>(transaction.Execute);
        }

        [Fact]
        public void Execute_ProductCanBeBoughtOnCreditUserInsufficientCredit_UserBalanceReduced()
        {
            // Arrange
            IUser mockUser = new FakeUser() { Balance = new Ddk(0) };
            IProduct stubProduct = new FakeProduct()
            {
                Price = new Ddk(100),
                IsActive = true,
                CanBeBoughtOnCredit = true
            };
            BuyTransaction transaction = 
                new BuyTransaction(mockUser, stubProduct, new FakeIdProvider());

            // Act
            transaction.Execute();

            // Assert
            Ddk expected = new Ddk(-100);
            Ddk actual = transaction.User.Balance;
            Assert.True(expected == actual);
        }
    }
}