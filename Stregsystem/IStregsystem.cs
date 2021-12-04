using System;
using System.Collections.Generic;
using Stregsystem.Transactions;
using Stregsystem.Shared;
using Stregsystem.Products;
using Stregsystem.Users;

namespace Stregsystem
{
    internal interface IStregsystem
    {
        IEnumerable<Product> ActiveProducts { get; }

        event EventHandler<User> UserBalanceBelowThreshold;

        void AddCreditToAccount(User user, Ddk amount);
        void BuyProduct(User user, Product product);
        Product GetProductById(int idNumber);
        IEnumerable<Transaction> GetTransactions(User user, int count);
        User GetUserByUsername(Username username);
        IEnumerable<User> GetUsers(Predicate<User> predicate);
    }
}