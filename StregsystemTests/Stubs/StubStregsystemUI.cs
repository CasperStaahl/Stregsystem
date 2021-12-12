using System;
using Stregsystem;
using Stregsystem.Products;
using Stregsystem.Transactions;
using Stregsystem.Users;

namespace StregsystemTests.Stubs
{
    public class StubStregsystemUI : IStregsystemUI
    {
        public event EventHandler<string> CommandEntered;

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void DisplayGeneralError(string errorString)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserInfo(IUser user)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}