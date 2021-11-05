using System;
using Stregsystem.Shared;
using Stregsystem.Users;

namespace Stregsystem.Transactions
{
    abstract class Transaction
    {
        private Id _id = new Id();

        private User _user;

        private DateTime _date = new DateTime();

        private DDK _amount = new DDK(0, 0);

        public abstract void Execute();

        public override string ToString()
        {
            return $"{_id} {_user.ToString()} {_amount} {_date.ToString()}";
        }

        protected Transaction(User user, DateTime date, DDK amount)
        {
            _user = user;
            _date = date;
            _amount = amount;
        }
    }
}