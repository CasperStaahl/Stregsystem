using System;
using System.Collections.Generic;
using Stregsystem.Transactions;
using Stregsystem.Shared;
using Stregsystem.Products;
using Stregsystem.Users;
using System.Linq;
using System.IO;

namespace Stregsystem
{
    internal class Stregsystem
    {
        public IEnumerable<Product> ActiveProducts { get => _products.FindAll(x => x.IsActive); }

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
                return found[0];
            else
                throw new ProductDoesNotExistException($"product with id {idNumber} does not exist");
        }

        private IEnumerable<User> GetUsers(Predicate<User> predicate)
        {
            return _users.FindAll(predicate);
        }

        private User GetUserByUsername(Username username)
        {
            List<User> found = _users.FindAll(x => username.ToString() == x.Username.ToString());
            if (0 < found.Count)
                return found[0];
            else
                throw new UserDoesNotExistException($"user with username {username.ToString()} does not exist");
        }

        private IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            return _transactions.FindAll(x => x.User == user).Take(count);
        }

        // This constructur will instantiate a Stregsystem given two file addresses. 
        // If either Address is invalid it will throw an error.
        public Stregsystem(string productFileAddress, string userFileAddress)
        {
            // For each line, except the first, in the productFile add a product object to _products
            foreach (string line in File.ReadLines(productFileAddress).Skip(1))
            {
                string[] subs = line.Split(';');

                // Product product = new Product();
                
            }

            // For each line in the userFile add a user object to _users

        }
    }
}