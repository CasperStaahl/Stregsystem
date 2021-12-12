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
        public IEnumerable<IProduct> ActiveProducts => throw new NotImplementedException();

        public event EventHandler<User> UserBalanceBelowThreshold;

        public InsertCashTransaction AddCreditToAccount(IUser user, Ddk amount)
        {
            throw new NotImplementedException();
        }

        public BuyTransaction BuyProduct(IUser user, IProduct product)
        {
            throw new NotImplementedException();
        }

        public IProduct GetProductById(int idNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            throw new NotImplementedException();
        }

        public IUser GetUserByUsername(Username username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> GetUsers(Func<IUser, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}