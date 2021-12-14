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

        private int _id;

        protected Transaction(IUser user, Ddk amount, IIdProvider idProvider)
        {
            _id = idProvider.GetNextId();
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