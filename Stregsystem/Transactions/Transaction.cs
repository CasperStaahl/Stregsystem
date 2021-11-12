using System;
using src.Shared;
using src.Users;
using Stregsystem.Shared;

namespace src.Transactions
{
    internal abstract class Transaction
    {
        protected User _user;

        protected DDK _amount = new DDK(0);

        protected DateTime _date = new DateTime();

        private Id<Transaction> _id = new Id<Transaction>();

        protected Transaction(User user, DDK amount)
        {
            _user = user;
            _amount = amount;
        }

        public virtual void Execute()
        {
            _date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{_id} {_user.ToString()} {_amount} {_date.ToString()}";
        }
    }
}