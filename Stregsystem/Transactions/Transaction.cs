using System;
using Stregsystem.Shared;
using Stregsystem.Users;

namespace Stregsystem.Transactions
{
    public abstract class Transaction
    {
        public IUser User { get => _user; }

        protected IUser _user;

        protected Ddk _amount = new Ddk(0);

        private DateTime _date = new DateTime();

        private Id<Transaction> _id = new Id<Transaction>();

        protected Transaction(IUser user, Ddk amount)
        {
            _user = user;

            if (new Ddk(0) <= amount)
                _amount = amount;
            else
                throw new ArgumentOutOfRangeException("Transaction amount can not be negative");

        }

        public virtual void Execute()
        {
            _date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{_id.Number} {_user.ToString()} {_amount} {_date.ToString()}";
        }
    }
}