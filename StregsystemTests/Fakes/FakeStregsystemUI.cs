using System;
using Stregsystem.Model.Transactions;
using Stregsystem.Model.Users;
using Stregsystem.View;

namespace StregsystemTests.Fakes
{
    public class FakeStregsystemUI : IStregsystemUI
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