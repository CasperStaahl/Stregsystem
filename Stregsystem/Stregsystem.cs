using System;
using System.Collections.Generic;
using Stregsystem.Transactions;
using Stregsystem.Shared;
using Stregsystem.Products;
using Stregsystem.Users;

namespace Stregsystem
{
    internal class Stregsystem
    {
        // private IEnumerable<Product> ActiveProducts { get; set; } 

        public IEnumerable<Product> ActiveProducts { get; } 

        private List<Product> _products = new List<Product>();

        private List<Transaction> _transactions = new List<Transaction>();

        private List<User> _users = new List<User>();

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
            List<Product> found = _products.FindAll(x => x.Id.Number == idNumber);
            if (0 < found.Count)
            {
                return found[0];
            }
            else
            {
                throw new ProductDoesNotExistException($"product with id {idNumber} does not exist");
            }
        }

        private IEnumerable<User> GetUsers(Predicate<User> predicate)
        {
            return _users.FindAll(predicate);
        }

        private User GetUserByUsername(Username username)
        {
            List<User> found = _users.FindAll(x => username.ToString() == x.Username.ToString());
            if (0 < found.Count)
            {
                return found[0];
            }
            else
            {
                throw new UserDoesNotExistException($"user with username {username.ToString()} does not exist");
            }
        }

        private IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            return _transactions.FindAll(x => x.User == user);
        }
    }
}