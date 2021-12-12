using System;
using System.Collections.Generic;
using Stregsystem.Transactions;
using Stregsystem.Shared;
using Stregsystem.Products;
using Stregsystem.Users;
using System.Linq;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Stregsystem
{

    public class Stregsystem : IStregsystem
    {
        public event EventHandler<User> UserBalanceBelowThreshold;

        public IEnumerable<IProduct> ActiveProducts { get => _products.Where(x => x.IsActive); }

        protected IList<IProduct> _products;

        protected IList<Transaction> _transactions;

        protected IList<IUser> _users;

        protected ILogger _logger;

        public Stregsystem()
        {
            InitializeStregSystem();
        }

        protected virtual void InitializeStregSystem()
        {
            // For each line, except the first, in the productFile add a product object to _products
            IList<IProduct> products = new List<IProduct>();
            foreach (string line in File.ReadLines(@"../../../products.csv").Skip(1))
            {
                string[] subs = line.Split(';');

                string idString = subs[0];
                int id = Convert.ToInt32(idString);

                string nameString = subs[1];
                nameString = Regex.Replace(nameString, "<.*?>", String.Empty);
                nameString = nameString.Replace("\"", String.Empty);
                Name name = new Name(nameString);

                string priceString = subs[2];
                int priceInt = Convert.ToInt32(priceString);
                Ddk price = new Ddk(priceInt);

                string isActiveString = subs[3];
                int isActiveInt = Convert.ToInt32(isActiveString);
                bool isActive = Convert.ToBoolean(isActiveInt);

                Product product = new Product(id, name, price, isActive, false);
                products.Add(product);
            }
            _products = products;

            IList<IUser> users = new List<IUser>();
            // For each line in the userFile add a user object to _users
            foreach (string line in File.ReadLines(@"../../../users.csv").Skip(1))
            {
                string[] subs = line.Split(',');

                string idString = subs[0];
                int id = Convert.ToInt32(idString);

                string firstNameString = subs[1];
                Name firstName = new Name(firstNameString);

                string lastNameString = subs[2];
                Name lastName = new Name(lastNameString);

                string usernameString = subs[3];
                Username username = new Username(usernameString);

                string balanceString = subs[4];
                int balanceInt = Convert.ToInt32(balanceString);
                Ddk balance = new Ddk(balanceInt);

                string emailString = subs[5];
                MailAddress email = new MailAddress(emailString);

                User user = new User(id, firstName, lastName, username, balance, email);
                user.BelowBalanceThreshold += OnUserBalanceBelowThreshold;
                users.Add(user);
            }
            _users = users;

            _transactions = new List<Transaction>();
            _logger = new Logger();
        }

        protected virtual void OnUserBalanceBelowThreshold(object user, EventArgs e)
        {
            EventHandler<User> handler = UserBalanceBelowThreshold;
            handler?.Invoke(this, (User)user);
        }

        public BuyTransaction BuyProduct(IUser user, IProduct product)
        {
            BuyTransaction transaction = new BuyTransaction(user, product);
            ExecuteTransaction(transaction);
            return transaction;
        }

        public InsertCashTransaction AddCreditToAccount(IUser user, Ddk amount)
        {
            InsertCashTransaction transaction = new InsertCashTransaction(user, amount);
            ExecuteTransaction(transaction);
            return transaction;
        }

        public IProduct GetProductById(int idNumber)
        {
            IProduct found = _products.Where(x => x.Id.Number == idNumber).FirstOrDefault();
            if (found != null)
                return found;
            else
                throw new ProductDoesNotExistException($"product with id {idNumber} does not exist");
        }

        public IEnumerable<IUser> GetUsers(Func<IUser, bool> predicate)
        {
            return _users.Where(predicate);
        }

        public IUser GetUserByUsername(Username username)
        {
            IUser found = _users.Where(x => username.ToString() == x.Username.ToString())
                                .FirstOrDefault();
            if (found != null)
                return found;
            else
                throw new UserDoesNotExistException($"user with username {username.ToString()} does not exist");
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            return _transactions.Where(x => x.User == user).Take(count);
        }

        private void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            _transactions.Add(transaction);
            _logger.Log(transaction.ToString());
        }
    }
}