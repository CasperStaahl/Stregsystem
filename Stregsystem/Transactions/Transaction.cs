using System;
using src.Users;
using Stregsystem.Shared;

namespace src.Transactions
{
    internal abstract class Transaction
    {
        protected User _user;

        protected Ddk _amount = new Ddk(0);

        protected DateTime _date = new DateTime();

        private Id<Transaction> _id = new Id<Transaction>();

        protected Transaction(User user, Ddk amount)
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