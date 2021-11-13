using System;
using System.Collections.Generic;
using Stregsystem.Transactions;
using src.Users;
using Stregsystem.Shared;
using Stregsystem.Products;

namespace Stregsystem
{
    internal class Stregsystem
    {
        // private IEnumerable<Product> ActiveProducts { get; set; } 

        private List<Product> _products = new List<Product>();

        private List<Transaction> _transactions = new List<Transaction>();

        private void BuyProduct(User user, Product product)
        {
            Transaction transaction = new BuyTransaction(user, product);
            ExecuteTransaction(transaction);
        }

        private void AddCreditToAccount(User user, Ddk amount)
        {
            Transaction transaction = new InsertCashTransaction(user, amount);
            ExecuteTransaction(transaction);
        }

        private void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            _transactions.Add(transaction);
        }

        private Product GetProductById(int idNumber)
        {
            return _products.Find(x => x.Id.Number == idNumber);
        }

        private IEnumerable<User> GetUsers(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        private User GetUserByUsername(Username username)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            throw new NotImplementedException();
        }
    }

}