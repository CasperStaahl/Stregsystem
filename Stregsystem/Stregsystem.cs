using System;
using System.Collections.Generic;
using Stregsystem.Transactions;
using Stregsystem.Shared;
using Stregsystem.Products;
using Stregsystem.Users;
using System.Linq;
using System.IO;
using System.Net.Mail;

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

                string idString = subs[0];
                int idInt = Convert.ToInt32(idString);
                Id<Product> id = new Id<Product>(idInt);
                
                string nameString = subs[1];
                Name name = new Name(nameString);
                
                string priceString = subs[2];
                int priceInt = Convert.ToInt32(priceString);
                Ddk price = new Ddk(priceInt);

                string isActiveString = subs[3];
                int isActiveInt = Convert.ToInt32(isActiveString);
                bool isActive = Convert.ToBoolean(isActiveInt);

                Product product = new Product(id, name, price, isActive, false);
                _products.Add(product);
            }

            // For each line in the userFile add a user object to _users
            foreach (string line in File.ReadLines(userFileAddress).Skip(1))
            {
                string[] subs = line.Split(',');

                string idString = subs[0];
                int idInt = Convert.ToInt32(idString);
                Id<User> id = new Id<User>(idInt);
                
                string firstNameString = subs[1];
                Name firstName = new Name(firstNameString);

                string lastNameString = subs[2];
                Name lastName = new Name(firstNameString);

                string usernameString = subs[3];
                Username username = new Username(usernameString);

                string balanceString = subs[4];
                int balanceInt = Convert.ToInt32(balanceString);
                Ddk balance = new Ddk(balanceInt);
                
                string emailString = subs[5];
                MailAddress email = new MailAddress(emailString);

                User user = new User(id, firstName, lastName, username, balance, email);
                _users.Add(user);
            }
        }
    }
}