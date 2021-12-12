using System;
using System.Collections.Generic;
using Stregsystem;
using Stregsystem.Products;
using Stregsystem.Shared;
using Stregsystem.Transactions;
using Stregsystem.Users;

namespace StregsystemTests.Stubs
{
    class StubStregSystem : IStregsystem
    {
        public IEnumerable<Product> ActiveProducts => throw new NotImplementedException();

        public event EventHandler<User> UserBalanceBelowThreshold;

        public InsertCashTransaction AddCreditToAccount(User user, Ddk amount)
        {
            throw new NotImplementedException();
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int idNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(Username username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers(Predicate<User> predicate)
        {
            throw new NotImplementedException();
        }
    }
}