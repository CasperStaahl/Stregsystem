using System;
using System.Collections.Generic;
using Stregsystem.Model.Products;
using Stregsystem.Model.Shared;
using Stregsystem.Model.Transactions;
using Stregsystem.Model.Users;

namespace Stregsystem.Model
{
    public interface IStregsystem
    {
        IEnumerable<IProduct> ActiveProducts { get; }

        event EventHandler<User> UserBalanceBelowThreshold;

        InsertCashTransaction AddCreditToAccount(IUser user, Ddk amount);
        BuyTransaction BuyProduct(IUser user, IProduct product);
        IProduct GetProductById(int idNumber);
        IEnumerable<Transaction> GetTransactions(User user, int count);
        IUser GetUserByUsername(Username username);
        IEnumerable<IUser> GetUsers(Func<IUser, bool> predicate);
    }
}