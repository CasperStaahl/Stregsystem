using Stregsystem.Transactions;
using Stregsystem.Products;
using Stregsystem.Users;
using System;

namespace Stregsystem
{
    public interface IStregsystemUI
    {
        event EventHandler<string> CommandEntered;
        void DisplayUserInfo(IUser user);
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void Close();
        void DisplayGeneralError(string errorString);
        void Start();
        // void DisplayInsufficientCash(User user, Product product);
        // void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        // void DisplayTooManyArgumentsError(string command);
        // void DisplayAdminCommandNotFoundMessage(string adminCommand);
        // void DisplayUserNotFound(string username);
        // void DisplayProductNotFound(string product);
    }
}