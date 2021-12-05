using Stregsystem.Transactions;
using Stregsystem.Products;
using Stregsystem.Users;
using System;

namespace Stregsystem
{
    internal class StregsystemCLI : IStregsystemUI
    {
        public event EventHandler<string> CommandEntered;

        private bool _running = true;

        private IStregsystem _stregsystem;

        public StregsystemCLI(IStregsystem stregsystem)
        {
            _stregsystem = stregsystem;
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine($"The admin command \"{adminCommand}\" could not be found!");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine($"ERROR: {errorString}");
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine
                ($"User \"{user.ToString()}\" does not have enough founds to buy product \"{product.ToString()}\"");
        }

        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine($"{product} could not be found!");
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine($"The command \"{command}\" contains to many arguments!");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.ToString());
        }

        // TODO figure out what the fuck count should do
        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            DisplayUserBuysProduct(transaction);
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(user.ToString());
        }


        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"User {username} not found!");
        }

        private void DrawUI()
        {
            foreach (Product product in _stregsystem.ActiveProducts)
            {
                Console.WriteLine(product.ToString());
            }
            Console.Write("#");
        }

        public void Start()
        {
            while (_running)
            {
                DrawUI();
                string command = Console.ReadLine();
                Console.WriteLine();
                OnCommandEntered(command);
                Console.WriteLine();
            }
        }

        public void Close()
        {
            _running = false;
        }

        protected virtual void OnCommandEntered(string command)
        {
            EventHandler<string> handler = CommandEntered;
            handler?.Invoke(this, command);
        }
    }
}
