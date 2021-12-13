using Stregsystem.Shared;
using Stregsystem.Transactions;
using StregsystemTests.Fakes;
using Xunit;

namespace StregsystemTests.TransactionsTests
{
    public class InsertCashTransactionTests
    {
        [Fact]
        public void Execute_ValidTransaction_UserBalanceIncreased()
        {
            // Arrange
            FakeUser mockUser = new FakeUser(){ Balance = new Ddk(0)};
            Ddk amount = new Ddk(1);
            InsertCashTransaction transaction = 
                new InsertCashTransaction(mockUser, amount, new FakeIdProvider<Transaction>());
        
            // Act
            transaction.Execute();
        
            // Assert
            Ddk expected = mockUser.Balance;
            Ddk actual = new Ddk(1);
            Assert.Equal(expected, actual);
        }
    }
}